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
        public JsonResult GetItems(string text)
        {
            Uri iUri = new Uri(ODataWebService.BuildODataUrl());
            NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };
            
            var iResults = (from Item in iWebService.items
                            orderby Item.displayName
                            where Item.number.Contains(text)
                            select new { itemNumber = Item.number, displayName = Item.displayName, id =Item.id }).ToList().Distinct();

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