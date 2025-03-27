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
    public class orderService : Iorder
    {
        private readonly IUnitOfWork _unitOfWork;

        public orderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<order> AddOrderAsync(order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _unitOfWork.Repository<order>().add(order);
            await _unitOfWork.CompleteAsync();
            return order;
        }

        public void CalculateTotalAmount(List<Models.Classes.orderDetails> list)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllOrders()
        {
            return await _unitOfWork.Repository<order>().countAllAsync();
        }
        public void DeleteOrder(int id)
        {
            _unitOfWork.Repository<order>().delete(id);
            _unitOfWork.Complete();
        }

        public async Task <IEnumerable<order>> GetAllOrders()
        {
            var orders = await _unitOfWork.Repository<order>().getAllAsync();
            return orders;
        }

        public order GetOrderById(int id)
        {
            return _unitOfWork.Repository<order>().getByID(id);
        }

        public IEnumerable<order> getOrdersByName(string name)
        {
            return _unitOfWork.Repository<order>().getByName(name);
        }

        public void UpdateOrder(order order)
        {
           _unitOfWork.Repository<order>().update(order,order.Id);
        }
    }
}

