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
    public class SalesOrderController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            salesOrder iSalesOrder = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
                iSalesOrder = (from salesOrder in iWebService.salesOrders where salesOrder.id == id select salesOrder).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // return ex;
            }
            return View(iSalesOrder);
        }


    }
}