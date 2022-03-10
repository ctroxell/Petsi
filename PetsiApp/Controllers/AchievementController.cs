using Microsoft.AspNetCore.Mvc;
using PetsiApp.Models;
using PetsiApp.ViewModels;

namespace PetsiApp.Controllers
{
    public class Achievement : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Check(PetIndexViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //earn achi 3
        //        if(model.UserPet.PetXp >= 100 && model.UserPet.Achievements < 3)
        //        {
        //            model.UserPet.Achievements = 3;
        //            return View("ThirdAchi");
                    
        //        }

        //        //earn achi 2
        //        if(model.UserPet.PetXp >= 50 && model.UserPet.Achievements < 2)
        //        {
        //            model.UserPet.Achievements = 2;
        //            return View("SecondAchi");
        //        }

        //        //earn achi 1
        //        if (model.LoggedActivities.Count == 1)
        //        {
        //            model.UserPet.Achievements = 1;
        //            return View("FirstAchi");
        //        }

        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Pet");
        //    }

        //    return RedirectToAction("Index", "Pet");
        //}

        public IActionResult FirstAchi()
        {
            return View();
        }

        public IActionResult SecondAchi()
        {
            return View();
        }

        public IActionResult ThirdAchi()
        {
            return View();
        }
    }
}
