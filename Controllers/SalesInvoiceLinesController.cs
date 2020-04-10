using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;


namespace WebApplication1.Controllers
{
    public  class SalesInvoiceLinesController : ODataController {
           
        public IQueryable<salesInvoiceLine> GetSalesInvoiceLines(ODataQueryOptions queryOptions)
        {
            IQueryable<salesInvoiceLine> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
                
              iQuery = (IQueryable<salesInvoiceLine>)queryOptions.ApplyTo(iWebService.salesInvoiceLines);
            }
            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
