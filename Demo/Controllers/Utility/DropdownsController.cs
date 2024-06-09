using AutoMapper;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using Contracts.Interfaces.Utility;
using Entities.Models.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Controllers.Utility
{
    [Route("api/dropdowns")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]

    public class DropdownsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DropdownsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSuppliersDropdown()
        {
            var dropdownItems = await _repository.Dropdown.GetSuppliersDropdownAsync();
            return Ok(dropdownItems);
        }


    }
}
