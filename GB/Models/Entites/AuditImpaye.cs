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
    
    public partial class AuditImpaye
    {
        public string Agence { get; set; }
        public int SerieV { get; set; }
        public string Client { get; set; }
        public string Denomination { get; set; }
        public string CpteJumelleCC { get; set; }
        public string CpteJumelleCredit { get; set; }
        public Nullable<short> CatCpte { get; set; }
        public string CpteJumelleImp { get; set; }
        public string CpteIndAgioRes { get; set; }
        public string CpteGenAgioRes { get; set; }
        public string CleGenAgioRes { get; set; }
        public string LibCpteGenAgioRes { get; set; }
        public string CpteGL { get; set; }
        public string CleCpte { get; set; }
        public string LibCpteGl { get; set; }
        public Nullable<double> Montant { get; set; }
        public Nullable<double> Capital { get; set; }
        public Nullable<double> Interet { get; set; }
        public Nullable<double> MtTVA { get; set; }
        public Nullable<double> MtTDC { get; set; }
        public Nullable<double> PortionDiff { get; set; }
        public Nullable<System.DateTime> DateImpaye { get; set; }
        public string Regul { get; set; }
        public Nullable<System.DateTime> DateRegul { get; set; }
        public Nullable<System.DateTime> DateTransfContent { get; set; }
        public string NumeroContrat { get; set; }
        public Nullable<System.DateTime> DateAccord { get; set; }
        public Nullable<double> MtPenalite { get; set; }
        public Nullable<System.DateTime> DateCptaPenalite { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string FPVal { get; set; }
        public string TxnNo { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
        public string RowStatus { get; set; }
        public Nullable<System.DateTime> DateAudit { get; set; }
        public decimal serie { get; set; }
        public string ImpStatus { get; set; }
        public decimal idaudit { get; set; }
    }
}
