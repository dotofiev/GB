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
    
    public partial class CMOpDevise
    {
        public short Agence { get; set; }
        public string Caisse { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public int Serie { get; set; }
        public string CpteClient { get; set; }
        public string Devise { get; set; }
        public string TypeOp { get; set; }
        public Nullable<double> Cours { get; set; }
        public string Imputation { get; set; }
        public Nullable<double> MtDevise { get; set; }
        public double ValCFA { get; set; }
        public Nullable<double> Commission { get; set; }
        public Nullable<double> Frais { get; set; }
        public Nullable<double> Taxe { get; set; }
        public string Ref { get; set; }
        public string CpteCaisse { get; set; }
        public string CleCpteCaisse { get; set; }
        public string Description { get; set; }
        public string CpteColClt { get; set; }
        public string CleColClt { get; set; }
        public string LibCpteColClt { get; set; }
        public string CodeMaj { get; set; }
        public Nullable<short> Employe { get; set; }
        public string Libemploye { get; set; }
        public string Motif { get; set; }
        public string LibAgence { get; set; }
        public string LibDevise { get; set; }
        public string Denomination { get; set; }
        public string LibCaisse { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string LibCpteCaisse { get; set; }
        public string CodeLibelle { get; set; }
        public System.DateTime datevals { get; set; }
        public Nullable<double> TxIntDb { get; set; }
        public Nullable<double> TxIntCr { get; set; }
        public string TxnNo { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
    }
}