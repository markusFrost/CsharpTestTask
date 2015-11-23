using CsharpTestTask.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using CsharpTestTask.Helper;

namespace CsharpTestTask.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        //----Register Client ---------
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
                item.DateCreate = FakeCreator.getDateTimeByMills(FakeCreator.getNowTimeInMillisecond());

                long time = FakeCreator.getTimeInMillisecond(item.DateOfLastCall);

                string dateString = FakeCreator.getDateTimeByMills(time);

                ViewBag.Message = "Successfully Registration Done!";
            }
            return View(item);
        }
        //----Register Client ---------


        //----Register Contact Person ---------
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
        //----Register Contact Person ---------

        //----Edit Client ---------     
        public ActionResult EditClient(long id)
        {
            Сlient item = FakeCreator.getClientById(id);

            return View(item);
        }

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
        //----Edit Client ---------

        //----Edit Contact Person ---------
        public ActionResult EditContactPerson(long id)
        {
            return View(FakeCreator.getContactPersonById(id));
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
        //----Edit Contact Person ---------

        //------ Delete 
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
        //------ Delete 


        public ActionResult getUsers(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(FakeCreator.generateUsers().ToPagedList(pageNumber, pageSize));
        }



        //-------------------------

      

        //-------------------------


       

    }
}
