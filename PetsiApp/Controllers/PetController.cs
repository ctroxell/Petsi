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

                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        Pet newPet = new Pet
                        {
                            Name = model.Name,
                            Gender = model.Gender,
                            Species = model.Species,
                            UserId = model.UserId
                        };
                        var userIdValue = userIdClaim.Value;
                        newPet.UserId = userIdValue;
                        context.Pets.Add(newPet);
                        context.SaveChanges();
                        return View("Index");
                    }
                }
            }
            return View("AddPet");
        }
    }
}
