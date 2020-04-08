using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.NAV;
using System.Linq;
using Microsoft.OData.Edm;


namespace WebApplication1.Controllers
{
    public  class CustomersController : ODataController {
           
        public IQueryable<customer> GetCustomers(ODataQueryOptions queryOptions)
        {
            IQueryable<customer> iQuery = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) {Credentials = ODataWebService.CreateCredentials(iUri.ToString())};

            try
            {
             iQuery = (IQueryable<customer>)queryOptions.ApplyTo(iWebService.customers);
        
            }
            catch (Exception ex)
            {
               // return ex;
            }

            
            return iQuery;
        }

     }
}

           // var Customers = from Cust in iWebService.customers where Cust.number == "10000" select Cust;