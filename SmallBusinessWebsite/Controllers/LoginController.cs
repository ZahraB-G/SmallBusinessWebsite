using DataLibrary.BusinessLogic;
using SmallBusinessWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            if (ModelState.IsValid)
            {
                int UserCredentialId = SignUpProcessor.IsUserExists(model.Username, model.Password);
                if (UserCredentialId != 0)//if the user has an account we are going to the Company page
                {
                    cookie["UserID"] = UserCredentialId.ToString();
                    Response.Cookies.Add(cookie);
                    if (SignUpProcessor.IsUserNew(UserCredentialId))
                        return RedirectToAction("Index", "CompanyPage");
                    else
                        return RedirectToAction("Index", "Company");
                }

                else
                {
                    Response.Write("<script language=javascript>alert('Incorrect Username or Password, Please Try Again');</script>");
                    return View();
                }

            }
            return View();
        }
    }
}