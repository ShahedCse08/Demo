using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Creation;
using Entities.DataTransferObjects.Retrieve;
using Entities.DataTransferObjects.Update;
using Entities.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Demo.ActionFilter;
using Demo.ModelBinders;

namespace Demo.Controllers
{
   // [ApiVersion("1.0")]
    [Route("api/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]

    //[ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly DateTimeOffset cacheExpirationOptions;
        private readonly IDistributedCache _distributedCache;

        public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }



        /// <summary>
        /// Creates a newly created company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>A newly created company</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateCompany")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            
            var companyEntity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEntity);
           await _repository.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id }, companyToReturn);
        }

        #region In Memory Cache
        // /// <summary>
        // /// Gets the list of all companies
        // /// </summary>
        // /// <returns>The companies list</returns>
        // [HttpGet(Name = "GetCompanies"), Authorize]
        //// [HttpGet(Name = "GetCompanies"), Authorize(Roles = "Manager")]
        // public async Task<IActionResult> GetCompanies()
        // {
        //     var cacheKey = "";
        //     if (!_memoryCache.TryGetValue(cacheKey ,out IEnumerable<CompanyDto> companiesDto)) {

        //         var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges: false);
        //         companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        //         _memoryCache.Set(cacheKey, companiesDto,cacheExpirationOptions);
        //     }
        //     return Ok(companiesDto);

        //     //var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges: false); //old
        //     //var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        //     //return Ok(companiesDto);

        // }
        #endregion

        /// <summary>
        /// Gets the list of all companies
        /// </summary>
        /// <returns>The companies list</returns>
        [HttpGet(Name = "GetCompanies")]
        // [HttpGet(Name = "GetCompanies"), Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCompanies()
        {


            var cacheKey = "";

            IEnumerable<CompanyDto> companiesDto;
            string serializedMovies;

            var encodedCompanies = await _distributedCache.GetAsync(cacheKey);

            if (encodedCompanies != null)
            {
                serializedMovies = Encoding.UTF8.GetString(encodedCompanies);
                companiesDto = JsonConvert.DeserializeObject<IEnumerable<CompanyDto>>(serializedMovies);
            }
            else
            {
                var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges: false);
                companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                serializedMovies = JsonConvert.SerializeObject(companiesDto);
                encodedCompanies = Encoding.UTF8.GetBytes(serializedMovies);
                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(6));
                await _distributedCache.SetAsync(cacheKey, encodedCompanies, options);
            }
             return Ok(companiesDto);
           

        }


        [HttpGet("{id}", Name = "CompanyById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]

        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _repository.Company.GetCompanyAsync(id, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(companyDto);
            }
        }


        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollectionn([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var companyEntities = await _repository.Company.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != companyEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            return Ok(companiesToReturn);
        }

     
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection == null)
            {
                _logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CompanyForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
            await _repository.SaveAsync();
            var companyCollectionToReturn =
           _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("CompanyCollection", new { ids },
           companyCollectionToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateCompanyExistsAttribute))]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var company = HttpContext.Items["company"] as Company;

            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {

            var companyEntity = HttpContext.Items["company"] as Company;
            _mapper.Map(company, companyEntity);
            await _repository.SaveAsync();
            return NoContent();

        }


        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }


    }
}


