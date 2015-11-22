using CsharpTestTask.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpTestTask.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        //RegisterClient
        public ActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterClient(Сlient item)
        {
            if (ModelState.IsValid)
            {
                item.DateCreate = getDateTimeByMills(getNowTimeInMillisecond());

                long time = getTimeInMillisecond(item.DateOfLastCall);

                string dateString = getDateTimeByMills(time);

                ViewBag.Message = "Successfully Registration Done!";
            }
            return View(item);
        }

        public ActionResult RegisterContactPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterContactPerson(ContactPerson item)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Successfully Registration Done!";
            }
            return View(item);
        }

        //-------------------------

        public static List<SelectListItem> generateContactFace()
        {
            //List<ContactFace> list = new List<ContactFace>();

            List<SelectListItem> list = new List<SelectListItem>();

            ContactPerson item;

            item = new ContactPerson();
            item.Id = 1;
            item.Name = "John";
            item.Surname = "Smith";
            item.Patronymic = "Tom";

            string value = item.Surname + " " + item.Name + " " + item.Patronymic;
            list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            //--------------------
            item = new ContactPerson();
            item.Id = 2;
            item.Name = "Mark";
            item.Surname = "Walker";
            item.Patronymic = "James";

            value = item.Surname + " " + item.Name + " " + item.Patronymic;
            list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            //--------------------
            item = new ContactPerson();
            item.Id = 3;
            item.Name = "Peter";
            item.Surname = "Craw";
            item.Patronymic = "Appach";

            value = item.Surname + " " + item.Name + " " + item.Patronymic;
            list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            //--------------------
            item = new ContactPerson();
            item.Id = 4;
            item.Name = "Gray";
            item.Surname = "Pears";
            item.Patronymic = "Sam";

            value = item.Surname + " " + item.Name + " " + item.Patronymic;
            list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            //--------------------

            return list;
        }

        public static string getDateTimeByMills(long time)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(time).ToLocalTime();

            return date.ToString("MM/dd/yyyy").Replace(".", "/");
        }

        public static long getTimeInMillisecond(string value)
        {
            string[] formats = { "MM/dd/yyyy" };
            var time = DateTime.ParseExact(value, formats, new CultureInfo("en-US"), DateTimeStyles.None);

            DateTime old = new DateTime(1970, 1, 1);
            TimeSpan t = time - old;
            long timestamp = (long)t.TotalMilliseconds;
            return timestamp;
        }

        public static long getNowTimeInMillisecond()
        {
            DateTime now = DateTime.Now;
            DateTime old = new DateTime(1970, 1, 1);
            TimeSpan t = now - old;
            long timestamp = (long)t.TotalMilliseconds;
            return timestamp;
        }


        //-------------------------


       

    }
}
