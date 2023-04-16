using System.ComponentModel.DataAnnotations;

namespace WorkoutWarriors.View_Model
{
    public class RegisterViewModel
    {

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Do Not Match")]
        public string ConfirmPassword { get; set; } 



    }
}
