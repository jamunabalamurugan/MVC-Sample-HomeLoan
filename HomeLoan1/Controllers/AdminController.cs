using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using IronOcr;
using System.Web.Mvc;
using HomeLoan1.Models;
using IronBarCode;
using System.Text.RegularExpressions;
using System.IO;

namespace HomeLoan1.Controllers
{
    [HandleError]
    public class AdminController : Controller
    {
        Home_Loan_TestEntities db = new Home_Loan_TestEntities();
        /// <summary>
        /// Empty View Result to Clear All the Session Variables when Called by the Signout/Logout Button.
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminSignOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserHome", "User");
        }
        /// <summary>
        /// Home Page of the Admin where He/She can View Verified or Not Verified Applications.
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminHome()
        {
            return View();
        }
      
        /// <summary>
        /// Page which displays all the Applications which are Not Verified in a WebGrid.
        /// </summary>
        /// <returns></returns>
        public ActionResult NotVerified()
        {    
            var udetails = (from i in db.User_Detail
                            join j in db.Incomes on i.Application_ID equals j.Application_ID
                            join k in db.LoanDetails on i.Application_ID equals k.Application_ID
                            join z in db.Properties on i.Application_ID equals z.Application_ID
                            join m in db.Upload_Document on i.Application_ID equals m.Application_ID
                            join n in db.Status on i.Application_ID equals n.Application_ID
                            where n.Verification_Status == "NotVerified"
                            select new AllUsers { Phone_Number = i.Phone_Number, Application_ID = i.Application_ID, First_Name = i.First_Name, Last_Name = i.Last_Name, Email = i.Email, Verification_Status = n.Verification_Status,Gender=i.Gender,Date_Of_Birth=i.Date_Of_Birth,Amount=k.Amount}).ToList();
            return View(udetails.ToList());
        }
        /// <summary>
        /// Page to display all the Applications which are Verified in a WebGrid.
        /// </summary>
        /// <returns></returns>
        public ActionResult Verified()
        {
            var udetails = (from i in db.User_Detail
                            join j in db.Incomes on i.Application_ID equals j.Application_ID
                            join k in db.LoanDetails on i.Application_ID equals k.Application_ID
                            join z in db.Properties on i.Application_ID equals z.Application_ID
                            join m in db.Upload_Document on i.Application_ID equals m.Application_ID
                            join n in db.Status on i.Application_ID equals n.Application_ID
                            where n.Verification_Status == "Verified"
                            select new AllUsers { Phone_Number = i.Phone_Number, Application_ID = i.Application_ID, First_Name = i.First_Name, Last_Name = i.Last_Name, Email = i.Email, Verification_Status = n.Verification_Status, Gender = i.Gender, Date_Of_Birth = i.Date_Of_Birth, Amount = k.Amount }).ToList();
            return View(udetails.ToList());
        }
      


