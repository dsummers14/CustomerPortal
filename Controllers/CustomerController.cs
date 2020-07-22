using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;
using System.Security.Claims;

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
        public JsonResult GetCustomers(string CompanyId = "")
        {
            if (CompanyId == "") 
                CompanyId = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CompanyId").Select(s => s.Value).FirstOrDefault();

            Uri iUri = string.IsNullOrEmpty(CompanyId) ? new Uri(ODataWebService.BuildODataUrl()) : new Uri(ODataWebService.BuildODataUrl(CompanyId));
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
            
            var iResults = (from Customer in iWebService.customers
                            orderby Customer.displayName
                            select new { Customer.number, Customer.displayName, Customer.id}).ToList().Distinct();

            return Json(iResults, JsonRequestBehavior.AllowGet);
        }

    }
}