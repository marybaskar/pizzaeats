using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LUIS_pizzaorder.Models
{
    [MetadataType(typeof(userMetaData))]
    public partial class user
    {
        public string comfirmpassword { get; set; }
    }

    public class userMetaData
    {
        const string errorString = "Feild is required";


        public int user_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Minimum 6 characters required")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Confirm password ad password do not match")]
        public string comfirmpassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}