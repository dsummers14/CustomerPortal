using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;
using System.Security.Claims;



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
               //var iCustomerId = ClaimsPrincipal.Current.Claims.Where(w => w.Type == "extension_CustomerId").Select(s => s.Value).FirstOrDefault();

               //iQuery = from salesOrder in iWebService.salesOrders
               //                                 where salesOrder.customerId == new Guid(iCustomerId)
               //                                 select salesOrder;
               
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
