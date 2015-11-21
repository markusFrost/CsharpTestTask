using CsharpTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpTestTask.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Сlient item)
        {
            if (ModelState.IsValid)
            {
                item.DateCreate = getNowTimeInMillisecond();


                ViewBag.Message = "Successfully Registration Done!";
            }
            return View(item);
        }

        public static long getNowTimeInMillisecond()
        {
             DateTime now = DateTime.Now;
            DateTime old = new DateTime(1970, 1, 1);
            TimeSpan t = now - old;
            long timestamp = (long)t.TotalMilliseconds;
            return timestamp;
        }


    }
}
