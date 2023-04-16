using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WorkoutWarriors.View_Model
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        

    }
}
