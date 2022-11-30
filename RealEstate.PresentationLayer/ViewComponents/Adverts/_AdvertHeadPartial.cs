using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertHeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
