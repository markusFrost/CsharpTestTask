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
using CsharpTestTask.Models.Enums;

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


        // Page getUsers simple pagination

        public ActionResult getUsers(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(FakeCreator.generateUsers().ToPagedList(pageNumber, pageSize));
        }


        //Sort users with pagination and sort param
        public ActionResult sortUsers(int? page, SortType? sortType)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<UserDto> list = null;
            if (sortType == null)
            {
                sortType = (SortType) System.Web.HttpContext.Current.Session["sortType"];
            }
             if (sortType == SortType.ClientName)
            {
                list = FakeCreator.getUsersBySortType(SortType.ClientName);
                System.Web.HttpContext.Current.Session["sortType"] = sortType; 
            }
            else if (sortType == SortType.DateOfLastCall)
            {
                list = FakeCreator.getUsersBySortType(SortType.DateOfLastCall);
                System.Web.HttpContext.Current.Session["sortType"] = sortType; 
            }

            return View(list.ToPagedList(pageNumber, pageSize));
        }

        
        //fielter users by deal state
        [HttpGet]
        public ActionResult fielterUsers(int? page, string dealState)
        {

            if (dealState != null)
            {
                System.Web.HttpContext.Current.Session["dealState"] = dealState; 
            }
            else
            {
                dealState = (string)System.Web.HttpContext.Current.Session["dealState"];
            }
            int position = 0;
            Int32.TryParse(dealState, out position);

            List<UserDto> list = null;
            list = FakeCreator.generateUsers();


            var users = from item in list
                        where item.ClientDealState == FakeCreator.statesArray[position]
                        select item;

            list = users.ToList<UserDto>();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View( list.ToPagedList(pageNumber, pageSize));
        }



        //-------------------------

      

        //-------------------------


       

    }
}
