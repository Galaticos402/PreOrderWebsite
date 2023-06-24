using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderById(id);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int pageSize, int pageNumber)
        {
            var result = await _orderService.GetOrders(pageSize, pageNumber);
            return result;
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetOrdersByAccountId(int accountId, int pageSize, int pageNumber)
        {
            var result = await _orderService.GetOrdersByAccountId(accountId, pageSize, pageNumber);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateRequest request)
        {
            var result = await _orderService.CreateOrder(request);
            return result;
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteOrder(int id)
        {
            var result = await _orderService.CompleteOrder(id);
            return result;
        }
    }
}
