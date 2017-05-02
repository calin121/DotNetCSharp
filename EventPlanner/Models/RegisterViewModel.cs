using System.ComponentModel.DataAnnotations;
namespace EventPlanner.Models
{
    public class RegisterViewModel {
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The First Name needs to be at least 2 or more characters long!")]
        public string FirstName { get; set; }
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "The Last Name needs to be at least 2 or more characters long!")]
        public string LastName { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required]
        [MinLengthAttribute(8, ErrorMessage = "The Password needs to be at least 8 or more characters long!")]
        public string Password { get; set; }
        [Required]
        [CompareAttribute("Password", ErrorMessage = "Oops, the Password Confirm did not match the Password!")]
        public string PasswordConfirm { get; set; }
    }
}