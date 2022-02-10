using PetsiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetsiApp.ViewModels
{
    public class PetIndexViewModel
    {
        public Pet UserPet { get; set; }
        public List<LoggedActivity> LoggedActivities { get; set; }
    }
}
