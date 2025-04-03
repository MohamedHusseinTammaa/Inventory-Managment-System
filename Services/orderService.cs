using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Inventory_Managment_System.Services
{
    public class OrderService : IOrder
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> AddOrderAsync(Order Order)
        {
            if (Order == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }
            await _unitOfWork.Repository<Order>().addAsync(Order);
            await _unitOfWork.CompleteAsync();
            return Order;
        }

        public void CalculateTotalAmount(List<Models.Classes.OrderDetails> list)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllOrders()
        {
            return await _unitOfWork.Repository<Order>().countAllAsync();
        }
        public void DeleteOrder(int id)
        {
            _unitOfWork.Repository<Order>().delete(id);
            _unitOfWork.Complete();
        }

        public async Task <IEnumerable<Order>> GetAllOrders()
        {
            var Orders = await _unitOfWork.Repository<Order>().getAllAsync();
            foreach (var o in Orders) {
                //var OrderDetails = await _unitOfWork.Repository<OrderDetails>().findAllAsync(p => p.orderId == o.Id, 1000, 0);
                //List<OrderDetails> Items = OrderDetails.ToList(); 
                var customer =  _unitOfWork.Repository<Customer>().getByID(o.CustomerId);
                o.Customer=customer;
                //o.OrderDetails = Items;
            }
            return Orders;
        }

        public Order GetOrderById(int id)
        {
            return _unitOfWork.Repository<Order>().getByID(id);
        }

        public IEnumerable<Order> getOrdersByName(string name)
        {
            return _unitOfWork.Repository<Order>().getByName(name);
        }

        public void UpdateOrder(Order Order)
        {
           _unitOfWork.Repository<Order>().update(Order,Order.Id);
        }
    }
}

