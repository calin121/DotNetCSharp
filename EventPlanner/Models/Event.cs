using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models {
    public class Event : BaseEntity{
        [KeyAttribute]
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string EventName { get; set; }
        public string Address { get; set; }
        public int UserID { get; set; }
        
        public User User { get; set; }

        public List<Invite> Attendees { get; set; }

        public Event () {
            Attendees = new List<Invite>();
        }
    }
}