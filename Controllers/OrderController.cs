using Microsoft.AspNetCore.Mvc;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Services;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.UnitOfWork;

namespace Inventory_Managment_System.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrder _Order;
        private readonly IProduct _Product;
        private readonly ICustomer _Customer;
        private readonly IOrderDetails _orderDetails;
        public OrderController(IOrder Order, IProduct product, ICustomer customer, IOrderDetails orderDetails)
        {
            _Order = Order;
            _Customer = customer;
            _Product = product;
            _orderDetails = orderDetails;
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var Orders = _Order.GetAllOrders();
            var list=Orders.Result.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var model = new Order
            {
                OrderDate = DateTime.Now,
                OrderDetails = new List<OrderDetails>()
            };
            ViewData["Products"] =  _Product.getAllProducts().Result;
            ViewData["Customers"] =  _Customer.GetAllCustomers().Result;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order Order)
        {
            
            if (Order.OrderDate>DateTime.Today && Order.CustomerId != 0)
            {
                bool orderAdd = false;
                Order.CalculateTotalAmount();
                List<OrderDetails> orderDetails = Order.OrderDetails;
                foreach (OrderDetails item in orderDetails)
                {
                    if (item.ProductId == 0 || item.Quantity <= 0 || item.Price <= 0)
                    {
                        return RedirectToAction("CreateOrder");
                    }
                    item.CalculateFinalPrice();
                    if (!orderAdd)
                    {
                        _Order.AddOrderAsync(Order);
                        orderAdd = true;
                    }
                    item.orderId = Order.Id;
                    _orderDetails.AddOrderDetailsAsync(item);
                }
            }
            else
            {
                return Content("shit!");
            }
            
            return RedirectToAction("GetAllOrders");
            
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var Order = _Order.GetOrderById(id);
            return View(Order);
        }

        [HttpPost]
        public IActionResult EditOrder(Order Order)
        {
            if (ModelState.IsValid)
            {
                _Order.UpdateOrder(Order);
                return RedirectToAction("GetAllOrders");
            }
            return View(Order);
        }

        public IActionResult DeleteOrder(int id)
        {
            _Order.DeleteOrder(id);
            return RedirectToAction("GetAllOrders");
        }
    }
}
