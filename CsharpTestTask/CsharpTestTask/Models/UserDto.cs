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
        [DisplayName("Client name")]
        public string ClientName { get; set; }

        [DisplayName("Client phone")]
        public string Phone { get; set; }

        [DisplayName("Clients web site")]     
        public string AdressWebSite { get; set; }

        [DisplayName("Date of last call")]
        public string DateOfLastCall { get; set; }

         [DisplayName("Date of Created Client")]
        public string DateCreate { get; set; }

        [DisplayName("Deal State")]
        public DealStatus DealState { get; set; }

        // contact person

        [DisplayName("Surname of contact person")]
        public string Surname { get; set; }

        [DisplayName("Name of contact person")]
        public string Name { get; set; }

        [DisplayName("Patronymic of contact person")]
        public string Patronymic { get; set; }

        [DisplayName("work phone of contact person")]
        public string WorkPhone { get; set; }

        [DisplayName("MobilePhone of contact person")]
        public string MobilePhone { get; set; }

        [DisplayName("Email of contact person")]
        public string Email { get; set; }

    }
}