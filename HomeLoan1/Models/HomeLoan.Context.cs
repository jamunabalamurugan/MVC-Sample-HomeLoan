﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Home_Loan_TestEntities : DbContext
    {
        public Home_Loan_TestEntities()
            : base("name=Home_Loan_TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Upload_Document> Upload_Document { get; set; }
        public virtual DbSet<User_Detail> User_Detail { get; set; }
        public virtual DbSet<LoanDetail> LoanDetails { get; set; }
    }
}
