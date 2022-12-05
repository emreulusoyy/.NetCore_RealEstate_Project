using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using X.PagedList;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertListPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _AdvertListPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int page=1)
        {
           
            var values = _productService.TGetProductByCategory().ToPagedList(page , 6);
            return View(values);
        }
    }
}
