
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    public class ProductAjaxController : Controller
    {
        Context context = new Context();    
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ProductList()
        {
            var valuesJson = JsonConvert.SerializeObject(context.Products.ToList());
            return Json(valuesJson);
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.AppUserID = 1;
            p.CategoryID = 2;
            context.Products.Add(p);
            context.SaveChanges();
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
