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
    
    public partial class StandingOrder
    {
        public string Agence { get; set; }
        public string CpteClient { get; set; }
        public string Denomination { get; set; }
        public Nullable<double> Amount { get; set; }
        public string CorrespondentCode { get; set; }
        public string Correspondent { get; set; }
        public string CorrespondentAcct { get; set; }
        public string AccountKey { get; set; }
        public string Statut { get; set; }
        public Nullable<System.DateTime> DateDemarrage { get; set; }
        public Nullable<System.DateTime> DateRenovellement { get; set; }
        public string DateCreation { get; set; }
        public Nullable<System.DateTime> DateModif { get; set; }
        public string Reference { get; set; }
        public string LibAgence { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public string TypeVir { get; set; }
        public string LibLiaison { get; set; }
        public string Liaison { get; set; }
        public int Serie { get; set; }
        public string Companyname { get; set; }
        public string matrisalaire { get; set; }
        public string institutiontype { get; set; }
        public string TxnNo { get; set; }
        public Nullable<System.DateTime> datederniervir { get; set; }
        public string CpteGl { get; set; }
        public string Clecpte { get; set; }
        public string LibcpteGl { get; set; }
        public string TraitSalaire { get; set; }
    }
}