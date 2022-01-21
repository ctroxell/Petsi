using System.ComponentModel.DataAnnotations;

namespace PetsiApp.ViewModels
{
    public class AddChildViewModel
    {

        [Required]
        public string ChildEmail { get; set; }
    }
}
