//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.Models.Entites
{
    using System;
    using System.Collections.Generic;
    
    public partial class PayrollAcct
    {
        public System.DateTime DateSalaire { get; set; }
        public string PayYear { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string CpteGl { get; set; }
        public string CleCpte { get; set; }
        public string LibCpteGl { get; set; }
        public string CodeMaj { get; set; }
    }
}
