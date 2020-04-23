using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;


namespace WebApplication1.Controllers
{
    public  class SalesQuoteLinesController : ODataController {
           
        public IQueryable<salesQuoteLine> GetSalesQuoteLines(ODataQueryOptions queryOptions)
        {
            IQueryable<salesQuoteLine> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
              iQuery = (IQueryable<salesQuoteLine>)queryOptions.ApplyTo(iWebService.salesQuoteLines);
            }
            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
