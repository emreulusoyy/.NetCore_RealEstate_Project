using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.EntityLayer.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)  //İdentity kütüphanesinden alıyoruz.
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()   //Rolleri direk listeliyoruz.
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole() 
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AppRole p)
        {
            var result = await _roleManager.CreateAsync(p);  //Rol oluşturma işlemi için kullanılıyor.
            if(result.Succeeded)
            {
                return RedirectToAction("Index");   
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult UpdateRoles(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=> x.Id == id);   
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoles(AppRole p)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == p.Id);
            role.Name = p.Name; 
            var result = await _roleManager.UpdateAsync(role);    
           if (result.Succeeded)
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
