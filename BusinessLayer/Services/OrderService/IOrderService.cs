using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IOrderService
    {
        Task<ObjectResult> GetOrderById(int id);
        Task<ObjectResult> GetOrders(int pageSize, int pageNumber);
        Task<ObjectResult> GetOrdersByAccountId(int accountId, int pageSize, int pageNumber);
        Task<ObjectResult> CreateOrder(OrderCreateRequest request, int accountId);
        Task<ObjectResult> CompleteOrder(int id);
    }
}
