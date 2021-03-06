﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CsharpTestTask.Models
{
    public class ContactPerson
    {
        public long Id {get; set;}
        
        [Required (ErrorMessage="Please enter surname", AllowEmptyStrings=false) ]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter name", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter patronymic", AllowEmptyStrings = false)]
        public string Patronymic { get; set; }

        [RegularExpression(@"[\+\d]\d+",
                   ErrorMessage = "Invalid  work phone number")]
        [Required(ErrorMessage = "Please enter work phone", AllowEmptyStrings = false)]
        public string Phone { get; set; }

        [RegularExpression(@"[\+\d]\d+",
                   ErrorMessage = "Invalid mobile phone number")]
        [Required(ErrorMessage = "Please enter mobile phone", AllowEmptyStrings = false)]
        public string MobilePhone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
                    ErrorMessage = "Please provide valid email")]
        [Required(ErrorMessage = "Please enter email", AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}