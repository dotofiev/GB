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
    
    public partial class TmpEmpTransaction
    {
        public string Agence { get; set; }
        public string LibAgence { get; set; }
        public string Matricule { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public string TrCode { get; set; }
        public Nullable<long> Qty { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public decimal Pk { get; set; }
    }
}