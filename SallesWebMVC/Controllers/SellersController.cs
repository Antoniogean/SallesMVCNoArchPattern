using Microsoft.AspNetCore.Mvc;

namespace SallesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
