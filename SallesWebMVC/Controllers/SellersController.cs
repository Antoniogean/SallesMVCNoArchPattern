using Microsoft.AspNetCore.Mvc;
using SallesWebMVC.Services;

namespace SallesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;
        public SellersController(SellerService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
    }
}
