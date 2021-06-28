using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLoan1.Models
{
    public class AllUsers
    {

        //public int Application_ID { get; set;}
        //public string User_Password { get; set; }
        //public string First_Name { get; set; }
        //public string Middle_Name { get; set; }
        //public string Last_Name { get; set; }
        //public string Email { get; set; }
        //public string Phone_Number { get; set; }
        //public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        //public string Gender { get; set; }
        //public string Aadhar_Number { get; set; }
        //public string Pan_Number { get; set; }
        //public string Type_Of_Employment { get; set; }
        //public string Organization_Type { get; set; }
        //public string Organization_Name { get; set; }
        //public Nullable<double> Salary { get; set; }
        //public Nullable<int> Retirement_Age { get; set; }
        //[Display(Name ="Loan Amount")]
        //public Nullable<double> Amount { get; set; }
        //public Nullable<double> Interest { get; set; }
        //public Nullable<double> Tenure { get; set; }
        //public string Loan_Account_Number { get; set; }
        //public Nullable<double> Balance { get; set; }
        //public string Plot_Number { get; set; }
        //public string Property_Area { get; set; }
        //public string Pincode { get; set; }
        //public string Type_Of_Property { get; set; }
        //public Nullable<double> Estimated_Cost { get; set; }
        //public string Pan_Card { get; set; }
        //public string Aadhar_Card { get; set; }
        //public string Salary_Slip { get; set; }
        //public string LOA { get; set; }
        //public string NOC { get; set; }
        //public string Agreement { get; set; }
        //public string Verification_Status { get; set; }


        [Key]
        [Display(Name = "Application Id")]
        public int Application_ID { get; set; }
        public string User_Password { get; set; }
        [Display(Name = "First name")]
        public string First_Name { get; set; }
        [Display(Name = "Middle name")]
        public string Middle_Name { get; set; }
        [Display(Name = "Last name")]
        public string Last_Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string Phone_Number { get; set; }
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Aadhar Number")]
        public string Aadhar_Number { get; set; }
        [Display(Name = "PAN Number")]
        public string Pan_Number { get; set; }
        [Display(Name = "Type of Employment")]

        public string Type_Of_Employment { get; set; }
        [Display(Name = "Organization Type")]

        public string Organization_Type { get; set; }
        [Display(Name = "Organization Name")]

        public string Organization_Name { get; set; }
        [Display(Name = "Salary")]

        public Nullable<double> Salary { get; set; }
        [Display(Name = "Retirement Age")]

        public Nullable<int> Retirement_Age { get; set; }
        [Display(Name = "Amount")]
        public Nullable<double> Amount { get; set; }
        [Display(Name = "Interest")]
        public Nullable<double> Interest { get; set; }
        //[Display(Name = "Loan Amount")]

        //public Nullable<double> Interest { get; set; }
        [Display(Name = "Tenure")]
        public Nullable<double> Tenure { get; set; }
        [Display(Name = "Loan Account Number")]
        public string Loan_Account_Number { get; set; }
        [Display(Name = "Balance")]

        public Nullable<double> Balance { get; set; }
        [Display(Name = "Plot Number")]

        public string Plot_Number { get; set; }
        [Display(Name = "Property Area")]

        public string Property_Area { get; set; }
        [Display(Name = "Pincode")]

        public string Pincode { get; set; }
        [Display(Name = "Type of Property")]

        public string Type_Of_Property { get; set; }
        [Display(Name = "Estimated Cost")]


        public Nullable<double> Estimated_Cost { get; set; }
        [Display(Name = "Pan Card")]

        public string Pan_Card { get; set; }
        [Display(Name = "Aadhar Card")]

        public string Aadhar_Card { get; set; }
        [Display(Name = "Salary Slip")]

        public string Salary_Slip { get; set; }
        [Display(Name = "LOA")]

        public string LOA { get; set; }
        [Display(Name = "NOC")]

        public string NOC { get; set; }
        [Display(Name = "Agreement")]

        public string Agreement { get; set; }
        [Display(Name = "Verification Status")]

        public string Verification_Status { get; set; }

    }
}