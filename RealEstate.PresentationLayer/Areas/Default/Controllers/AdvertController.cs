using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.PresentationLayer.Areas.Default.Controllers
{
    public class AdvertController : Controller
    {
        [Area("Default")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
