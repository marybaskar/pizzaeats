using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LUIS_pizzaorder.Models
{
    public class UserLogin
    {
        const string errorString = "Feild is required";

        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 6)]
        public string password { get; set; }
    }
}