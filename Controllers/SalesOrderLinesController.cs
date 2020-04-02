using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;


namespace WebApplication1.Controllers
{
    public  class SalesOrderLinesController : ODataController {
           
        public IQueryable<salesOrderLine> GetSalesOrderLines(ODataQueryOptions queryOptions)
        {
            IQueryable<salesOrderLine> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
              iQuery = (IQueryable<salesOrderLine>)queryOptions.ApplyTo(iWebService.salesOrderLines);
            }
            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
