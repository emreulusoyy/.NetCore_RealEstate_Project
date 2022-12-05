using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;

namespace RealEstate.PresentationLayer.Areas.Default.Controllers
{
    [AllowAnonymous]
    [Area("Default")]
    public class ContactController : Controller
    {
       private readonly IContactService _contactService;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialSendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialSendMessage(Contact contact)
        {
            contact.ContactDate
            return PartialView();
        }

        public PartialViewResult PartialAddressDetails()
        {
            return PartialView();
        }

        public PartialViewResult PartialMapDetails()
        {
            return PartialView();
        }
    }
}
