using DataLibrary.BusinessLogic;
using SmallBusinessWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessWebsite.Controllers
{
    public class SignUpController : Controller
    {

        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                /*If client already has an account and tries to sign up again*/
                HttpCookie cookie = new HttpCookie("UserInfo");
                int UserCredentialId = SignUpProcessor.IsEmailExist(model.EmailAddress);
                if (UserCredentialId != 0)
                {
                    int Id = SignUpProcessor.IsUserExists(model.EmailAddress, model.Password); //everything match with db so redirect to login
                    if(Id != 0)
                    {
                        cookie["UserID"] = UserCredentialId.ToString();
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index", "Login");
                    }
                    ViewBag.UsernameError = "This username is not available";
                    return View();
                }
                else
                {
                    int recordsCreated = SignUpProcessor.CreateUser(model.EmailAddress, model.Password);
                    UserCredentialId = SignUpProcessor.IsUserExists(model.EmailAddress, model.Password);
                    cookie["UserID"] = UserCredentialId.ToString();
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }
    }
}