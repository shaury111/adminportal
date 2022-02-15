using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace new_loginsystem.Models
{
    public class UserEnquiryModel
    {

        public int id { get; set; }

        [Display(Name = "Enter Your Name")]
        [Required(ErrorMessage = "Must Provide Name")]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid  Name")]
        public string fldname { get; set; }

        [Display(Name = "Enter Your Mobile")]
        [Required(ErrorMessage = "Mobile Required")]
        [DataType(DataType.PhoneNumber)]
        public string fldmobile { get; set; }


        //[Required(ErrorMessage = "Gender Required")]
        //[DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string fldgender { get; set; }

        [Display(Name = "Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Required")]
        public string fldemail { get; set; }

        [Display(Name = "Enter Your Subject")]
        [Required(ErrorMessage = "Subject Required")]


        [StringLength(50, MinimumLength = 5)]
        public string fldsubject { get; set; }
        public string fldextra { get; set; }
        public string fldextra1 { get; set; }
        public int refid { get; set; }
    }
}