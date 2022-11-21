using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using RealEstate.PresentationLayer.Areas.Guest.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Guest.Controllers
{
    [Area("Guest")] //Area olduğunu bildiriyoruz.
    public class GuestProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public GuestProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index() //ilgili yapıyı asekton olarak tanımladık.
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);  //Await asekron ifadelerde önce 20. satırdaki ifadeyi yap diyor.
            UserEditViewModel userEdit = new UserEditViewModel();
            userEdit.Name = values.Name;    
            userEdit.SurName = values.Surname;    
            userEdit.PhoneNumber = values.PhoneNumber;    
            userEdit.Mail = values.Email;    
            userEdit.Gender = values.Gender;    
            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);  //Await asekron ifadelerde önce 20. satırdaki ifadeyi yap diyor.
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); 
                var extension =Path.GetExtension(p.Image.FileName); //uzantı .jpg vs
                var imageName = Guid.NewGuid()+ extension;  //restgele resim ismi
                var saveLocation = resource + "/wwwroot/Image/"+ imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                values.ImageUrl = imageName;
            }
            values.Name = p.Name;
            values.Surname = p.SurName;
            values.PhoneNumber = p.PhoneNumber;
            values.Email = p.Mail;
            values.Gender = p.Gender;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result = await _userManager.UpdateAsync(values);

            return View();
        }

        public IActionResult ProductListByGuest()
        {
            return View();
        }

      

    }
}
