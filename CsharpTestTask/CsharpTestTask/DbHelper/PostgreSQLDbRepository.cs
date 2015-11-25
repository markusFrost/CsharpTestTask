using CsharpTestTask.Helper;
using CsharpTestTask.Models;
using CsharpTestTask.Models.Enums;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CsharpTestTask.Controllers.DbHelper
{
    public class PostgreSQLDbRepository
    {
       static  PostgreSQLDbRepository instance;

        public static  PostgreSQLDbRepository getInstance()
        {
            if (instance == null)
            {
                instance = new PostgreSQLDbRepository();
            }
            return instance;
        }

        private PostgreSQLDbRepository()
        {

        }

        static NpgsqlConnection conection;
        private static NpgsqlConnection getConection()
        {
            string connect_string = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=ClientDb;";

            if (conection == null)
            {
                conection = new NpgsqlConnection(connect_string);
            }

            return conection;
        }

        public List<UserDto> getAllUsersByFilter(string dealState)
        {
            int position = 0;
            Int32.TryParse(dealState, out position);

            List<UserDto> list = new List<UserDto>();
            UserDto item = null;

            string query = "SELECT  " +
  "clients_table.client_name as cl_name,  " +
  "clients_table.work_phone as cl_phone,  " +
  "clients_table.addres_web_site as cl_addres, " +
  "clients_table.date_of_last_call as cl_date_calt_call,  " +
  "clients_table.date_create as cl_date_create,  " +
  "clients_table.deal_state as cl_deal_state,  " +
  "clients_table.id as cl_id,  " +
  "clients_table.contact_person_id as cl_cp_id,  " +
  "contact_person.first_name as cp_surname ,   " +
  "contact_person.cf_name as cp_name ,   " +
  "contact_person.patronymic as cp_patronomyc ,  " +
  "contact_person.workphone as cp_workphone ,  " +
  "contact_person.mobile_phone as cp_mobile_phone ,  " +
  "contact_person.email as cp_email ,  " +
  "contact_person.id as cp_id  " +
"FROM  " +
  "public.clients_table, " +
  "public.contact_person " +
"WHERE  " +
  "(clients_table.contact_person_id = contact_person.id) " +
  " and (clients_table.deal_state = " + position + ");";

          

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    // item = reader[""].ToString(); 
                    //item = Convert.ToInt64(reader[""].ToString()); 
                    item = new UserDto();

                    item.ClientAdressWebSite = reader["cl_addres"].ToString();
                    item.ClientDateCreate = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_create"].ToString()));
                    item.ClientDateOfLastCall = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_calt_call"].ToString()));
                    item.ClientDealState = SimpleHeper.getDealStatusByPosition(Convert.ToInt32(reader["cl_deal_state"].ToString()));
                    item.ClientId = Convert.ToInt64(reader["cl_id"].ToString());
                    item.ClientName = reader["cl_name"].ToString();
                    item.ClientPhone = reader["cl_phone"].ToString();
                    item.ContactPersonEmail = reader["cp_email"].ToString();
                    item.ContactPersonId = Convert.ToInt64(reader["cp_id"].ToString());
                    item.ContactPersonMobilePhone = reader["cp_mobile_phone"].ToString();
                    item.ContactPersonName = reader["cp_name"].ToString();
                    item.ContactPersonPatronymic = reader["cp_patronomyc"].ToString();
                    item.ContactPersonSurname = reader["cp_surname"].ToString();
                    item.ContactPersonWorkPhone = reader["cp_workphone"].ToString();

                    list.Add(item);
                }
                catch { }

            }
            con.Close();
            return list; ;


        }

        public List<UserDto> getAllUsers(SortType? sortType)
        {
            List<UserDto> list = new List<UserDto>();
            UserDto item = null;

            string query = "SELECT  " +
  "clients_table.client_name as cl_name,  " +
  "clients_table.work_phone as cl_phone,  " +
  "clients_table.addres_web_site as cl_addres, " +
  "clients_table.date_of_last_call as cl_date_calt_call,  " +
  "clients_table.date_create as cl_date_create,  " +
  "clients_table.deal_state as cl_deal_state,  " +
  "clients_table.id as cl_id,  " +
  "clients_table.contact_person_id as cl_cp_id,  " +
  "contact_person.first_name as cp_surname ,   " +
  "contact_person.cf_name as cp_name ,   " +
  "contact_person.patronymic as cp_patronomyc ,  " +
  "contact_person.workphone as cp_workphone ,  " +
  "contact_person.mobile_phone as cp_mobile_phone ,  " +
  "contact_person.email as cp_email ,  " +
  "contact_person.id as cp_id  " +
"FROM  " +
  "public.clients_table, " +
  "public.contact_person " +
"WHERE  " +
  "clients_table.contact_person_id = contact_person.id ";

            if (sortType == SortType.ClientName)
            {
                query += " order by clients_table.client_name";
            }
            else if (sortType == SortType.DateOfLastCall)
            {
                query += " order by clients_table.date_of_last_call";
            }
            else
            {
                query += ";";
            }

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    // item = reader[""].ToString(); 
                    //item = Convert.ToInt64(reader[""].ToString()); 
                    item = new UserDto();

                    item.ClientAdressWebSite = reader["cl_addres"].ToString();
                    item.ClientDateCreate = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_create"].ToString()));
                    item.ClientDateOfLastCall = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_calt_call"].ToString()));
                    item.ClientDealState = SimpleHeper.getDealStatusByPosition(Convert.ToInt32(reader["cl_deal_state"].ToString()));
                    item.ClientId = Convert.ToInt64(reader["cl_id"].ToString());
                    item.ClientName = reader["cl_name"].ToString();
                    item.ClientPhone = reader["cl_phone"].ToString();
                    item.ContactPersonEmail = reader["cp_email"].ToString();
                    item.ContactPersonId = Convert.ToInt64(reader["cp_id"].ToString());
                    item.ContactPersonMobilePhone = reader["cp_mobile_phone"].ToString();
                    item.ContactPersonName = reader["cp_name"].ToString();
                    item.ContactPersonPatronymic = reader["cp_patronomyc"].ToString();
                    item.ContactPersonSurname = reader["cp_surname"].ToString();
                    item.ContactPersonWorkPhone = reader["cp_workphone"].ToString();

                    list.Add(item);
                }
                catch { }

            }
            con.Close();
            return list; ;


        }




        public List<UserDto> getAllUsers()
        {

            List<UserDto> list = new List<UserDto>();
            UserDto item = null;

            string query = "SELECT  " +
  "clients_table.client_name as cl_name,  " +
  "clients_table.work_phone as cl_phone,  " +
  "clients_table.addres_web_site as cl_addres, " +
  "clients_table.date_of_last_call as cl_date_calt_call,  " +
  "clients_table.date_create as cl_date_create,  " +
  "clients_table.deal_state as cl_deal_state,  " +
  "clients_table.id as cl_id,  " +
  "clients_table.contact_person_id as cl_cp_id,  " +
  "contact_person.first_name as cp_surname ,   " +
  "contact_person.cf_name as cp_name ,   " +
  "contact_person.patronymic as cp_patronomyc ,  " +
  "contact_person.workphone as cp_workphone ,  " +
  "contact_person.mobile_phone as cp_mobile_phone ,  " +
  "contact_person.email as cp_email ,  " +
  "contact_person.id as cp_id  " +
"FROM  " +
  "public.clients_table, " +
  "public.contact_person " +
"WHERE  " +
  "clients_table.contact_person_id = contact_person.id; ";

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    // item = reader[""].ToString(); 
                    //item = Convert.ToInt64(reader[""].ToString()); 
                    item = new UserDto();

                    item.ClientAdressWebSite = reader["cl_addres"].ToString();
                    item.ClientDateCreate = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_create"].ToString()));
                    item.ClientDateOfLastCall = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["cl_date_calt_call"].ToString()));
                    item.ClientDealState = SimpleHeper.getDealStatusByPosition(Convert.ToInt32(reader["cl_deal_state"].ToString()));
                    item.ClientId = Convert.ToInt64(reader["cl_id"].ToString());
                    item.ClientName = reader["cl_name"].ToString();
                    item.ClientPhone = reader["cl_phone"].ToString();
                    item.ContactPersonEmail = reader["cp_email"].ToString();
                    item.ContactPersonId = Convert.ToInt64(reader["cp_id"].ToString());
                    item.ContactPersonMobilePhone = reader["cp_mobile_phone"].ToString();
                    item.ContactPersonName = reader["cp_name"].ToString();
                    item.ContactPersonPatronymic = reader["cp_patronomyc"].ToString();
                    item.ContactPersonSurname = reader["cp_surname"].ToString();
                    item.ContactPersonWorkPhone = reader["cp_workphone"].ToString();

                    list.Add(item);
                }
                catch { }

            }
            con.Close();
            return list; ;


        }

        public List<Сlient> getAllСlients()
        {
            List<Сlient> list = new List<Сlient>();
            Сlient item = null;


            string query = "SELECT client_name, work_phone, addres_web_site, date_of_last_call, " +
                            " date_create, deal_state, id, contact_person_id " +
                            " FROM clients_table;";

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    //string result = reader["cf_name"].ToString();//Получаем значение из второго столбца! Первый это (0)!
                    item = new Сlient();
                    item.AdressWebSite = reader["addres_web_site"].ToString();
                    item.ContactPersonId = Convert.ToInt64(reader["contact_person_id"].ToString());
                    item.DateCreate = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["date_create"].ToString()));
                    item.DateOfLastCall = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["date_of_last_call"].ToString()));
                    item.DealState = SimpleHeper.getDealStatusByValue(Convert.ToInt32(reader["deal_state"].ToString()));
                    item.Name = reader["client_name"].ToString();
                    item.Phone = reader["work_phone"].ToString();
                    item.Id = Convert.ToInt64(reader["id"].ToString());
                    // item = reader[""].ToString();    
                    list.Add(item);
                }
                catch { }

            }
            con.Close();
            return list; ;
        }

        public Сlient getСlientById(long id)
        {
            Сlient item = null;


            string query = "SELECT client_name, work_phone, addres_web_site, date_of_last_call, " +
                            " date_create, deal_state, id, contact_person_id " +
                            " FROM clients_table where id=" + id + ";";

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    //string result = reader["cf_name"].ToString();//Получаем значение из второго столбца! Первый это (0)!
                    item = new Сlient();
                    item.AdressWebSite = reader["addres_web_site"].ToString();
                    item.ContactPersonId = Convert.ToInt64(reader["contact_person_id"].ToString());
                    item.DateCreate = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["date_create"].ToString()));
                    item.DateOfLastCall = SimpleHeper.getDateTimeByMills(Convert.ToInt64(reader["date_of_last_call"].ToString()));
                    item.DealState = SimpleHeper.getDealStatusByValue(Convert.ToInt32(reader["deal_state"].ToString()));
                    item.Name = reader["client_name"].ToString();
                    item.Phone = reader["work_phone"].ToString();
                    item.Id = id;
                    // item = reader[""].ToString();    
                }
                catch { }

            }
            con.Close();
            return item;
        }

        public void deleteClient(long id)
        {
            string query = "DELETE FROM clients_table " +
               " WHERE " + "id=" + id + "; "; ;

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();

            reader.Close();

            con.Close();

        }


        public bool UpdateClient(Сlient item)
        {
            bool isSucces = false;

            string query = "UPDATE clients_table " +
            " SET client_name= " + "'" + item.Name + "'" + " , " +
            " work_phone= " + "'" + item.Phone + "'" + " , " +
            " addres_web_site= " + "'" + item.AdressWebSite + "'" + " , " +
            " date_of_last_call= " + SimpleHeper.getTimeInMillisecond(item.DateOfLastCall) + " , " +
            " date_create= " + SimpleHeper.getTimeInMillisecond(item.DateCreate) + " , " +
            " deal_state= " + SimpleHeper.getDealStaus(item.DealState) + " , " +
            " contact_person_id= " + item.ContactPersonId + " " +
            " WHERE id=" + item.Id + ";";

            try
            {
                NpgsqlConnection con = getConection();

                NpgsqlCommand com = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();

                reader.Close();

                con.Close();

                isSucces = true;
            }
            catch { isSucces = false; }

            return isSucces;
        }

        public bool AddClient(Сlient item)
        {
            bool isSucces = false;

            string query = "INSERT INTO clients_table( " +
                           " client_name, work_phone, addres_web_site, date_of_last_call, " +
                           "  date_create, deal_state,  contact_person_id) " +
                           " VALUES (" + "'" + item.Name + "'" + " , " + "'" + item.Phone + "'" + " , " +
                           "'" + item.AdressWebSite + "'" + " , " + SimpleHeper.getTimeInMillisecond(item.DateOfLastCall) + " , " +
                           SimpleHeper.getTimeInMillisecond(item.DateCreate) + " , " + SimpleHeper.getDealStaus(item.DealState) + " , " +
                           item.ContactPersonId + " );";

            try
            {
                NpgsqlConnection con = getConection();

                NpgsqlCommand com = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();

                reader.Close();

                con.Close();

                isSucces = true;
            }
            catch { isSucces = false; }

            return isSucces;
        }

        //--Contact Person

        public List<ContactPerson> getAllContactPersons()
        {
            List<ContactPerson> list = new List<ContactPerson>();

            ContactPerson item = null;

            string query = "SELECT first_name, cf_name, patronymic, workphone, mobile_phone, email, id " +
                          " FROM contact_person " + ";";

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    item = new ContactPerson();
                    item.Email = reader["email"].ToString();
                    item.MobilePhone = reader["mobile_phone"].ToString();
                    item.Name = reader["cf_name"].ToString();
                    item.Patronymic = reader["patronymic"].ToString();
                    item.Phone = reader["workphone"].ToString();
                    item.Surname = reader["first_name"].ToString();
                    //item = reader[""].ToString();
                    item.Id = Convert.ToInt64(reader["id"].ToString());
                    list.Add(item);
                }
                catch { }

            }
            con.Close();

            return list;

        }

        public ContactPerson getContactPersonById(long id)
        {
            ContactPerson item = null;

            string query = "SELECT first_name, cf_name, patronymic, workphone, mobile_phone, email " +
                           " FROM contact_person where id=" + id + ";";

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    item = new ContactPerson();
                    item.Email = reader["email"].ToString();
                    item.MobilePhone = reader["mobile_phone"].ToString();
                    item.Name = reader["cf_name"].ToString();
                    item.Patronymic = reader["patronymic"].ToString();
                    item.Phone = reader["workphone"].ToString();
                    item.Surname = reader["first_name"].ToString();
                    //item = reader[""].ToString();
                    item.Id = id;
                }
                catch { }

            }
            con.Close();

            return item;

        }

        public void DeleteContactPerson(long id)
        {
            string query = "DELETE FROM contact_person " +
                " WHERE " + "id=" + id + "; "; ;

            NpgsqlConnection con = getConection();

            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();

            reader.Close();

            con.Close();
        }

        public bool UpdateContactPerson(ContactPerson item)
        {
            bool isSucces = false;

            string query = "UPDATE contact_person " +
  " SET first_name=" + "'" + item.Surname + "'" + " , " +
            " cf_name= " + "'" + item.Name + "'" + " , " +
            " patronymic= " + "'" + item.Patronymic + "'" + " , " +
           " workphone= " + "'" + item.Phone + "'" + " , " +
           " mobile_phone= " + "'" + item.MobilePhone + "'" + " , " +
      " email= " + "'" + item.Email + "'" + "  " +
 " WHERE " + "id=" + item.Id + "; ";

            try
            {
                NpgsqlConnection con = getConection();

                NpgsqlCommand com = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();

                reader.Close();

                con.Close();

                isSucces = true;
            }
            catch { isSucces = false; }

            return isSucces;

        }


        public bool AddContactPerson(ContactPerson item)
        {
            bool isSucces = false;

            string query = "INSERT INTO contact_person( " +
            " first_name, cf_name, patronymic, workphone, mobile_phone, email ) " +
   " VALUES ( " +
                    "'" + item.Surname + "'" + " , " + "'" + item.Name + "'" + " , " +
                    "'" + item.Patronymic + "'" + " , " + "'" + item.Phone + "'" + " , " +
                    "'" + item.MobilePhone + "'" + " , " + "'" + item.Email + "'" +
            ");";

            try
            {
                NpgsqlConnection con = getConection();

                NpgsqlCommand com = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader reader;

                reader = com.ExecuteReader();

                reader.Close();

                con.Close();
                isSucces = true;
            }
            catch { isSucces = false; }

            return isSucces;

        }

        public List<SelectListItem> getNameContactFace( long id)
        {
            List<SelectListItem> list = new List<SelectListItem>();


            List<ContactPerson> listPersons = getAllContactPersons();

            listPersons.RemoveAll((x) => x.Id == id); 

            listPersons.Insert(0,  getContactPersonById(id)); // we need to remove it and set to first position

            foreach (ContactPerson item in listPersons)
            {
                    string value = item.Surname + " " + item.Name + " " + item.Patronymic;
                
                    list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            }

            return list;
        }

        public  List<SelectListItem> getNameContactFace()
        {
            List<SelectListItem> list = new List<SelectListItem>();


            List<ContactPerson> listPersons = getAllContactPersons();

            foreach (ContactPerson item in listPersons)
            {
                string value = item.Surname + " " + item.Name + " " + item.Patronymic;
                list.Add(new SelectListItem { Value = item.Id + "", Text = value });
            }
          
            return list;
        }




        
    }
}
