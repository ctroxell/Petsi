using Microsoft.AspNetCore.Identity;
using PetsiApp.Data;

namespace PetsiApp.Models
{
    public class Parent : IdentityUser
    {
        public string ChildUserId { get; set; }
        public IdentityUser ChildUser { get; set; }
    }
}
