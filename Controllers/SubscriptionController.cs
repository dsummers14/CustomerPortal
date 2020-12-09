using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Owin.Security.Provider;
using Microsoft.OData.Client;



namespace CustomerPortal.Controllers
{

    [Authorize]
    public class SubscriptionController : Controller
    {
        // GET: Subscriptions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subscriptions_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<subscriptions> subscriptions = null;

            try
            {
                var iUri = new Uri(ODataWebService.BuildODataUrl(false));
                var iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

                subscriptions = (from subscription in iWebService.subscriptions select subscription);
               
            }
            catch (DataServiceRequestException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return Json(subscriptions.ToDataSourceResult(request, ModelState));
        }
    } 
}
