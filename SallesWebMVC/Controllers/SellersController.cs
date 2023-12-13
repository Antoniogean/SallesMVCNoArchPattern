using Microsoft.AspNetCore.Mvc;
using SallesWebMVC.Models;
using SallesWebMVC.Models.ViewModels;
using SallesWebMVC.Services;
using SallesWebMVC.Services.Exceptions;

namespace SallesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService service, DepartmentService departmentService)
        {
            _sellerService = service;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.InsertSeller(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.DeleteSeller(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);

            if(seller == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel sellerFormViewModel = new SellerFormViewModel { Departments = departments, Seller = seller };

            return View(sellerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if( id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
            _sellerService.UpdateSeller(seller);
            return RedirectToAction(nameof(Index)); 

            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcunrrencyExpcetion)
            {
                return BadRequest();
            }
        }
    }
}
