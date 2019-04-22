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
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 6)]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Confirm password and password do not match")]
        public string comfirmpassword { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string lastname { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        public string address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = errorString)]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 6)]
        public string email { get; set; }
    }
}