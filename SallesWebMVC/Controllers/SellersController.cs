using Microsoft.AspNetCore.Mvc;
using SallesWebMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _service.InsertSeller(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
