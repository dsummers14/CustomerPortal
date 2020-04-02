using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;


namespace WebApplication1.Controllers
{
    public  class SalesOrdersController : ODataController {
           
        public IQueryable<salesOrder> GetSalesOrders(ODataQueryOptions queryOptions)
        {
            IQueryable<salesOrder> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
              iQuery = (IQueryable<salesOrder>)queryOptions.ApplyTo(iWebService.salesOrders);
            }
            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
