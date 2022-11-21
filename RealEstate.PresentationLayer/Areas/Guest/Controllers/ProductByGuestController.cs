using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class ProductByGuestController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ProductByGuestController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Product product)
        {
            product.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            product.AppUserID = values.Id;
            _productService.TInsert(product);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> ProductListByGuest()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var productValues = _productService.TGetProductByGuest(values.Id);
            return View(productValues);
        }

        

        public IActionResult DeleteProductByGuest(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return RedirectToAction("ProductListByGuest");
        }

        [HttpGet]
        public IActionResult UpdateProductGuest(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            var values = _productService.TGetByID(id);
            return View(values);
        }
        public IActionResult UpdateProductGuest(Product p)
        {
            _productService.TUpdate(p);
            return RedirectToAction("Index");
        }


    }
}
