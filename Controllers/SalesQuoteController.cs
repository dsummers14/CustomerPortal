using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;


namespace WebApplication1.Controllers
{
    [Authorize]
    public class SalesQuoteController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            salesQuote iSalesQuote = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
                iSalesQuote = (from salesQuote in iWebService.salesQuotes where salesQuote.id == id select salesQuote).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // return ex;
            }
            return View(iSalesQuote);
        }


    }
}