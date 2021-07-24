using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessWebsite.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}