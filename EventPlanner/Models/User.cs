using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models {
    public class User : BaseEntity{
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Invite> Attendees { get; set; }

        public List<Event> Events { get; set; }
        
        public User () {
            Events = new List<Event>();
            Attendees = new List<Invite>();
        }
    }
}