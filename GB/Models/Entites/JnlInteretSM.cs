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
    
    public partial class JnlInteretSM
    {
        public string Agence { get; set; }
        public string Client { get; set; }
        public string CpteJumelle { get; set; }
        public Nullable<System.DateTime> DateIntDebut { get; set; }
        public Nullable<System.DateTime> DateIntFin { get; set; }
        public string Denomination { get; set; }
        public string Devise { get; set; }
        public System.DateTime DateOperation { get; set; }
        public decimal Series { get; set; }
        public Nullable<System.DateTime> DateCptab { get; set; }
        public string TxnNo { get; set; }
        public Nullable<double> SMSAmount { get; set; }
        public Nullable<double> SMSVATAmount { get; set; }
        public string Employe { get; set; }
    }
}
