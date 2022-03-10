using System.Collections.Generic;

namespace PetsiApp.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public int PetXp {get; set; }
        public int Icon { get; set; }
        public int Achievements { get; set; }
        
    }
}
