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
    
    public partial class OpCaisABi
    {
        public string Agence { get; set; }
        public string CpteClient { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public decimal Serie { get; set; }
        public Nullable<System.DateTime> DateValeur { get; set; }
        public string Devise { get; set; }
        public string CodeLibelle { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string RefOperation { get; set; }
        public string Caisse { get; set; }
        public string CpteCaisse { get; set; }
        public string CleCpteCaisse { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public Nullable<double> TxIntDb { get; set; }
        public Nullable<double> TxIntCr { get; set; }
        public string Description { get; set; }
        public string CodeTaux { get; set; }
        public Nullable<System.DateTime> DateCalEI { get; set; }
        public string CodeMaj { get; set; }
        public string LibCaisse { get; set; }
        public string LibAgence { get; set; }
        public string Denomination { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string LibDevise { get; set; }
        public string LibCpteCaisse { get; set; }
        public string CpteColClt { get; set; }
        public string CleColClt { get; set; }
        public string LibCpteColClt { get; set; }
        public Nullable<double> FraisDecouvert { get; set; }
        public Nullable<double> FraisDepot { get; set; }
        public string TxnNo { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
        public string representative { get; set; }
    }
}
