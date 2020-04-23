using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public JsonResult GetCustomers()
        {
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
            
            var iResults = (from Customer in iWebService.customers
                            orderby Customer.displayName
                            select new { CustomerNo = Customer.number, Name = Customer.displayName, id =Customer.id }).ToList().Distinct();

            return Json(iResults, JsonRequestBehavior.AllowGet);
        }

    }
}