using HelperlandTatvasoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelperlandTatvasoft.Controllers
{
    public class StartController : Controller
    {

        private readonly HelperLandContext _db;

        public StartController(HelperLandContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult faq()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact c)
        {
            _db.Contacts.Add(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CustomerRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyEmail(User u)
        {
            var get_user = _db.Users.FirstOrDefault(p => p.Email.Equals(u.Email) && p.Password.Equals(u.Password));
            if (get_user != null)
            {
                if (get_user.UserTypeId == 1)
                {
                    HttpContext.Session.SetString("username", get_user.FirstName);
                    return RedirectToAction("customerServiceHistory");
                }
                else if (get_user.UserTypeId == 2)
                {
                    if (get_user.IsApproved == true)
                    {
                        HttpContext.Session.SetString("username", get_user.FirstName);
                        return RedirectToAction("about");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    HttpContext.Session.SetString("username", get_user.FirstName);
                    return RedirectToAction("faq");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

        public ActionResult customerServiceHistory()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult CustomerAdd(User u)
        {
            var get_user = _db.Users.FirstOrDefault(p => p.Email.Equals(u.Email));
            if (get_user == null)
            {
                User user = new User();
                user.FirstName = u.FirstName;
                user.LastName = u.LastName;
                user.Email = u.Email;
                user.Mobile = u.Mobile;
                user.Password = u.Password;
                user.UserTypeId = 1;
                user.CreatedDate = DateTime.Now;
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "User already Exist";
                return RedirectToAction("CustomerRegister");
            }
        }

        public ActionResult BecomeAHelper()
        {
            return View();
        }

        public ActionResult HelperRegister(User u)
        {
            var get_user = _db.Users.FirstOrDefault(p => p.Email.Equals(u.Email));
            if (get_user == null)
            {
                User user = new User();
                user.FirstName = u.FirstName;
                user.LastName = u.LastName;
                user.Email = u.Email;
                user.Mobile = u.Mobile;
                user.Password = u.Password;
                user.UserTypeId = 2;
                user.CreatedDate = DateTime.Now;
                user.IsApproved = false;
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "User already Exist";
                return RedirectToAction("BecomeAHelper");
            }
        }
        
        [HttpPost]
        public ActionResult SendEmailForForgotPassword(User u)
        {
            var get_user = _db.Users.FirstOrDefault(p => p.Email.Equals(u.Email));
            if (get_user != null)
            {
                String To = u.Email;

                var lnkHref = "<a href='" + Url.Action("ResetPassword", "Start",null, "http") + "'>Reset Password</a>";
                String subject = "Hello Test mail";

                String Body = "Password link" +" " + lnkHref;
                MailMessage mm = new MailMessage();
                mm.To.Add(To);
                mm.Subject = subject;
                mm.Body = Body;
                mm.From = new MailAddress("testhelperland@gmail.com");
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("testhelperland@gmail.com", "testhelperland123");
                smtp.Send(mm);
                ViewBag.message = "The email has been sent";
                return RedirectToAction("Prices");
            }
            else
            {
                return RedirectToAction("CustomerRegister");
            }
            
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult NewPassword(User u)
        {
            var get_user = _db.Users.FirstOrDefault(p => p.Email.Equals(u.Email));
            if (get_user != null)
            {
                get_user.Password = u.Password;
                _db.Users.Update(get_user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ResetPassword");
                ViewBag.msg("The Email is not Registered");
            }
        }

        
    }
}
