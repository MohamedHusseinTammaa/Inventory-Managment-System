using Microsoft.AspNetCore.Mvc;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Services;
using Inventory_Managment_System.Interfaces;

namespace Inventory_Managment_System.Controllers
{
    public class OrderController : Controller
    {

        private readonly Iorder _order;
        public OrderController(Iorder order)
        {
            _order = order;
        }

        public IActionResult GetAllOrders()
        {
            var orders = _order.GetAllOrders();
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(order order)
        {
            if (ModelState.IsValid)
            {
                _order.AddOrder(order);
                return RedirectToAction("GetAllOrders");
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var order = _order.GetOrderById(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrder(order order)
        {
            if (ModelState.IsValid)
            {
                _order.UpdateOrder(order);
                return RedirectToAction("GetAllOrders");
            }
            return View(order);
        }

        public IActionResult DeleteOrder(int id)
        {
            _order.DeleteOrder(id);
            return RedirectToAction("GetAllOrders");
        }
    }
}
