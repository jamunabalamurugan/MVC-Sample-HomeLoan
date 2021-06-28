using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeLoan1.Models
{
    public class UDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Application_ID { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "Please Enter Your First_Name")]
        public string First_Name { get; set; }

        [Display(Name = "Middle Name")]
        public string Middle_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last_Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Please Enter your Email ID")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string User_Password { get; set; }

        [NotMapped]
        [Compare("User_Password", ErrorMessage = "Password mismatch")]
        [Display(Name = "Confirm Password")]
        public string Confirm_Password { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string Phone_Number { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please Enter your Date Of Birth")]
        [DataType(DataType.Date)]
        public string Date_Of_Birth { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select your gender")]
        public string Gender { get; set; }
        [Display(Name = "Aadhar Number")]
        [Required(ErrorMessage = "Please Enter your Aadhar Number")]
        [Range(100000000000, 999999999999, ErrorMessage = "Enter Correct Aadhar number")]
        public string Aadhar_Number { get; set; }
        [Display(Name = "PAN Card Number")]
        [Required(ErrorMessage = "Please Enter your Pan Number")]
        [RegularExpression("^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$", ErrorMessage = "Enter correct PAN number")]
        public string Pan_Number { get; set; }
    }
}