        /// <summary>
        /// Page to display Details of the selected Applicant in a WebGrid Format.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewDetails(int? id)
        {
            var udetails = (from i in db.User_Detail
                            join j in db.Incomes on i.Application_ID equals j.Application_ID
                            join k in db.LoanDetails on i.Application_ID equals k.Application_ID
                            join z in db.Properties on i.Application_ID equals z.Application_ID
                            join m in db.Upload_Document on i.Application_ID equals m.Application_ID
                            join n in db.Status on i.Application_ID equals n.Application_ID
                            where n.Verification_Status == "NotVerified" && i.Application_ID == id
                            select new AllUsers { Phone_Number = i.Phone_Number, Application_ID = i.Application_ID, First_Name = i.First_Name, Middle_Name=i.Middle_Name,Last_Name = i.Last_Name, Email = i.Email, Verification_Status = n.Verification_Status, Gender = i.Gender, Date_Of_Birth = i.Date_Of_Birth, Amount = k.Amount,
                            Interest=k.Interest,Tenure=k.Tenure,Aadhar_Number=i.Aadhar_Number,Pan_Number=i.Pan_Number,
                            Type_Of_Employment=j.Type_Of_Employment,Organization_Name=j.Organization_Name,Organization_Type=j.Organization_Type,Salary=j.Salary,Retirement_Age=j.Retirement_Age,
                            Plot_Number=z.Plot_Number,Property_Area=z.Property_Area,Pincode=z.Pincode,Type_Of_Property=z.Type_Of_Property,Estimated_Cost=z.Estimated_Cost,
                            Aadhar_Card=m.Aadhar_Card,Pan_Card=m.Pan_Card,Salary_Slip=m.Salary_Slip,LOA=m.LOA,NOC=m.NOC,Agreement=m.Agreement}).ToList();
            return View(udetails.ToList());
        }
        public ActionResult ViewVDetails(int? id)
        {
            var udetails = (from i in db.User_Detail
                            join j in db.Incomes on i.Application_ID equals j.Application_ID
                            join k in db.LoanDetails on i.Application_ID equals k.Application_ID
                            join z in db.Properties on i.Application_ID equals z.Application_ID
                            join m in db.Upload_Document on i.Application_ID equals m.Application_ID
                            join n in db.Status on i.Application_ID equals n.Application_ID
                            where n.Verification_Status == "Verified" && i.Application_ID == id
                            select new AllUsers
                            {
                                Phone_Number = i.Phone_Number,
                                Application_ID = i.Application_ID,
                                First_Name = i.First_Name,
                                Middle_Name = i.Middle_Name,
                                Last_Name = i.Last_Name,
                                Email = i.Email,
                                Verification_Status = n.Verification_Status,
                                Gender = i.Gender,
                                Date_Of_Birth = i.Date_Of_Birth,
                                Amount = k.Amount,
                                Interest = k.Interest,
                                Tenure = k.Tenure,
                                Aadhar_Number = i.Aadhar_Number,
                                Pan_Number = i.Pan_Number,
                                Type_Of_Employment = j.Type_Of_Employment,
                                Organization_Name = j.Organization_Name,
                                Organization_Type = j.Organization_Type,
                                Salary = j.Salary,
                                Retirement_Age = j.Retirement_Age,
                                Plot_Number = z.Plot_Number,
                                Property_Area = z.Property_Area,
                                Pincode = z.Pincode,
                                Type_Of_Property = z.Type_Of_Property,
                                Estimated_Cost = z.Estimated_Cost,
                                Aadhar_Card = m.Aadhar_Card,
                                Pan_Card = m.Pan_Card,
                                Salary_Slip = m.Salary_Slip,
                                LOA = m.LOA,
                                NOC = m.NOC,
                                Agreement = m.Agreement
                            }).ToList();
            return View(udetails.ToList());
        }
        /// <summary>
        /// Page to Display List of Documents Uploaded by the Particular User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewDocuments(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select  i );
            
