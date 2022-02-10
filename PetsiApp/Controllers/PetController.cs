using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsiApp.Data;
using PetsiApp.Models;
using PetsiApp.ViewModels;
using System;
using System.Collections.Generic;
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
        public DbSet<CareActivity> CareActivities;

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public PetController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.context = context;

        }

        //consider making view model
        //consider setting care activity name in logged activity
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            Pet userPet = context.Pets.Find(currentUser.PetId);
            var petLoggedActivities = context.LoggedActivities.Where(activity => activity.PetId == currentUser.PetId).ToList();
            PetIndexViewModel model = new PetIndexViewModel
            {
                UserPet = userPet,
                LoggedActivities = petLoggedActivities
            };
            if (model.UserPet != null)
            {
                return View("Index", model);
            }
            return View("AddPet");
        }

        public IActionResult AddPet()
        {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> CreatePet(CreatePetViewModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUserAsync();
                Pet newPet = new Pet
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Species = model.Species,
                    User = currentUser,
                    UserId = currentUser.Id,
                    Icon = model.IconSelection,
                };
                context.Pets.Add(newPet);
                context.SaveChanges();
                currentUser.PetId = newPet.Id;
                context.SaveChanges();
                return View("Index");
            }
            return View("AddPet");
        }

        [HttpGet]
        public IActionResult LogActivity()
        {
            LogActivityViewModel logActivityViewModel = new LogActivityViewModel
            {
                CareActivities = context.CareActivities.ToList()
            };
            return View(logActivityViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogActivity(LogActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("LogActivity");
            }
            var currentUser = await GetCurrentUserAsync();
            Pet userPet = context.Pets.Find(currentUser.PetId);
            CareActivity careActivity = context.CareActivities.Find(model.CareActivityId);
            LoggedActivity newActivity = new LoggedActivity
            {
                //set CA name
                CareActivity = careActivity,
                ActivityName = careActivity.Name,
                Comments = model.Comments,
                Pet = userPet,
            };
            userPet.PetXp = userPet.PetXp + careActivity.XpValue;
            context.LoggedActivities.Add(newActivity);
            context.SaveChanges();

            return Redirect("Index");
        }

        public async Task<IActionResult> Logs()
        {
            var currentUser = await GetCurrentUserAsync();
            var userPet = context.Pets.Where(pet => pet.Id == currentUser.PetId);
            var petLoggedActivities = context.LoggedActivities.Where(activity => activity.PetId == currentUser.PetId).ToList();
            return View("Logs", petLoggedActivities);
        }

    }
}
