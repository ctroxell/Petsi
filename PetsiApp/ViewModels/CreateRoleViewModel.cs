using System.ComponentModel.DataAnnotations;

namespace PetsiApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
