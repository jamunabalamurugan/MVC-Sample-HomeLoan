using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeLoan1.Models
{
    public class UsersAll
    {
        
        public User_Detail Users { get; set;}
        public Property Props { get; set; }
        public Income Incs { get; set; }
        public LoanDetail Loans { get; set; }
        public Upload_Document Ups { get; set; }
        public Status Sts { get; set; }
    }
}