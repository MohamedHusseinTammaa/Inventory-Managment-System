using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
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
        private readonly InventoryDbContext _context;

        public orderService(InventoryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<order> GetAllOrders()
        {
       
            return _context.orders
                .Include(o => o.Customer)
                .Include(o => o.orderDetails)
                .ThenInclude(od => od.Product)
                .ToList();
        }

        public order GetOrderById(int id)
        {
            return _context.orders
                .Include(o => o.Customer)
                .Include(o => o.orderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public void AddOrder(order order)
        {
            CalculateTotalAmount(order.orderDetails.ToList());
            _context.orders.Add(order);
            _context.SaveChanges();
        }

        private void CalculateTotalAmount(List<Models.Classes.orderDetails> orderDetails)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(order order)
        {
            _context.orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.orders.Find(id);
            if (order != null)
            {
                _context.orders.Remove(order);
                _context.SaveChanges();
            }
        }

        void Iorder.CalculateTotalAmount(List<Models.Classes.orderDetails> list)
        {
            decimal TotalAmount = 0;
            foreach (var detail in list)
            {
                TotalAmount += detail.FinalPrice;
            }
        }
    }
}

