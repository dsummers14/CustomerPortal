using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.Graph;
using Microsoft.OData.Edm;
using System.Security.Claims;


namespace CustomerPortal.Controllers
{
    [Authorize]
    public class SalesOrderController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {

            return View(newOrder());
        }

        public salesOrder newOrder()
        {
            var customerNumber = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CustomerNumber").Select(s => s.Value).FirstOrDefault();
            var webRole = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_WebRole").Select(s => s.Value).FirstOrDefault();
            bool filterCustomer = (webRole != "1");

            var newOrder = new salesOrder();

            newOrder.orderDateTime = DateTime.Now;
            newOrder.postingDateTime = DateTime.Now;
            newOrder.requestedDeliveryDateTime = DateTime.Now;
          
           if (filterCustomer) 
                newOrder.customerNumber = customerNumber;
                    

            return newOrder;
        }

        [HttpPost]
        public ActionResult CreateOrder(salesOrder order)
        {
            if (!ModelState.IsValid)
            {
               var updatedOrder = new salesOrder();
            }



            return Redirect("Index") ;
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
