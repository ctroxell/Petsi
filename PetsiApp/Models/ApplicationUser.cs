using Microsoft.AspNetCore.Identity;

namespace PetsiApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int PetId { get; set; }
        public int RoleId { get; set; }
        public string Descriminator { get; set; }

        public ApplicationUser()
        {
            
        }
    }
}
