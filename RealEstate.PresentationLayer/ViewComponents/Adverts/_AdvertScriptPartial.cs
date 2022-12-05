using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
