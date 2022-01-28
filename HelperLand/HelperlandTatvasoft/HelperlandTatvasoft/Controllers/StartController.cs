using HelperlandTatvasoft.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var login = _db.Users.Where(s => s.Email == u.Email);
            if (login.Any())
            {
                if (login.Where(s => s.Password == u.Password).Any())
                {
                    
                    return Json(new
                    {
                        status = true,
                        message = "Login Successfull!"
                    });
                }

                else
                {
                    return Json(new
                    {
                        status = true,
                        message = "Invalid Password!"
                    });
                }
            }

            else
            {
                return Json(new
                {
                    status = false,
                    message = "Invalid Username!"
                });
            }
        }
    }
}
