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
    
    public partial class SummaryJnlPartMember
    {
        public string Agence { get; set; }
        public string LibAgence { get; set; }
        public string Client { get; set; }
        public Nullable<int> CatCpte { get; set; }
        public string CpteJumelle { get; set; }
        public string Denomination { get; set; }
        public Nullable<double> PartJan { get; set; }
        public Nullable<double> PartFev { get; set; }
        public Nullable<double> PartMar { get; set; }
        public Nullable<double> PartAvr { get; set; }
        public Nullable<double> PartMai { get; set; }
        public Nullable<double> PartJui { get; set; }
        public Nullable<double> PartJul { get; set; }
        public Nullable<double> PartAou { get; set; }
        public Nullable<double> PartSep { get; set; }
        public Nullable<double> PartOct { get; set; }
        public Nullable<double> PartNov { get; set; }
        public Nullable<double> PartDec { get; set; }
        public string devise { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public Nullable<System.DateTime> DateCptab { get; set; }
        public string TxnNo { get; set; }
        public decimal Series { get; set; }
        public string Employe { get; set; }
        public Nullable<double> Tauxint { get; set; }
        public Nullable<double> InteretAnnuelle { get; set; }
    }
}