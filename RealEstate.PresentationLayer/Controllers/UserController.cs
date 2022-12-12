using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.Concrete;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using RealEstate.PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }



        public async Task<IActionResult> DeleteUser(int id)
        {
            var role = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var result = await _userManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);    
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id) //Rol ataması
        {
            var user = _userManager.Users.FirstOrDefault(x=>x.Id== id); 
            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();  
                m.RoleID = role.Id; 
                m.Name= role.Name;
                m.Exists = userRoles.Contains(role.Name);
                models.Add(m); ///Değerleri oku ve ekle
            }
            return View(models);

        }





    }
}
