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
    
    public partial class OpCaisB
    {
        public Nullable<short> Agence { get; set; }
        public string Caisse { get; set; }
        public string CpteGL { get; set; }
        public string CleCpteGL { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public int Serie { get; set; }
        public Nullable<System.DateTime> DateValeur { get; set; }
        public string CodeLibelle { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string RefOperation { get; set; }
        public string CpteCaisse { get; set; }
        public string CleCpteCaisse { get; set; }
        public Nullable<short> Employe { get; set; }
        public string LibEmploye { get; set; }
        public Nullable<double> TxIntDb { get; set; }
        public Nullable<double> TxIntCr { get; set; }
        public string Description { get; set; }
        public string CodeTaux { get; set; }
        public Nullable<System.DateTime> DateCalEI { get; set; }
        public string CodeMaj { get; set; }
        public string LibCpteGL { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
    }
}
