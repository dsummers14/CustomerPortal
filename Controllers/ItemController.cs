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
        public JsonResult GetItemsByNumber(string text)
        {
            object iResults = null;
            
            if (text.Length >= 3)
            {
                Uri iUri = new Uri(ODataWebService.BuildODataUrl());
                NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

                iResults = (from Item in iWebService.items
                                orderby Item.number
                                where Item.number.Contains(text)
                                select new { itemNumber = Item.number, displayName = Item.displayName, id = Item.id }).ToList();
            }
            return Json(iResults, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetItemsByName(string text)
        {
            object iResults = null;
            
            if (text.Length >= 3)
            {
                Uri iUri = new Uri(ODataWebService.BuildODataUrl());
                NAV iWebService = new NAV(iUri) { Credentials = ODataWebService.CreateCredentials(iUri.ToString()) };

                 iResults = (from Item in iWebService.items
                                orderby Item.displayName
                                where Item.displayName.Contains(text)
                                select new { itemNumber = Item.number, displayName = Item.displayName, id = Item.id }).ToList();
            }

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