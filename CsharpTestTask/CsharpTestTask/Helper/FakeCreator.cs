﻿using CsharpTestTask.Models;
using CsharpTestTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpTestTask.Helper
{
    public class FakeCreator
    {

        public  static  string[] statesArray = { "First Contact", "Conversation", "Harmonization Of Contract", "Cooperation" };

        public static string getContactPersonNamebyId( long id )
        {
            List<ContactPerson> list = getContactPersons();

            var persons = from item in list
                         where item.Id == id
                         select item;
            ContactPerson cp = persons.ToList<ContactPerson>().First<ContactPerson>();

            return " " + cp.Surname + " " + cp.Name + " " + cp.Patronymic;
        }

        public static List<ContactPerson> getContactPersons()
        {
            List<ContactPerson> list = new List<ContactPerson>();

            ContactPerson item = null;

            for (int i = 0; i < 50; i++)
            {
                item = new ContactPerson();
                item.Email = "andreywystawkin@yandex.ru";
                item.Id = i;
                item.MobilePhone = "89158893604";
                item.Name = "Name " + i;
                item.Patronymic = "Patronymic " + i;
                item.Phone = "89156784309";
                item.Surname = "Surname " + i;

                list.Add(item);
            }

            return list;
        }

        public static List<Сlient> getСlientsByCp_id( long cp_id)
        {
            List<Сlient> list = getСlients();



            var clients = from client in list
                          where client.ContactPersonId == cp_id
                          select client;

            return clients.ToList<Сlient>();
        }

        public static List<Сlient> getСlients()
        {
            List<Сlient> list = new List<Сlient>();

            Сlient item = null;

            for (int i = 0; i <= 50; i++)
            {
                item = new Сlient();
                item.AdressWebSite = "http://vk.com/id53074293";
                item.ContactPersonId = i % 4;
                item.DateCreate = "11/21/2015";
                item.DateOfLastCall = "11/22/2015";
                item.DealState = SimpleHeper.getDealStatusByValue(i % 4);
                item.Id = i;
                item.Name = "Name " + i;
                item.Phone = "Phone " + i;

                list.Add(item);

            }

            return list;
        }

        public static List<UserDto> getUsersBySortType(SortType sortType)
        {
            List<UserDto> list = generateUsers();

            if (sortType == SortType.ClientName)
            {
                list.Sort((emp1, emp2) => emp1.ClientName.CompareTo(emp2.ClientName));
            }
            else if (sortType == SortType.DateOfLastCall)
            {
                list.Sort((emp1, emp2) => emp1.ClientDateOfLastCall.CompareTo(emp2.ClientDateOfLastCall));
            }

            return list;
        }

        public static List<SelectListItem> generateDealState(DealStatus d)
        {
            

            int index = -1;
            if (d == DealStatus.FirstContact)
            {
                index = 0;
            }
            else if (d == DealStatus.Conversation)
            {
                index = 1;
            }
            else if (d == DealStatus.HarmonizationOfContract)
            {
                index = 2;
            }
            else if (d == DealStatus.Cooperation)
            {
                index = 3;
            }

            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = index + "", Text = statesArray[index] });

            int count = 1;
            for (int i = 0; i < statesArray.Length; i++)
            {
                if (i != index)
                {
                    list.Add(new SelectListItem { Value = i + "", Text = statesArray[i] });
                    count++;
                }
            }
           /* var list = new List<SelectListItem> { 
                       new SelectListItem { Value = "0" , Text = "First Contact" },
                       new SelectListItem { Value = "1" , Text = "Conversation" },
                       new SelectListItem { Value = "2" , Text = "Harmonization Of Contract" },
                       new SelectListItem { Value = "3" , Text = "Cooperation" }
                    };*/

            List<SelectListItem> array = new List<SelectListItem>(list);

            return list;
        }


        public static ContactPerson getContactPersonById(long id)
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

            for (int i = 0; i < 50; i++)
            {
                item = new UserDto();

                // fill Client
                item.ClientId = i;
                item.ClientDateCreate = "11/21/2015";
                item.ClientDateOfLastCall = "11/22/2015";
                item.ClientDealState = statesArray[i % 4]; //!!! change to string
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
                item.ContactPersonWorkPhone = i * 2 + "" + i * 7 + "" + i * 2;
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

    }
}