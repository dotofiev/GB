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
    
    public partial class Contentieu
    {
        public string Agence { get; set; }
        public decimal Serie { get; set; }
        public int Client { get; set; }
        public string Denomination { get; set; }
        public string CpteJumelleCC { get; set; }
        public string CpteJumelleImp { get; set; }
        public string CpteJumelleCredit { get; set; }
        public Nullable<short> CatCpte { get; set; }
        public string CpteJumelleCont { get; set; }
        public string CpteIndAgioRes { get; set; }
        public string CpteGL { get; set; }
        public string CleCpte { get; set; }
        public string LibCpteGl { get; set; }
        public Nullable<double> Montant { get; set; }
        public Nullable<double> RembMensuel { get; set; }
        public Nullable<double> Interet { get; set; }
        public Nullable<double> MtTVA { get; set; }
        public System.DateTime DateContentieux { get; set; }
        public System.DateTime DateImpaye { get; set; }
        public string StateCont { get; set; }
        public Nullable<System.DateTime> DateReglement { get; set; }
        public string NumeroContrat { get; set; }
        public Nullable<System.DateTime> DateAccord { get; set; }
        public Nullable<double> MtPenalite { get; set; }
        public Nullable<System.DateTime> DateCptaPenalite { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string FPVal { get; set; }
        public string TxnNo { get; set; }
        public Nullable<System.DateTime> Datetransfert { get; set; }
        public string ImpayeStatus { get; set; }
        public Nullable<double> provision { get; set; }
        public string Writeoff { get; set; }
    }
}
