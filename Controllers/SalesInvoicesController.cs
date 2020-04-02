using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    public  class SalesInvoicesController : ODataController {
           
        public IQueryable<salesInvoice> GetSalesInvoices(ODataQueryOptions queryOptions)
        {
            IQueryable<salesInvoice> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
              iQuery = (IQueryable<salesInvoice>)queryOptions.ApplyTo(iWebService.salesInvoices);
            }
            catch (Exception ex)
            {
               // return ex;
            }
      
            return iQuery;
        }
    }
}