            return View(x.ToList());
        }
        public ActionResult ViewVDocuments(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);

            return View(x.ToList());
        }
        /// <summary>
        /// Displays the Aadhar Card Uploaded by the Applicant and a link to check if Aadhar Card is Valid.
        /// </summary>
        /// <param name="id">Application ID</param>
        /// <returns></returns>
        public ActionResult ViewAadhar(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVAadhar(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewPan(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVPan(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewSalarySlip(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVSalarySlip(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewNoa(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVNoa(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewLoc(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVLoc(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewAgreement(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        public ActionResult ViewVAgreement(int? id)
        {
            var x = (from i in db.Upload_Document where i.Application_ID == id select i);
            return View(x.ToList());
        }
        /// <summary>
        /// Approves the Loan of the Particular Applicant and sends an Email to the respective user regarding the EMI and Loan.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Approve(int? id)
        {
            Status qry = (from x in db.Status where x.Application_ID == id select x).SingleOrDefault();
            qry.Loan_Status = "Approved";
            qry.Verification_Status = "Verified";
            db.Entry(qry).State = EntityState.Modified;
            db.SaveChanges();
            LoanDetail l = (from x in db.LoanDetails where x.Application_ID == id select x).SingleOrDefault();
            l.Loan_Account_Number = DateTime.Now.ToString("yyyyMMddHHmmss");
            l.Balance = l.Amount;
            db.Entry(l).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.AccountNumber = l.Loan_Account_Number;
            ViewBag.AppID = l.Application_ID;
            ViewBag.Amount = l.Amount;
            ViewBag.Interest = 8.5;
            var rate = 8.5 / 100;
            var tenure = Convert.ToDouble(l.Tenure) * 12;
            ViewBag.Tenure = l.Tenure;
            var emi= (l.Amount * rate * Math.Pow((1 + rate), tenure)) / (Math.Pow((1 + rate), tenure) - 1);
            ViewBag.emi = emi;




            Session["id"] = id;
            var res = (from i in db.User_Detail where i.Application_ID == id select i).SingleOrDefault();
            Session["Email"]=res.Email;
            Session["Name"] = res.First_Name + " " + res.Last_Name;
            Session["Phone"] = res.Phone_Number;
            Session["Loan"] = l.Loan_Account_Number;
            Session["Amount"] = l.Amount;
            Session["Tenure"] = l.Tenure;
            Session["EMI"] = Math.Round(Convert.ToDouble(emi));
            Session["DateApprove"] = DateTime.Now.ToString("dd/MM/yyyy");


            var email1 = Convert.ToString(Session["Email"]);
            

            string to = email1; //To address    
            string from = "pika.b809@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Your Loan is Approved" + " <br />" + "Details of your Loan Sanction are as below: <br />" + "  Application ID: " + Convert.ToInt32(Session["id"]) + " <br />" + " Name: " +Session["Name"]+ " <br />" + "Mobile Number: " + Session["Phone"] + " <br />" +
            "Loan Account Number: " + Session["Loan"] + " <br />" + "Amount Sanctioned: ₹ " + Session["Amount"] + " <br />" + "Tenure: " + Session["Tenure"] +" Years" + " <br />" + "Your EMI is: ₹ " + Session["EMI"] + " <br />"
            + " Date of Approval: " + Session["DateApprove"] ;
            message.Subject = "Loan Approved ";
            message.Body = mailbody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("pika.b809@gmail.com", "Jellybean123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return View();

        }
      

            /// <summary>
            /// Rejects the Application of the Particular User.
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public ActionResult Reject(int? id)
        {
            Status qry = (from x in db.Status where x.Application_ID == id select x).FirstOrDefault();
            qry.Loan_Status = "Rejected";
            qry.Verification_Status = "Verified";
            db.Entry(qry).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        /// <summary>
        /// Login Page for Admin to Login.
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminLogin()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var aid = a.Admin_ID;
            var apwd = a.Admin_Password;
            
            var Admins = db.Admins.ToList();
            var res = (from i in db.Admins
                       where i.Admin_ID == aid &&
                       i.Admin_Password == apwd
                       select i).SingleOrDefault();
           if(res!=null)
            {
                Session["Admin"] = "Admin";
                return RedirectToAction("/AdminHome/");
            }
            else
            {
                TempData["Error"] = "Login Unsuccessful";
                return View();
            }
        }
       


        /// <summary>
        /// Method to Check if the Aadhar Card uploaded matches the Aadhar Number which was entered while filling the Application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CheckAadhar(int? id)
        {
            var result = (from i in db.User_Detail where i.Application_ID == id select i).FirstOrDefault();
            var doc = (from i in db.Upload_Document where i.Application_ID == id select i).FirstOrDefault();
            var aadharpath = doc.Aadhar_Card;
           
            Session["mm"] = id;

            string name = aadharpath.ToString();
            string filename = name.Remove(0, 8);
            string fullfn=Path.Combine(Server.MapPath("~/Files/"), filename);
            string fullfilename = "C:\\Users\\pcuser\\source\\repos\\HomeLoan1\\HomeLoan1\\Files\\" + filename;

            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode(fullfn);
            if (Result == null)
            {
                ViewBag.message = "Incorrect Image";
            }
            else
            {
                var res = Result.Text.ToString();
                Regex rg = new Regex("[0-9]{12}");
                MatchCollection m = rg.Matches(res);
                string[] strArray = new string[m.Count];
                for (int i = 0; i < m.Count; i++)
                {
                    strArray[i] = m[i].Groups[0].Value;
                }
                var aadhar = strArray[0];
                var aadharnumber = result.Aadhar_Number;
                if (aadhar == aadharnumber)
                {
                    ViewBag.message = "Aadhar Card Uploaded matches with the Number Entered.... User is Valid!";

                }
                else
                {
                    ViewBag.message = "Aadhar Card uploaded does not match with the Number Entered. You can Reject this Application!";
                }
                Session["enterednum"] = aadharnumber.ToString();
                Session["aadharnum"] = aadhar.ToString();
            }
            return View();
        }

    }


}
