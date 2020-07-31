using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CustomerPortal.Controllers
{
    public class SalesOrderLineController : Controller
    {


        public ActionResult SalesOrderLines_Read(DataSourceRequest request, Guid documentId)
        {
            IQueryable<salesOrderLine> salesOrderLines = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

            try
            {
                salesOrderLines = (from lsalesOrderLine in iWebService.salesOrderLines where lsalesOrderLine.documentId == documentId select lsalesOrderLine);
            }
            catch (Exception ex)
            {
                // return ex;
            }

            return Json(salesOrderLines.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult SalesOrderLine_Update(DataSourceRequest request, salesOrderLine OrderLine)
        {
            List<salesOrderLine> iResult = new List<salesOrderLine>();





            return Json(iResult.ToDataSourceResult(request, ModelState));
        }
        [HttpPost]
        public ActionResult SalesOrderLine_Create(DataSourceRequest request, salesOrderLine OrderLine)
        {
            List<salesOrderLine> iResult = new List<salesOrderLine>();





            return Json(iResult.ToDataSourceResult(request, ModelState));
        }
       [HttpDelete]
        public ActionResult SalesOrderLines_Delete(DataSourceRequest request, salesOrderLine OrderLine)
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

            return Json(iResult.ToDataSourceResult(request));
        }

    }
}



