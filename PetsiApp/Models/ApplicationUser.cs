using Microsoft.AspNetCore.Identity;

namespace PetsiApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string RoleId { get; set; }
        public int PetId { get; set; }
        public ApplicationUser()
        {

        }
    }
}
