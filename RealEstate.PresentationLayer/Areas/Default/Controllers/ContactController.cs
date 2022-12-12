using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Default.Controllers
{
    [AllowAnonymous]
    [Area("Default")]
    [Route("Default/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        [Route("")]
        [Route("PartialSendMessage")]
        public IActionResult PartialSendMessage()
        {
            return PartialView();
        }


        
        [HttpPost]
        [Route("")]
        [Route("PartialSendMessage")]
        public IActionResult PartialSendMessage(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.TInsert(contact);
            return RedirectToAction("Index");
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
