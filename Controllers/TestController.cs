using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerPortal.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            if (model.FirstName == model.LastName)
            {
                ModelState.AddModelError("LastName", "The last name cannot be the same as the first name.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Succsess");
        }

    }
}