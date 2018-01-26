using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(UserDetails usr)
        {
            EmployeeBussinesLayer bal = new EmployeeBussinesLayer();
            if (bal.IsValidUser(usr))
            {
                FormsAuthentication.SetAuthCookie(usr.UserName, false);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }
    }
}