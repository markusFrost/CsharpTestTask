using CsharpTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpTestTask.Controllers
{
    public class ContactFaceController : Controller
    {
        //
        // GET: /ContactFace/

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ContactPerson item )
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Successfully Registration Done!";
            }
            return View(item);
        }

    }
}
