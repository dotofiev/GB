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
    
    public partial class CpteCltHistb
    {
        public int Agence { get; set; }
        public decimal Client { get; set; }
        public Nullable<short> CatCpte { get; set; }
        public Nullable<short> SubCpte { get; set; }
        public string LetCle { get; set; }
        public string CpteJumelle { get; set; }
        public string Denomination { get; set; }
        public string Devise { get; set; }
        public decimal Serie { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public Nullable<System.DateTime> DateValeur { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string CodeLibelle { get; set; }
        public string RefOperation { get; set; }
        public Nullable<short> Employe { get; set; }
        public string LibEmploye { get; set; }
        public Nullable<double> TxIntDb { get; set; }
        public Nullable<double> TxIntCr { get; set; }
        public string CodeTaux { get; set; }
        public Nullable<System.DateTime> DateCalEI { get; set; }
        public string LibAgence { get; set; }
        public string LibTrCode { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string TrCode { get; set; }
        public string Description { get; set; }
        public string CpteCol { get; set; }
        public string txnno { get; set; }
        public string integritystatus { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
        public string Authoriser { get; set; }
        public string validation { get; set; }
        public string NewMle { get; set; }
    }
}
