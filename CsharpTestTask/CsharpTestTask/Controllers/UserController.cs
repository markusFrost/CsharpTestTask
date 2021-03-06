﻿using CsharpTestTask.Models;
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
using CsharpTestTask.Controllers.DbHelper;

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
               bool isSucces = PostgreSQLDbRepository.getInstance().AddClient(item);
                if (isSucces)
                {
                    ViewBag.SuccesMessage = "Successfully Registration Done!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Can not save user to database!";
                }
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
               bool isSucces =   PostgreSQLDbRepository.getInstance().AddContactPerson(item);

               if (isSucces)
               {
                   ViewBag.SuccesMessage = "Successfully Registration Done!";
               }
               else
               {
                   ViewBag.ErrorMessage = "Can not save user to database!";
               }
            }
            return View(item);
        }
        //----Register Contact Person ---------

        //----Edit Client ---------     
        public ActionResult EditClient(long id)
        {
            Сlient item = PostgreSQLDbRepository.getInstance().getСlientById(id);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(Сlient item)
        {
            if (ModelState.IsValid)
            {
                bool isSucces = PostgreSQLDbRepository.getInstance().UpdateClient(item);

                if (isSucces)
                {
                    ViewBag.SuccesMessage = "Client was sucessfull updated!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Can not update user into database!";
                }
            }
            return View(item);
        }
        //----Edit Client ---------

        //----Edit Contact Person ---------
        public ActionResult EditContactPerson(long id)
        {
            return View(PostgreSQLDbRepository.getInstance().getContactPersonById(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContactPerson(ContactPerson item)
        {
            if (ModelState.IsValid)
            {
                bool isSucces = PostgreSQLDbRepository.getInstance().UpdateContactPerson(item);

                if (isSucces)
                {
                    ViewBag.SuccesMessage = "Contact person was sucessfull updated!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Can not update user into database!";
                }
            }
            return View(item);
        }
        //----Edit Contact Person ---------

        //------ Delete 
        public ActionResult DeleteClient(long id)
        {
            bool isSucces = PostgreSQLDbRepository.getInstance().deleteClient(id);

            if (isSucces)
            {
                ViewBag.SuccesMessage = "Client was sucessfull deleted";
            }
            else
            {
                ViewBag.ErrorMessage = "Can not delete user!";
            }

            return View();
        }

        public ActionResult DeleteContactPerson(long id)
        {
            bool isSucces = PostgreSQLDbRepository.getInstance().deleteContactPerson(id);

            if (isSucces)
            {
                ViewBag.SuccesMessage = "Contact person was sucessfull deleted";
            }
            else
            {
                ViewBag.ErrorMessage = "Contact person was not deleted!";
            }
            return View();
        }
        //------ Delete 


        // Page getUsers simple pagination

        public ActionResult getUsers(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(PostgreSQLDbRepository.getInstance().getAllUsers().ToPagedList(pageNumber, pageSize));
        }

        //Page get client
        public ActionResult getClients(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(PostgreSQLDbRepository.getInstance().getAllСlients().ToPagedList(pageNumber, pageSize));
        }

        //Page get client by contact_person id
        public ActionResult getClientsByCp_id(int? page, int cp_id)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(PostgreSQLDbRepository.getInstance().getAllСlientsByContPersonId(cp_id).ToPagedList(pageNumber, pageSize));
        }

        //Page get contact persons
        public ActionResult getContactPersons(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(PostgreSQLDbRepository.getInstance().getAllContactPersons().ToPagedList(pageNumber, pageSize));
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
                list = PostgreSQLDbRepository.getInstance().getAllUsers(sortType);
                System.Web.HttpContext.Current.Session["sortType"] = sortType; 
            }
            else if (sortType == SortType.DateOfLastCall)
            {
                list = PostgreSQLDbRepository.getInstance().getAllUsers(sortType);
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


            List<UserDto> list = null;
            list = PostgreSQLDbRepository.getInstance().getAllUsersByFilter(dealState);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View( list.ToPagedList(pageNumber, pageSize));
        }



        //-------------------------

      

        //-------------------------


       

    }
}
