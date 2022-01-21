using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PetsiApp.Controllers
{
    public class AdministrationController : Controller
    {
        private  RoleManager<IdentityRole> roleManager;
        public AdministrationController(RoleManager<IdentityRole> manager)
        {
            this.roleManager = manager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
    }
}
