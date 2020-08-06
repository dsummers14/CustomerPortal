using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.Mvc;
using Microsoft.NAV;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Runtime.InteropServices;
using Microsoft.Owin.Security.Provider;
using Microsoft.OData.Client;


namespace CustomerPortal.Controllers
{
    public class SalesOrderLineController : Controller
    {

        public ActionResult Index (string id)
        {
            ViewData.Add("documentId", id);
           

            return View();
        }

  
        public ActionResult SalesOrderLines_Read([DataSourceRequest] DataSourceRequest request, Guid documentId)
        {
           // IQueryable<salesOrderLine> salesOrderLines = null;
            var salesOrderLinesModel = new List<salesOrderLineModel>();
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

            try
            {
               var salesOrderLines = (from lsalesOrderLine in iWebService.salesOrderLines where lsalesOrderLine.documentId == documentId select lsalesOrderLine);

                foreach (salesOrderLine lsalesOrderLine in salesOrderLines)
                 {                 
                    salesOrderLinesModel.Add(new salesOrderLineModel(lsalesOrderLine));
                 }
            }
            catch (Exception ex)
            {
                // return ex;
            }

            return Json(salesOrderLinesModel.ToDataSourceResult(request));
        }
         
        [HttpPost]
        public ActionResult SalesOrderLine_Update([DataSourceRequest] DataSourceRequest request, salesOrderLineModel modelSalesOrderLine)
        {
            List<salesOrderLineModel> iResult = new List<salesOrderLineModel>();

            if (!ModelState.IsValid)
            {
            }

            try
            {
                var salesOrderLineUpdate = new BCEntities.salesOrderLineUpdate(modelSalesOrderLine);
                var salesOrderLines = BCAPIServices.GetEntityCollection<BCEntities.salesOrderLines>(string.Format("$filter=id eq '{0}'",modelSalesOrderLine.id), true);
                var salesOrderLine = salesOrderLines.value.FirstOrDefault();
               
                var updatedSalesOrderLine = BCAPIServices.UpdateEntity<BCEntities.salesOrderLine, BCEntities.salesOrderLineUpdate>(salesOrderLine.id, salesOrderLineUpdate, salesOrderLine.etag, "", true);

                if (updatedSalesOrderLine.error != null)
                {
                    ModelState.AddModelError("", updatedSalesOrderLine.error.message);
                    iResult.Add(modelSalesOrderLine);
                }
                else
                {
                    iResult.Add(new salesOrderLineModel(updatedSalesOrderLine));
                }

            }
            catch (DataServiceRequestException ex)
            {
                ModelState.AddModelError("", ex.Message);
                iResult.Add(modelSalesOrderLine);
            }


            return Json(iResult.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SalesOrderLine_Create([DataSourceRequest] DataSourceRequest request, salesOrderLineModel modelSalesOrderLine)
        {
            var iResult = new List<salesOrderLine>();
            var newOrderLine = new Microsoft.NAV.salesOrderLine();

            if (!ModelState.IsValid)
            {
            }

            try
            {
                var iUri = new Uri(ODataWebService.BuildODataUrl());
                var iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
                var iItem = (from item in iWebService.items where item.number == modelSalesOrderLine.number select item).FirstOrDefault();

                if (iItem != null)
                {
                    newOrderLine.id = "";
                    newOrderLine.documentId = new Guid(modelSalesOrderLine.documentId);
                    newOrderLine.lineType = "Item";
                    newOrderLine.itemId = iItem.id;
                    newOrderLine.description = modelSalesOrderLine.description;
                    //newOrderLine.lineDetails = new documentLineObjectDetailsType();
                    //newOrderLine.lineDetails.number = modelSalesOrderLine.number;
                    //newOrderLine.lineDetails.displayName = modelSalesOrderLine.description;
                    newOrderLine.quantity = modelSalesOrderLine.quantity;
                    newOrderLine.unitPrice = (decimal)modelSalesOrderLine.unitPrice;

                    iWebService.AddTosalesOrderLines(newOrderLine);
                    iWebService.SaveChanges();

                    iResult.Add(newOrderLine);
                }
            }
            catch (DataServiceRequestException ex)
            {
                ModelState.AddModelError("", ex.Message);
                iResult.Add(newOrderLine);
            }
        
            return Json(iResult);
        }
      
        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult SalesOrderLine_Delete([DataSourceRequest] DataSourceRequest request, salesOrderLine OrderLine)
        {
            List<salesOrderLine> iResult = new List<salesOrderLine>();
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

            try
            {
                var salesOrderLine = (from lsalesOrderLine in iWebService.salesOrderLines where lsalesOrderLine.id == OrderLine.id select lsalesOrderLine);
            }
            catch (Exception ex)
            {
                // return ex;
            }

            return Json(iResult.ToDataSourceResult(request,ModelState));
        }

    }
}



