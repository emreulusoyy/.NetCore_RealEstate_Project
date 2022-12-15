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
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["userid"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleID = role.Id;
                m.Name = role.Name;
                m.Exists = userRoles.Contains(role.Name);
                models.Add(m); ///Değerleri oku ve ekle
            }
            return View(models);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(AppUser p)
        {
            var result = _userManager.Users.FirstOrDefault(x => x.Id == p.Id);
            result.Name = p.Name;
            result.Surname = p.Surname;
            result.UserName = p.UserName;
            result.Gender = p.Gender;

            var values = await _userManager.UpdateAsync(result);
            if (values.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }





        }
    }
}
