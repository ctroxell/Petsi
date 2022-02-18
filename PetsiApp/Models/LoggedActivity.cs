using System;

namespace PetsiApp.Models
{
    public class LoggedActivity
    {
        public int Id { get; set;}
        public int CareActivityId { get; set;}
        public CareActivity CareActivity { get; set;}
        //care activity name
        public string ActivityName { get; set;}
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public string Comments { get; set; }
        public DateTime LogTime { get; set; }
        public LoggedActivity()
        {
            LogTime = DateTime.Now;
        }
        
    }
}
