using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.BusinessLogic;
using SmallBusinessWebsite.Controllers;
using SmallBusinessWebsite.Models;

namespace SmallBusinessWebsite.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CompanyProfileModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    model.UserCredentialsID = Int32.Parse(cookie["UserID"]);
                    CompanyProcessor.InsertCompanyInformation(model.CompanyName, model.Address1, model.Address2, model.City, model.State, model.Zipcode, model.UserCredentialsID);
                    return RedirectToAction("Index", "CompanyPage");
                }

            }
            else
            {
                return View();
            }
            return View();
        }
    }
}