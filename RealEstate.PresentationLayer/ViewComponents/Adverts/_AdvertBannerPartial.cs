using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertBannerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
