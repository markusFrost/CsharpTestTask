using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CsharpTestTask.Models
{
    public class Сlient
    {
        public int Id { get; set; }

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

        
    }
}