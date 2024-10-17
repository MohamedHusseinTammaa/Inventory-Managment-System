using Inventory_Managment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement your authentication logic here
                // For example, check the user's credentials against your database
                // If valid, sign in the user and redirect to a secured page
                // If invalid, add a ModelState error and return the view
            }
            return View(model);
        }
    }
}
