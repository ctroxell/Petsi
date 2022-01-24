using Microsoft.AspNetCore.Identity;

namespace PetsiApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PetId { get; set; }
        public string RoleId { get; set; }

        public ApplicationUser()
        {

        }
    }
}
