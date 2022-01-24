using Microsoft.AspNetCore.Identity;
using PetsiApp.Data;

namespace PetsiApp.Models
{
    public class Parent : ApplicationUser
    {
        public string ChildUserId { get; set; }
        public ApplicationUser ChildUser { get; set; }
    }
}
