using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HomeLoan1.Models;

namespace HomeLoan1.Controllers
{
    [HandleError]
    public class UserController : Controller
    {

        Home_Loan_TestEntities db = new Home_Loan_TestEntities();
        
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        /// <summary>
        /// Empty View to Clear Session Variables. Called on Signout/Logout.
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserHome", "User");
        }
        /// <summary>
        /// Login Form for the User once their Application is Submitted
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(Login u)
        {
            
            var email = u.Email;
            var password = u.Password;
            var res = (from i in db.User_Detail
                       where i.Email == email &&
                       i.User_Password == password
                       select i).SingleOrDefault();
            if (res != null)
            {
                
                var ApplicationID = res.Application_ID;
                Session["Application_ID"] = ApplicationID;
                Session["FName"] = res.First_Name;
                Session["Email"] = res.Email;
                return RedirectToAction("/LoggedInHome");
            }
            else
            {
                ViewBag.message = "Incorrect credentials";
                return View();
            }
        }
        /// <summary>
        /// Page displayed after the User is Logged In using the Email and Password.
        /// Here, The user can track his Loan Status and View his Sanctioned Loan amount.
        /// </summary>
        /// <returns></returns>
        public ActionResult LoggedInHome()
        {
            return View();
        }
        /// <summary>
        /// The respective user can View his Loan details.
        /// </summary>
        public ActionResult ViewStatus(StatusView l)
        {
            var x = (from i in db.LoanDetails
                     join j in db.Status on i.Application_ID equals j.Application_ID
                     join k in db.User_Detail on i.Application_ID equals k.Application_ID
                     where k.Email==l.Email
                     select new StatusView { Application_ID=k.Application_ID, First_Name = k.First_Name, Last_Name = k.Last_Name, Loan_Account_Number = i.Loan_Account_Number, Balance=i.Balance,Tenure=i.Tenure,Interest=i.Interest, Verification_Status = j.Verification_Status, Loan_Status = j.Loan_Status,Email=k.Email }).SingleOrDefault();
            return View(x);
        }
       /// <summary>
       /// Home Page of the Web Application.
       /// Contains a JavaScript Calculator for Calculating EMI and Eligible Loan Amount
       /// </summary>
        public ActionResult UserHome()
        {
            return View();
        }
        /// <summary>
        /// Form to Submit Basic Information of the User such as Name, Email, Phone Number, etc
        /// </summary>
        /// <returns></returns>
        public ActionResult UserDetails()
        {
            if(Session["Application_ID"]!=null)
            {
                Session["MultipleApplications"] = "You can Apply only once for your Loan!";
                return RedirectToAction("UserLogin", "User");
            }
            else
            {
                return View();

            }
       }

        [HttpPost]
        public ActionResult UserDetails(User_Detail ud)
        {
            
            db.User_Detail.Add(ud);
            db.SaveChanges();
            var user = db.User_Detail.Where(x => x.Email == ud.Email).FirstOrDefault();
            var ApplicationID = ud.Application_ID;
            Session["Application_ID"] = ApplicationID;
            Session["FName"] = ud.First_Name;
            return RedirectToAction("IncomeDetails");

        }
        
