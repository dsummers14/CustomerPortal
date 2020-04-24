using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;


namespace CustomerPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Select().Expand().Filter().OrderBy().MaxTop(10000).Count();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Microsoft.NAV.customer>("Customers");
            builder.EntitySet<Microsoft.NAV.item>("Items");
            builder.EntitySet<Microsoft.NAV.salesQuote>("SalesQuotes");
            builder.EntitySet<Microsoft.NAV.salesQuoteLine>("SalesQuoteLines");
            builder.EntitySet<Microsoft.NAV.salesOrder>("SalesOrders");
            builder.EntitySet<Microsoft.NAV.salesOrderLine>("SalesOrderLines");
            builder.EntitySet<Microsoft.NAV.salesInvoice>("SalesInvoices");
            builder.EntitySet<Microsoft.NAV.salesInvoiceLine>("SalesInvoiceLines");
            builder.EntitySet<Microsoft.Graph.User>("Users");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "oData",
                model: builder.GetEdmModel());

        }
    }
}
