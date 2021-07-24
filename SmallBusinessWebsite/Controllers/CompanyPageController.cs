using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessWebsite.Controllers
{
    public class CompanyPageController : Controller
    {
        // GET: CompanyPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Customers()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
        public ActionResult Reports()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
    }
}