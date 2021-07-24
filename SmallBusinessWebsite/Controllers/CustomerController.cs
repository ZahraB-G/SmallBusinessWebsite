using DataLibrary.BusinessLogic;
using SmallBusinessWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessWebsite.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomerProfileModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    model.UserCredentialsID = Int32.Parse(cookie["UserID"]);
                    CustomerProcessor.InsertCustomerInformation(model.FirstName,model.LastName, model.Address1, model.Address2, model.City, model.State, model.Zipcode,model.Email, model.Phone, model.UserCredentialsID);
                    return RedirectToAction("Index", "CompanyPage");
                }

            }
            else
            {
                return View();
            }
            return View();
        }
        public ActionResult AllCustomer()
        {
            try
            {

                int UserCredentialsId = -1;
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    UserCredentialsId = Int32.Parse(cookie["UserID"]);
                }
                if (CustomerProcessor.IsCustomerExisted(UserCredentialsId) == 0)
                {
                    return View();
                }
                else
                {
                    var data = CustomerProcessor.LoadCustomers(UserCredentialsId);
                    List<CustomerProfileModel> Customers = new List<CustomerProfileModel>();
                    foreach (var row in data)
                    {
                        Customers.Add(new CustomerProfileModel
                        {
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                            Address1 = row.Address1,
                            Address2 = row.Address2,
                            City = row.City,
                            State = row.State,
                            Zipcode = row.Zipcode,
                            Email = row.Email,
                            Phone = row.Phone
                        });
                    }
                    return View(Customers);
                }
            }
            catch (NullReferenceException ex)
            {
                return View();
            }
        }
    }
}