using AutoMapper;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Controllers.Utility
{
    [Route("api/autocompletes")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AutoCompletesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public AutoCompletesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }


       
        [HttpGet("products/{query}")]
        public async Task<IActionResult> GetProductAutocompleteAsync(string query)
        {
            var products = await _repository.AutoComplete.GetProductAutocompleteAsync(query);
            return Ok(products);
        }

    }
}
