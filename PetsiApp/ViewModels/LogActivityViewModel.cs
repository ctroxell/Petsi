using Microsoft.EntityFrameworkCore;
using PetsiApp.Data;
using PetsiApp.Models;
using System.Collections.Generic;

namespace PetsiApp.ViewModels
{
    public class LogActivityViewModel
    {
        public string Name { get; set; }
        public string Comments { get; set; }
        public List<CareActivity> CareActivities { get; set; }
        public string CareActivityName { get; set; }
        public int CareActivityId { get; set; }

        public LogActivityViewModel() { 
        
        }
    }
}
