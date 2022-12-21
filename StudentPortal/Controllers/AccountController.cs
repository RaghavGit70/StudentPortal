using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Models;
using System.Web.Security;


namespace StudentPortal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Models.Membership model)
        {
            using (var context = new Student_IFEntities1())
            {


                bool isValid = context.Account_Information.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Stu_Inf");
                }

                ModelState.AddModelError("", "Invalid UserName or password");
                return View();
            }
            

        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SignUp(Account_Information model)
        {
            using (var context = new Student_IFEntities1())
            {
                context.Account_Information.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}