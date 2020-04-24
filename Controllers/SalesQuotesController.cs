using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;
using System.Security.Claims;



namespace CustomerPortal.Controllers
{
    public  class SalesQuotesController : ODataController {
           
        public IQueryable<salesQuote> GetSalesQuotes(ODataQueryOptions queryOptions)
        {
            IQueryable<salesQuote> iQuery = null;
             Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
                iQuery = (IQueryable<salesQuote>)queryOptions.ApplyTo(iWebService.salesQuotes);
              
            }

            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
