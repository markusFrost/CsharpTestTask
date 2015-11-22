using CsharpTestTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CsharpTestTask.Models
{
    public class Сlient
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter name", AllowEmptyStrings = false)]
        public string Name { get; set; }

       // [Required(ErrorMessage = "Please enter work phone", AllowEmptyStrings = false)]
        public string Phone { get; set; }

        [DisplayName("Addres of web site")]
        [RegularExpression(@"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$",
                    ErrorMessage = "Please provide valid addres of website")]
        [Required(ErrorMessage = "Please enter addres of website", AllowEmptyStrings = false)]
        public string AdressWebSite { get; set; }

        [DisplayName("Date of last call")]
        public string DateOfLastCall { get; set; }

        [DisplayName("Deal State")]
        public string DateCreate { get; set; }

        public DealStatus DealState { get; set; }

        [DisplayName("Contact face name")]
        public long ContactPersonId { get; set; }
    }
}