        /// <summary>
        /// Form to Submit the Applicant's Job Details
        /// </summary>
        /// <returns></returns>
        public ActionResult IncomeDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncomeDetails(Income inc)
        {
            Income income = new Income();
            income.Application_ID = Convert.ToInt32(Session["Application_ID"]);
            income.Organization_Name = inc.Organization_Name;
            income.Organization_Type = inc.Organization_Type;
            income.Retirement_Age = inc.Retirement_Age;
            income.Salary = inc.Salary;
            income.Type_Of_Employment = inc.Type_Of_Employment;
            db.Incomes.Add(income);
            db.SaveChanges();
            return RedirectToAction("PropertyDetails");

        }
        /// <summary>
        /// Form to Submit the Property Details where the Applicant wants to Build a Home or Purchase a Home.
        /// </summary>
        /// <returns></returns>
        public ActionResult PropertyDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PropertyDetails(Property p)
        {
            if(ModelState.IsValid)
            {
                Property prop = new Property();
                prop.Application_ID = Convert.ToInt32(Session["Application_ID"]);
                prop.Estimated_Cost = p.Estimated_Cost;
                prop.Pincode = p.Pincode;
                prop.Plot_Number = p.Plot_Number;
                prop.Property_Area = p.Property_Area;
                prop.Type_Of_Property = p.Type_Of_Property;
                db.Properties.Add(prop);
                db.SaveChanges();
                return RedirectToAction("LoanDetails");
            }
            else
            {
                return View();
            }
            
           
            

        }
        /// <summary>
        /// Form to Submit the Required Loan Amount and the Time the Applicant needs to repay.
        /// </summary>
        /// <returns></returns>
        public ActionResult LoanDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoanDetails(LoanDetail l)
        {

            LoanDetail loan = new LoanDetail();
            if (ModelState.IsValid)
            {
                loan.Application_ID = Convert.ToInt32(Session["Application_ID"]);
                loan.Amount = l.Amount;
                loan.Interest = 8.5;
                loan.Tenure = l.Tenure;

                db.LoanDetails.Add(loan);
                db.SaveChanges();
                

                return RedirectToAction("UploadDocuments");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// Form to Upload the necessary documents which will be verified by the Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UploadDocuments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadDocuments(Upload_Document updoc ,HttpPostedFileBase PanFile, HttpPostedFileBase AadharFile, HttpPostedFileBase SalaryFile, HttpPostedFileBase LOAFile, HttpPostedFileBase NOCFile, HttpPostedFileBase AgreementFile)
        {
            
            
            updoc.Application_ID = Convert.ToInt32(Session["Application_ID"]);

            string Panfilename = Path.GetFileNameWithoutExtension(PanFile.FileName);
            string extension = Path.GetExtension(PanFile.FileName);

            if (extension != ".jpg" )
            {
                ViewBag.UploadStatus = "Ensure that uploaded document is in .jpg format .";
                return View();
            }
            else
            {
                Panfilename = Panfilename + extension;
                updoc.Pan_Card = "~/Files/" + Panfilename;
                Panfilename = Path.Combine(Server.MapPath("~/Files/"), Panfilename);
                PanFile.SaveAs(Panfilename);
                TempData["Status"] = "Uploaded Successfully";
                ViewBag.UploadStatus = " files uploaded successfully.";


            }

            string aadhar = Path.GetFileNameWithoutExtension(AadharFile.FileName);
            string aextension = Path.GetExtension(AadharFile.FileName);

            if (extension != ".jpg")
            {

                return View();
            }
            else
            {
                aadhar = aadhar + extension;
                updoc.Aadhar_Card = "~/Files/" + aadhar;
                aadhar = Path.Combine(Server.MapPath("~/Files/"), aadhar);
                AadharFile.SaveAs(aadhar);
            }

            string salary = Path.GetFileNameWithoutExtension(SalaryFile.FileName);
            string sextension = Path.GetExtension(SalaryFile.FileName);
            if (extension != ".jpg")
            {

                return View();
            }
            else
            {
                salary = salary + extension;
                updoc.Salary_Slip = "~/Files/" + salary;
                salary = Path.Combine(Server.MapPath("~/Files/"), salary);
                SalaryFile.SaveAs(salary);
            }

            string loa = Path.GetFileNameWithoutExtension(LOAFile.FileName);
            string loaextension = Path.GetExtension(LOAFile.FileName);
            if (extension != ".jpg" )
            {

                return View();
            }
            else
            {
                loa = loa + extension;
                updoc.LOA = "~/Files/" + loa;
                loa = Path.Combine(Server.MapPath("~/Files/"), loa);
                LOAFile.SaveAs(loa);
            }

            string noc = Path.GetFileNameWithoutExtension(NOCFile.FileName);
            string nocextension = Path.GetExtension(NOCFile.FileName);
            if (extension != ".jpg" )
            {

                return View();
            }
            else
            {
                noc = noc + extension;
                updoc.NOC = "~/Files/" + noc;
                noc = Path.Combine(Server.MapPath("~/Files/"), noc);
                NOCFile.SaveAs(noc);
            }

            string agreement = Path.GetFileNameWithoutExtension(AgreementFile.FileName);
            string agextension = Path.GetExtension(AgreementFile.FileName);
            if (extension != ".jpg")
            {

                return View();
            }
            else
            {
                agreement = agreement + extension;
                updoc.Agreement = "~/Files/" + agreement;
                agreement = Path.Combine(Server.MapPath("~/Files/"), agreement);
                AgreementFile.SaveAs(agreement);
                db.Upload_Document.Add(updoc);
                db.SaveChanges();

            }
            var status = new Status() { Application_ID = Convert.ToInt32(Session["Application_ID"]) ,Verification_Status="NotVerified"};
            db.Status.Add(status);
            db.SaveChanges();
            TempData["UploadStatus"] = "Uploaded Successfully and Documents sent for Verification";
            return RedirectToAction("UserHome");
        }
        /// <summary>
        /// Page where User can View His Basic Information and Change his Password when required.
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageAccount()
        {
            var AppID = Convert.ToInt32(Session["Application_ID"]);
            var x = (from i in db.User_Detail where i.Application_ID==AppID select i).SingleOrDefault();
            return View(x);
        }
        /// <summary>
        /// Form to Change User Password
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ModifyPassword(int? id)
        {
            var z = Convert.ToInt32(Session["Application_ID"]);
            var password = Request.Form["pass"];
            var res = (from i in db.User_Detail where i.Application_ID == z select i).SingleOrDefault();
            res.User_Password = password;
            db.SaveChanges();
            TempData["message"] = "Password Changed Successfully";
            return RedirectToAction("LoggedInHome", "User");
        }
        /// <summary>
        /// Form which allows User to set a new Password if He/She forgets the Password.
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(int? id)
        {
            var email = Request.Form["email"];
            var number = Request.Form["mobile"];
            var res = (from i in db.User_Detail where i.Email == email && i.Phone_Number == number select i).SingleOrDefault();
            if(res!=null)
            {
                Session["emailid"] = email;
                return RedirectToAction("SetNewPassword", "User");
            }
            else
            {
                TempData["error"] = "Please Check your Email and Mobile Number";
                return View();
            }
        }
        /// <summary>
        /// Changes the Password of the User.
        /// </summary>
        /// <returns></returns>
        public ActionResult SetNewPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetNewPassword(int? id)
        {
            var email = Session["emailid"].ToString();
            var p = Request.Form["pass"];
            var res = (from i in db.User_Detail where i.Email == email select i).SingleOrDefault();
            res.User_Password = p;
            db.SaveChanges();
            TempData["d"] = "Login with your New Password";
            return RedirectToAction("UserLogin", "User");
        }

       
    }
}