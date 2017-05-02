using System;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models {
    public class User {
        [KeyAttribute]
        public int id { get; set; }
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The First Name needs to be at least 2 or more characters long!")]
        public string name { get; set; }
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The Last Name needs to be at least 2 or more characters long!")]
        public string description { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string email { get; set; }
        [Required]
        [MinLengthAttribute(8, ErrorMessage = "The Password needs to be at least 8 or more characters long!")]
        public string password { get; set; }
        [Required]
        [CompareAttribute("password", ErrorMessage = "Oops, the Password Confirm did not match the Password!")]
        public string password_confirm { get; set; }
        public string image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User()
        {
            image = "";
            created_at = DateTime.Now;
            updated_at = DateTime.Now; 
        }
    }
}