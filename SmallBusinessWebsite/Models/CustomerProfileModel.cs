using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SmallBusinessWebsite.Models
{
    public class CustomerProfileModel
    {
        public int CustomerId;

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "First Name can be 50 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50, ErrorMessage = "Last Name can be 50 character")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [Range(10000, 9999999, ErrorMessage = "Zipcode is minimum 5 digits and maximum 7 digits")]
        [MaxLength(9, ErrorMessage = "ZipCode Maximum is 9 Characters")]
        public string Zipcode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public int UserCredentialsID { get; internal set; }
    }
}