using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public JsonResult GetCompanies()
        {
            Uri iUri = new Uri(ODataWebService.BuildODataUrl(false));
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
            
            var iResults = (from Company in iWebService.companies
                            orderby Company.displayName
                            select new {Company.displayName, Company.id }).ToList().Distinct();

            return Json(iResults, JsonRequestBehavior.AllowGet);
        }

    }
}