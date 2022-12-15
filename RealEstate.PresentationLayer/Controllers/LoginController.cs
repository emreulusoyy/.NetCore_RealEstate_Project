using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.EntityLayer.Concrete;
using RealEstate.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result =await _signInManager.PasswordSignInAsync(p.username, p.password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }
    }
}
