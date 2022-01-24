using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsiApp.Data;
using PetsiApp.Models;
using PetsiApp.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PetsiApp.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public PetController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddPet()
        {
            return View();
        }
    

        [HttpGet]
        public async Task<IActionResult> CreatePet(CreatePetViewModel model)
        {

            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                Pet newPet = new Pet
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Species = model.Species,
                };
                newPet.UserId = currentUser.Id;
                context.Pets.Add(newPet);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddPet");
        }
    }
}
