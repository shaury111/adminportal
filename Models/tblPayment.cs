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
    
    public partial class tblPayment
    {
        public int id { get; set; }
        public Nullable<int> cid { get; set; }
        public string InvTitle { get; set; }
        public string InvDesc { get; set; }
        public Nullable<System.DateTime> PublishedDate { get; set; }
        public string InvDocument { get; set; }
        public Nullable<bool> invStatus { get; set; }
        public string fldextra { get; set; }
        public string fldextra1 { get; set; }
        public string fldextra2 { get; set; }
    
        public virtual UserDetail UserDetail { get; set; }
    }
}
