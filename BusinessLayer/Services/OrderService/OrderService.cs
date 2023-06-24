using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Exceptions;
using DataLayer.Models;
using DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderService:BaseService, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        
        private async Task<AccountOrder> getOrder(int id)
        {
            var order = await _unitOfWork.AccountOrderRepository.GetOrderById(id);
            if (order == null)
            {
                throw new IdNotFoundException($"OrderId: {id} not found");
            }
            return order;
        }
        public async Task<ObjectResult> GetOrderById(int id)
        {
            var order = await getOrder(id);
            var res = _mapper.Map<OrderResponse>(order);
            return new ObjectResult(res);
        }

        public async Task<ObjectResult> GetOrders(int pageSize, int pageNumber)
        {
            var page = toPage(pageSize, pageNumber);
            var orders = await _unitOfWork.AccountOrderRepository.GetOrders(page);
            var res = orders.Select(x=> _mapper.Map<OrderResponse>(x)).ToList();
            return new ObjectResult(res);
        } 

        public async Task<ObjectResult> GetOrdersByAccountId(int accountId, int pageSize, int pageNumber)
        {
            var page = toPage(pageSize, pageNumber);
            var orders = await _unitOfWork.AccountOrderRepository.GetOrdersByAccountId(accountId, page);
            var res = orders.Select(x => _mapper.Map<OrderResponse>(x)).ToList();
            return new ObjectResult(res);
        }

        public async Task<ObjectResult> CreateOrder(OrderCreateRequest request)
        {
            var order = _mapper.Map<AccountOrder>(request);
            order.Status = "PENDING";
            _unitOfWork.AccountOrderRepository.Create(order);
            await _unitOfWork.Save();
            return new ObjectResult(order.AccountOrderId);
        }

        public async Task<ObjectResult> CompleteOrder(int id)
        {
            var order = await _unitOfWork.AccountOrderRepository.GetOrderById(id);
            order.Status = "COMPLETED";
            await _unitOfWork.Save();
            return new ObjectResult("OK");
        }
    }
}
