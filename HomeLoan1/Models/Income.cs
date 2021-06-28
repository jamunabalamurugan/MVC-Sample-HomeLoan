//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeLoan1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Income
    {
        public int Income_ID { get; set; }
        [Required(ErrorMessage = "Select any one of the options")]
        [Display(Name = "Employment Type")]
        public string Type_Of_Employment { get; set; }
        [Required(ErrorMessage = "Select any one of the options")]
        [Display(Name = "Type of Organization")]
        public string Organization_Type { get; set; }
        [Required(ErrorMessage = "Enter Organization name")]
        [Display(Name = "Name of your Organization")]
        public string Organization_Name { get; set; }
        [Required(ErrorMessage = "Enter your Salary")]
        public Nullable<double> Salary { get; set; }
        [Required(ErrorMessage = "Enter retirement age")]
        [Display(Name = "Retirement Age")]
        public Nullable<int> Retirement_Age { get; set; }

        public Nullable<int> Application_ID { get; set; }
    
        public virtual User_Detail User_Detail { get; set; }
    }
}