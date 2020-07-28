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

            if (filterCustomer) 
                newOrder.customerNumber = customerNumber;
                    

            return newOrder;
        }

        [HttpPost]
        public ActionResult CreateOrder(salesOrderModel order)
        {
            if (!ModelState.IsValid)
            {
             
            }

            try
            {
                Uri iUri = new Uri(ODataWebService.BuildODataUrl());
                NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
                var newOrder = new salesOrder();

                newOrder.customerNumber = order.customerNumber;
                newOrder.externalDocumentNumber = order.externalDocumentNumber;
                newOrder.orderDate = order.orderDateTime;
                newOrder.requestedDeliveryDate = order.requestedDeliveryDateTime;
                newOrder.currencyCode = "USD";
                newOrder.shipToContact = order.shipToContact;
                newOrder.shipToName = order.shipToName;
                newOrder.shippingPostalAddress = order.shippingPostalAddress;


                iWebService.AddTosalesOrders(newOrder);
                iWebService.SaveChanges(SaveChangesOptions.PostOnlySetProperties);
            }
            catch (Exception ex)
            {

            }

            return View("Index");
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

                salesOrderModel.id = salesOrder.id;
                salesOrderModel.customerNumber = salesOrder.customerNumber;
                salesOrderModel.externalDocumentNumber = salesOrder.externalDocumentNumber;
                salesOrderModel.orderDateTime = ODataWebService.EdmDateToDateTime(salesOrder.orderDate);
                salesOrderModel.requestedDeliveryDateTime = ODataWebService.EdmDateToDateTime(salesOrder.requestedDeliveryDate);
                salesOrderModel.currencyCode = "USD";
                salesOrderModel.shipToContact = salesOrder.shipToContact;
                salesOrderModel.shipToName = salesOrder.shipToName;
                salesOrderModel.shippingPostalAddress = salesOrder.shippingPostalAddress;

            }
            catch (Exception ex)
            {
                // return ex;
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

            }
            catch (DataServiceRequestException ex)
            {

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
