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
    
    public partial class CumulCpteClthist
    {
        public decimal pk { get; set; }
        public string Agence { get; set; }
        public string CpteCol { get; set; }
        public string Devise { get; set; }
        public Nullable<double> CumulDebit { get; set; }
        public Nullable<double> CumulCredit { get; set; }
        public System.DateTime DateOperation { get; set; }
        public string CpteJumelle { get; set; }
    }
}
