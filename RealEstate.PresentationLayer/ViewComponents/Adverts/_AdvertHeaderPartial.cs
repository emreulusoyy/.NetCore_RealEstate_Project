using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
