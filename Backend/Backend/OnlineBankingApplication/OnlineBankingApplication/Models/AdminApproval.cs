//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBankingApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminApproval
    {
        public int ApprovalID { get; set; }
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public string ApprovalStatus { get; set; }
        public System.DateTime ApprovalDate { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual User User { get; set; }
    }
}
