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
    public class SalesInvoiceController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            salesInvoice iSalesInvoice = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
                iSalesInvoice = (from salesinvoice in iWebService.salesInvoices where salesinvoice.id == id select salesinvoice).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // return ex;
            }
            return View(iSalesInvoice);
        }


    }
}