using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderById(id);
            return result;
        }

        [HttpGet]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> GetOrders(int pageSize, int pageNumber)
        {
            var result = await _orderService.GetOrders(pageSize, pageNumber);
            return result;
        }

        [HttpGet("account/{accountId}")]
        [Authorize]
        public async Task<IActionResult> GetOrdersByAccountId(int accountId, int pageSize, int pageNumber)
        {
            var result = await _orderService.GetOrdersByAccountId(accountId, pageSize, pageNumber);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(OrderCreateRequest request)
        {
            int accountID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _orderService.CreateOrder(request, accountID);
            return result;
        }

        [HttpPut("{id}/complete")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CompleteOrder(int id)
        {
            var result = await _orderService.CompleteOrder(id);
            return result;
        }
    }
}
