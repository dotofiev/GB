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
    
    public partial class Compensation
    {
        public short Agence { get; set; }
        public string CpteJumelleCC { get; set; }
        public string Denomination { get; set; }
        public string TypePres { get; set; }
        public string CodeCorrBnk { get; set; }
        public string LibCorrBnk { get; set; }
        public string RefRemise { get; set; }
        public Nullable<short> LigneRefRemise { get; set; }
        public string Tracer { get; set; }
        public Nullable<double> MtCheque { get; set; }
        public string Status { get; set; }
        public string NatItem { get; set; }
        public string ChkType { get; set; }
        public Nullable<double> TxCom { get; set; }
        public Nullable<double> AmtCom { get; set; }
        public Nullable<double> TxTVA { get; set; }
        public Nullable<double> MtTVA { get; set; }
        public Nullable<System.DateTime> DateEff { get; set; }
        public Nullable<System.DateTime> DateComp { get; set; }
        public Nullable<System.DateTime> DateVals { get; set; }
        public string CodeTirBnk { get; set; }
        public string LibTirBnk { get; set; }
        public string CodeBenBnk { get; set; }
        public string LibBenBnk { get; set; }
        public string BenAcct { get; set; }
        public string Description { get; set; }
        public Nullable<short> CodeTrait { get; set; }
        public string ClrResult { get; set; }
        public string CodeRem { get; set; }
        public Nullable<short> AgenceProv { get; set; }
        public string LibAgence { get; set; }
        public string LibAgenceProv { get; set; }
        public decimal Serie { get; set; }
        public string TirAcct { get; set; }
        public string TxnNo { get; set; }
    }
}
