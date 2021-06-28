using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLoan1.Models
{
    public class StatusView
    {
        [Key]
        [Display(Name = "Application ID")]
        public int Application_ID { get; set; }
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Surname")]
        public string Last_Name { get; set; }
        [Display(Name = "Loan Account Number")]
        public string Loan_Account_Number { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<double> Tenure { get; set; }
        public Nullable<double> Interest { get; set; }
        [Display(Name ="Verification Status")]
        public string Verification_Status { get; set; }
        [Display(Name = "Loan Status")]
        public string Loan_Status { get; set; }
        [Display(Name ="Date Of Birth")]
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        [Display(Name ="Mobile Number")]
        public string Phone_Number { get; set; }

    }
}