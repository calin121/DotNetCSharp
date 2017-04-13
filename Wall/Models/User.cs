using System.ComponentModel.DataAnnotations;

namespace LogReg.Models {
    public class User {
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The First Name needs to be at least 2 or more characters long!")]
        public string first_name { get; set; }
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The Last Name needs to be at least 2 or more characters long!")]
        public string last_name { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string email { get; set; }
        [Required]
        [MinLengthAttribute(8, ErrorMessage = "The Password needs to be at least 8 or more characters long!")]
        public string password { get; set; }
        [Required]
        [CompareAttribute("password", ErrorMessage = "Oops, the Password Confirm did not match the Password!")]
        public string password_confirm { get; set; }

    }
}