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
    [Authorize] //user must be logged in to access this page
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
            //if the user has a pet, this^ info will be sent to the dashboard
            if (model.UserPet != null)
            {
                return View("Index", model);
            }
            //if the user does NOT have a pet, they have to make one
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
                    PetXp = 0,
                };
                //adding the new pet into the database
                context.Pets.Add(newPet);
                context.SaveChanges();
                //assigning that pet to the user
                currentUser.PetId = newPet.Id;
                context.SaveChanges();
                PetIndexViewModel indexModel = new PetIndexViewModel
                {
                    UserPet = newPet,
                    LoggedActivities = new List<LoggedActivity>(),
                };
                return View("Index", indexModel);
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
                CareActivity = careActivity,
                ActivityName = careActivity.Name,
                Comments = model.Comments,
                Pet = userPet,
            };
            context.Pets.Find(currentUser.PetId).PetXp += careActivity.XpValue;
            //updating the pet's XP accordingly
            context.LoggedActivities.Add(newActivity);
            //adding the activity log to the database
            context.SaveChanges();

            return Redirect("Index");
        }

        public async Task<IActionResult> Logs()
        {
            var currentUser = await GetCurrentUserAsync();
            var userPet = context.Pets.Where(pet => pet.Id == currentUser.PetId);
            var petLoggedActivities = context.LoggedActivities.Where(activity => activity.PetId == currentUser.PetId).ToList();
            //retrieving a list of activity logs assigned to the current user and sending it to the view
            return View("Logs", petLoggedActivities);
        }

    }
}
