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

        [Required(ErrorMessage = "Please enter work phone", AllowEmptyStrings = false)]
        public string Phone { get; set; }

        [RegularExpression(@"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$",
                    ErrorMessage = "Please provide valid addres of website")]
        [Required(ErrorMessage = "Please enter addres of website", AllowEmptyStrings = false)]
        public string AdressWebSite { get; set; }

        public long DateOfLastCall { get; set; }

        public long DateCreate { get; set; }

        public DealStatus DealState { get; set; }

        [DisplayName("Id of Contact Face")]
        [Required(ErrorMessage = "Please enter id of contact face", AllowEmptyStrings = false)]
        public string ContactFaceId { get; set; }
    }
}