
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    public class ProductAjaxController : Controller
    {
        
        private readonly IProductService _productService;

        public ProductAjaxController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ProductList()
        {
            var valuesJson = JsonConvert.SerializeObject(_productService.TGetList());
            return Json(valuesJson);
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.AppUserID = 1;
            p.CategoryID = 2;
            _productService.TInsert(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetByID(int ProductID)
        {
            var values = _productService.TGetByID(ProductID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json( jsonValues);
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult UpdateProduct(Product p)
        {
            var values = _productService.TGetByID(p.ProductID);
            values.Title = p.Title;
            values.Price = p.Price;
            _productService.TUpdate(values);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
    }
}
