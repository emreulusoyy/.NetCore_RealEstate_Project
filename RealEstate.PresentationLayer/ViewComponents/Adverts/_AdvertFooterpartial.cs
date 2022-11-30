using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertFooterpartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
