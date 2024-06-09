using Contracts.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Controllers.OrderTest
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private readonly IRepositoryManager _repository;

        //public OrdersController(IRepositoryManager repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet("{orderId}", Name = "GetOrder")]
        //public async Task<IActionResult> GetOrder(int orderId)
        //{
        //    // Implement retrieval of order by ID
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
        //{
        //    // Implement creation of new order
        //}

        //[HttpPut("{orderId}")]
        //public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderForUpdateDto order)
        //{
        //    // Implement updating of existing order
        //}

        //[HttpPatch("{orderId}")]
        //public async Task<IActionResult> PartiallyUpdateOrder(int orderId, [FromBody] JsonPatchDocument<OrderForUpdateDto> patchDoc)
        //{
        //    // Implement partial update of existing order
        //}

        //[HttpDelete("{orderId}")]
        //public async Task<IActionResult> DeleteOrder(int orderId)
        //{
        //    // Implement deletion of existing order
        //}
    }
}
