using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
