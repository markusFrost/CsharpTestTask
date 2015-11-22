﻿using CsharpTestTask.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

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


        public ActionResult getUsers(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(generateUsers().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EditClient(long id)
        {           
            return View( getClientById(id) );
        }

        public ActionResult EditContactPerson(long id)
        {
            return View(getContactPersonById(id));
        }

        //------- [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(Сlient item)
        {
            if (ModelState.IsValid)
            {
                // problem = datecreate and spinners
                ViewBag.Message = "Client was sucessfull updated!";
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContactPerson(ContactPerson item)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Contact person was sucessfull updated!";
            }
            return View(item);
        }

        //------ [HttpPost]

        public ActionResult DeleteClient(long id)
        {
            //use id of client it is very simple to delete it
            return View();
        }

        public ActionResult DeleteContactPerson(long id)
        {
            //use id of contact person it is very simple to delete it
            return View();
        }





        //-------------------------

        public static ContactPerson getContactPersonById( long id )
        {
            ContactPerson item = new ContactPerson();

            UserDto user = generateUsers()[(int)id];

            item.Id = id;
            item.Email = "andreywystawkin@gmail.com";
            item.MobilePhone = user.ContactPersonMobilePhone;
            item.Name = user.ContactPersonName;
            item.Patronymic = user.ContactPersonPatronymic;
            item.Phone = user.ContactPersonWorkPhone;
            item.Surname = user.ContactPersonSurname;

            return item;
        }

        public static Сlient getClientById(long id)
        {
            Сlient item = new Сlient();

            UserDto user = generateUsers()[(int)id];
            // need to get id from contact person
            // it will be simple because realy it will become from DB
            item.AdressWebSite = "http://www.cold-corp.com/";
            item.Id = id;
            item.DateCreate = user.ClientDateCreate;
            item.DateOfLastCall = user.ClientDateOfLastCall;
            item.DealState = Models.Enums.DealStatus.Cooperation;
            item.Name = user.ClientName;
            item.Phone = user.ClientPhone;

            return item;
        }

        public static List<UserDto> generateUsers()
        {

            List<UserDto> list = new List<UserDto>();

            UserDto item;

            for ( int i = 0; i < 50; i++)
            {
                item = new UserDto();

                // fill Client
                item.ClientId = i;
                item.ClientDateCreate = "11/21/2015";
                item.ClientDateOfLastCall = "11/22/2015";
                item.ClientDealState = "deal " + i; //!!! change to string
                item.Id = i;
                item.ClientName = "Name" + " " + i;
                item.ClientPhone = i + "" + i + "" + i + "" + i;
                item.ClientAdressWebSite = "Adress " + i;


                //fill contact face
                item.ContactPersonId = i;
                item.ContactPersonEmail = "email " + i;
                item.ContactPersonMobilePhone = i * 2 + "" + i * 3 + "" + i * 7 + "" + i * 2;
                item.ContactPersonName = "CPName " + i;
                item.ContactPersonPatronymic = "Patronomyc " + i;
                item.ContactPersonSurname = "CPSurname " + i;
                item.ContactPersonWorkPhone = i * 2 + "" +  i * 7 + "" + i * 2;
                list.Add(item);
            }
            return list;
        }

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
