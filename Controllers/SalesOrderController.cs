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
using Microsoft.OData.Client;
using System.Security.Claims;
using Microsoft.Ajax.Utilities;

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

        public salesOrderModel newOrder()
        {
            var customerNumber = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CustomerNumber").Select(s => s.Value).FirstOrDefault();
            var webRole = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_WebRole").Select(s => s.Value).FirstOrDefault();
            bool filterCustomer = (webRole != "1");

            var newOrder = new salesOrderModel();

            newOrder.orderDateTime = DateTime.Now;
            newOrder.requestedDeliveryDateTime = DateTime.Now;
            newOrder.shippingPostalAddress = new Microsoft.NAV.postalAddressType();

            if (filterCustomer) 
                newOrder.customerNumber = customerNumber;
                    

            return newOrder;
        }

        [HttpPost]
        public ActionResult CreateOrder(salesOrderModel salesOrderModel)
        {
            if (string.IsNullOrEmpty(salesOrderModel.customerNumber))
                ModelState.AddModelError("", "Customer Number is required");

            if (!ModelState.IsValid)
            {
                return View(salesOrderModel);
            }

            var newOrder = new salesOrder();

            try
            {
                Uri iUri = new Uri(ODataWebService.BuildODataUrl());
                NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
               

                newOrder.customerNumber = salesOrderModel.customerNumber;
                newOrder.externalDocumentNumber = salesOrderModel.externalDocumentNumber;
                newOrder.orderDate = salesOrderModel.orderDateTime;
                newOrder.requestedDeliveryDate = salesOrderModel.requestedDeliveryDateTime;
                newOrder.shipToContact = salesOrderModel.shipToContact;
                newOrder.shipToName = salesOrderModel.shipToName;
                newOrder.shippingPostalAddress = salesOrderModel.shippingPostalAddress;


                iWebService.AddTosalesOrders(newOrder);
                iWebService.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("UpdateOrder", new { id = newOrder.id });
        }

        [HttpGet]
        public ActionResult UpdateOrder(Guid id)
        {
            salesOrderModel salesOrderModel = new salesOrderModel();
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

            try
            {
                var salesOrder = (from lsalesOrder in iWebService.salesOrders where lsalesOrder.id == id select lsalesOrder).FirstOrDefault();

                if (salesOrder.status != "Draft")
                {
                    ModelState.AddModelError("", "This order has been released and cannot be modified");
                }

                salesOrderModel.id = salesOrder.id;
                salesOrderModel.number = salesOrder.number;
                salesOrderModel.customerNumber = salesOrder.customerNumber;
                salesOrderModel.externalDocumentNumber = salesOrder.externalDocumentNumber;
                salesOrderModel.orderDateTime = ODataWebService.EdmDateToDateTime(salesOrder.orderDate);
                salesOrderModel.requestedDeliveryDateTime = ODataWebService.EdmDateToDateTime(salesOrder.requestedDeliveryDate);
                salesOrderModel.shipToContact = salesOrder.shipToContact;
                salesOrderModel.shipToName = salesOrder.shipToName;
                salesOrderModel.shippingPostalAddress = salesOrder.shippingPostalAddress;
            }
            catch (Exception ex)
            {
            }

            
            return View(salesOrderModel);
        }

        [HttpPost]
        public ActionResult UpdateOrder(salesOrderModel salesOrderModel)
        {
            if (!ModelState.IsValid)
            {
            }

            try
            {
                var salesOrder = BCAPIServices.GetEntityById<BCEntities.salesOrder>(salesOrderModel.id.ToString());

                BCEntities.salesOrderUpdate salesOrderUpdate = new BCEntities.salesOrderUpdate();
                salesOrderUpdate.externalDocumentNumber = salesOrderModel.externalDocumentNumber;
                salesOrderUpdate.shipToContact = salesOrderModel.shipToContact;
                salesOrderUpdate.shipToName = salesOrderModel.shipToName;
                salesOrderUpdate.orderDate = string.Format("{0:yyyy-MM-dd}", salesOrderModel.orderDateTime);
                salesOrderUpdate.requestedDeliveryDate = string.Format("{0:yyyy-MM-dd}", salesOrderModel.requestedDeliveryDateTime);
                salesOrderUpdate.shippingPostalAddress = salesOrderModel.shippingPostalAddress;

                var updatedSalesOrder = BCAPIServices.UpdateEntity<BCEntities.salesOrder, BCEntities.salesOrderUpdate>(salesOrder.id.ToString(), salesOrderUpdate, salesOrder.etag, "", true);

                if (updatedSalesOrder.error != null)
                {
                    ModelState.AddModelError("", updatedSalesOrder.error.message);
                }
            }
            catch (DataServiceRequestException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            if (!ModelState.IsValid)
            {
                return View(salesOrderModel);
            }

            return View("Index"); 
        }
      

    }
}

//Uri iUri = new Uri(ODataWebService.BuildODataUrl());
//NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

//var salesOrder = (from lsalesOrder in iWebService.salesOrders where lsalesOrder.id == salesOrderModel.id select lsalesOrder).FirstOrDefault();

//DataServiceCollection<salesOrder> salesOrdersCollection = new DataServiceCollection<salesOrder>(iWebService);
//salesOrdersCollection.Add(salesOrder);

//                 salesOrder.externalDocumentNumber = salesOrderModel.externalDocumentNumber;
//                    salesOrder.orderDate = salesOrderModel.orderDateTime;
//                    salesOrder.requestedDeliveryDate = salesOrderModel.requestedDeliveryDateTime;
//                    salesOrder.currencyCode = "USD";
//                    salesOrder.shipToContact = salesOrderModel.shipToContact;
//                    salesOrder.shipToName = salesOrderModel.shipToName;
//                    salesOrder.shippingPostalAddress = salesOrderModel.shippingPostalAddress;

//                    iWebService.UpdateObject(salesOrder);
//                    iWebService.SaveChanges(SaveChangesOptions.PostOnlySetProperties);
