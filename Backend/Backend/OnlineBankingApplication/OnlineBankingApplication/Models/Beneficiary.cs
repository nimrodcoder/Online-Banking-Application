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
    
    public partial class Beneficiary
    {
        public string Name { get; set; }
        public long BenAccountNumber { get; set; }
        public string NickName { get; set; }
        public Nullable<long> UserAccountNumber { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
    }
}