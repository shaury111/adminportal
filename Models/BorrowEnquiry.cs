//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteAllAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BorrowEnquiry
    {
        public int id { get; set; }
        public string EnquiryName { get; set; }
        public string EnquiryEmail { get; set; }
        public string EnquiryPhone { get; set; }
        public string EnquiryMessage { get; set; }
        public string EnquiryLoanAmount { get; set; }
        public string EnquiryYear { get; set; }
        public Nullable<bool> fldstatus { get; set; }
        public Nullable<System.DateTime> EnquiryDate { get; set; }
        public string fldextra { get; set; }
        public string fldextra1 { get; set; }
    }
}