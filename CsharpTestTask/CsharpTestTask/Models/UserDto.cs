using CsharpTestTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CsharpTestTask.Models
{
    public class UserDto
    {
        public long Id { get; set; }

        public long ClientId { get; set; }

        [DisplayName("Client name")]
        public string ClientName { get; set; }

        [DisplayName("Client phone")]
        public string ClientPhone { get; set; }

        [DisplayName("Clients web site")]
        public string ClientAdressWebSite { get; set; }

        [DisplayName("Date of last call")]
        public string ClientDateOfLastCall { get; set; }

         [DisplayName("Date of Created Client")]
        public string ClientDateCreate { get; set; }

        [DisplayName("Deal State")]
         public string ClientDealState { get; set; }

        // contact person

        public long ContactPersonId { get; set; }

        [DisplayName("Surname of contact person")]
        public string ContactPersonSurname { get; set; }

        [DisplayName("Name of contact person")]
        public string ContactPersonName { get; set; }

        [DisplayName("Patronymic of contact person")]
        public string ContactPersonPatronymic { get; set; }

        [DisplayName("Work phone of contact person")]
        public string ContactPersonWorkPhone { get; set; }

        [DisplayName("MobilePhone of contact person")]
        public string ContactPersonMobilePhone { get; set; }

        [DisplayName("Email of contact person")]
        public string ContactPersonEmail { get; set; }

    }
}