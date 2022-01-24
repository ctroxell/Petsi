using Microsoft.AspNetCore.Identity;
using PetsiApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PetsiApp.ViewModels
{
    public class CreatePetViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string UserId { get; set; }

    }
}
