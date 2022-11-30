using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertListPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _AdvertListPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetProductByCategory();
            return View(values);
        }
    }
}
