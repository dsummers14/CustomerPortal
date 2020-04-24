using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;
using Microsoft.OData.Edm;


namespace WebApplication1.Controllers
{
    public  class ItemsController : ODataController {
           
        public IQueryable<item> GetItems(ODataQueryOptions queryOptions)
        {
            IQueryable<item> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
             iQuery = (IQueryable<item>)queryOptions.ApplyTo(iWebService.items);
        
            }
            catch (Exception ex)
            {
               // return ex;
            }

            
            return iQuery;
        }

     }
}

          