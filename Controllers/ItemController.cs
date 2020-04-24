using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.NAV;

namespace CustomerPortal.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public JsonResult GetItems()
        {
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
            
            var iResults = (from Item in iWebService.items
                            orderby Item.displayName
                            select new { CustomerNo = Item.number, Name = Item.displayName, id =Item.id }).ToList().Distinct();

            return Json(iResults, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(Guid id)
        {
            item iItem = null;
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

            try
            {
                iItem = (from Item in iWebService.items where Item.id == id select Item).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // return ex;
            }
            return View(iItem);
        }

    }
}