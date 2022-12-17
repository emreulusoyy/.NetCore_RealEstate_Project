using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.BusinessLayer.Concrete;
using RealEstate.DataAccessLayer.EntityFramework;
using RealEstate.DataAccessLayer.Migrations;
using RealEstate.EntityLayer.Concrete;

namespace RealEstate.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DasboardController : Controller
	{
		PersonalManager pm = new PersonalManager(new EfPersonalDal());	

        public  IActionResult Index()
		{
			var values = pm.TGetList();	
			return View(values);
		}
	}
}
