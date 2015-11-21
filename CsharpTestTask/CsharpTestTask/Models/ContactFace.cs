using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsharpTestTask.Models
{
    public class ContactFace
    {
        public int Id {get; set;}

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int WorkPhone { get; set; }

        public int MobilePhone { get; set; }

        public string Email { get; set; }
    }
}