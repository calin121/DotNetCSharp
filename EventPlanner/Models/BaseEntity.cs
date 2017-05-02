using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models {
    public class BaseEntity{
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}