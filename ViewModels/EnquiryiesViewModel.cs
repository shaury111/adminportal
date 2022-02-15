using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCMS.Models
{
    public class EnquiryiesViewModel
    {
        public int id { get; set; }

        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Email Id")]
        public string Customer_Email { get; set; }

        [Display(Name = "Phone Number")]
        public string Customer_phone { get; set; }

        [Display(Name = "Monthly Income")]
        public string customer_monthly_Income { get; set; }

        [Display(Name = "Invest Amount")]
        public string invest_amount { get; set; }

        [Display(Name = "City")]
        public string CurentCity { get; set; }

        [Display(Name = "State")]
        public string stateresidance { get; set; }

        [Display(Name = "Apply For")]
        public string ApplyFor { get; set; }


        [Display(Name = "Date")]
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string fldextra { get; set; }
        public string fldextra2 { get; set; }
        public string fldextra1 { get; set; }

    }
}
