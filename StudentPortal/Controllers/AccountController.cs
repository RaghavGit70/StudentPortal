using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Models;
using System.Web.Security;
using StudentDAL;

namespace StudentPortal.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// returning view for login page
        /// </summary>
        /// <returns></returns>
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// api for posting log in details and verifying user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new Student_IFEntities())
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
        /// <summary>
        /// returning view for signing up new user
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUp()
        {
            return View();
        }
        /// <summary>
        /// api for posting signing up details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult SignUp(SignUpViewModel model)
        {
            using (var context = new Student_IFEntities())
            {
                context.Account_Information.Add(model.account_Information);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// api for user to logout
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}



