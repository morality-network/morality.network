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
    
    public partial class Transaction
    {
        public long Id { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public double Fee { get; set; }
        public double Amount { get; set; }
        public long CurrencyId { get; set; }
        public string TransactionHash { get; set; }
        public long UserFrom { get; set; }
        public long UserTo { get; set; }
        public string Notes { get; set; }
        public bool Confirmed { get; set; }
        public System.DateTime Timestamp { get; set; }
        public long BlockNumber { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}