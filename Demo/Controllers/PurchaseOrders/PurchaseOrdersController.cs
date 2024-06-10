using AutoMapper;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using Entities.DataTransferObjects.Retrieve;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using Entities.Models;
using Entities.DataTransferObjects.Creation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities.Models.PurchaseOrders;
using System.Collections.Generic;
using Entities.DataTransferObjects.Manipulator;

namespace Demo.Controllers.PurchaseOrders
{
    [Route("api/purchaseorders")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PurchaseOrdersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrders([FromQuery] PurchaseOrderParameters purchaseOrderParameters)
        {
            var purchaseOrders = await _repository.PurchaseOrder.GetPurchaseOrdersAsync(purchaseOrderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(purchaseOrders.MetaData));
            return Ok(purchaseOrders);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurhcaseOrder([FromBody] PurchaseOrderWithDetailsDto purchaseOrderWithDetails)
        {
            var purchaseOrderEntity = _mapper.Map<PurchaseOrder>(purchaseOrderWithDetails.PurchaseOrder);
            var purchaseOrderDetailEntities = _mapper.Map<IEnumerable<PurchaseOrderDetail>>(purchaseOrderWithDetails.PurchaseOrderDetails);
            await _repository.PurchaseOrder.CreatePurhcaseOrder(purchaseOrderEntity, purchaseOrderDetailEntities);
            return Ok("Purchase order created successfully.");
            //  var result = _repository.PurchaseOrder.CreatePurhcaseOrder(purchaseOrderEntity, purchaseOrderDetailEntity);

        }

        [HttpPut("{purchaseOrderId}")]
        public async Task<IActionResult> UpdatePurchaseOrder(Guid purchaseOrderId, [FromBody] PurchaseOrderWithDetailsUpdateDto purchaseOrderWithDetails)
        {
            //if (purchaseOrderWithDetails == null)
            //{
            //    return BadRequest("Purchase order update data is null.");
            //}

            //var purchaseOrderEntity = await _repository.PurchaseOrder.GetPurchaseOrderAsync(purchaseOrderId, trackChanges: true);
            //if (purchaseOrderEntity == null)
            //{
            //    return NotFound($"Purchase order with ID {purchaseOrderId} not found.");
            //}

            //_mapper.Map(purchaseOrderWithDetails.PurchaseOrder, purchaseOrderEntity);

            //var purchaseOrderDetailEntities = await _repository.PurchaseOrderDetail.GetPurchaseOrderDetailsByOrderIdAsync(purchaseOrderId, trackChanges: true);
            //if (purchaseOrderDetailEntities == null)
            //{
            //    return NotFound($"Purchase order details for order ID {purchaseOrderId} not found.");
            //}

            //foreach (var detailUpdateDto in purchaseOrderWithDetails.PurchaseOrderDetails)
            //{
            //    var detailEntity = purchaseOrderDetailEntities.FirstOrDefault(d => d.PurchaseOrderDetailId == detailUpdateDto.PurchaseOrderDetailId);
            //    if (detailEntity != null)
            //    {
            //        _mapper.Map(detailUpdateDto, detailEntity);
            //    }
            //}

            //await _repository.SaveAsync();

            return NoContent();
        }

    }
}
