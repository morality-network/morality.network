//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RateIt.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class InternalTransaction
    {
        public long Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public decimal Value { get; set; }
        public string ExtData { get; set; }
        public System.DateTime Timestamp { get; set; }
        public Nullable<long> FromUserId { get; set; }
        public long ToUserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
