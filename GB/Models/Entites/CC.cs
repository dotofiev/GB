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
    
    public partial class CC
    {
        public short Cc_Agence { get; set; }
        public string Cc_TypeCheque { get; set; }
        public string Cc_Tracer { get; set; }
        public string Cc_Trancode { get; set; }
        public Nullable<double> Cc_TxIntDb { get; set; }
        public Nullable<double> Cc_TxIntCr { get; set; }
        public double Cc_MtCheque { get; set; }
        public Nullable<double> Cc_Charge { get; set; }
        public Nullable<double> Cc_TxTVA { get; set; }
        public Nullable<double> Cc_MtTVA { get; set; }
        public System.DateTime Cc_DateVals { get; set; }
        public string Cc_CpteClt { get; set; }
        public string Cc_Status { get; set; }
        public Nullable<System.DateTime> Cc_DateCreation { get; set; }
        public Nullable<int> Cc_Employe { get; set; }
        public string Cc_LibEmploye { get; set; }
        public string Cc_CpteGl { get; set; }
        public string Cc_CleCpteGl { get; set; }
        public string Cc_LibCpteGl { get; set; }
        public string Cc_LibAgence { get; set; }
        public string Cc_CpteGLCom { get; set; }
        public string Cc_CleCpteGLCom { get; set; }
        public string Cc_LibCpteGLCom { get; set; }
        public string Cc_CpteGLTVA { get; set; }
        public string Cc_CleCpteGLTVA { get; set; }
        public string Cc_LibCpteGLTVA { get; set; }
        public string Cc_Denomination { get; set; }
        public string Cc_OptnType { get; set; }
        public string Cc_Description { get; set; }
        public string Cc_CodeLibelle { get; set; }
        public string Cc_CodeForce { get; set; }
        public Nullable<System.DateTime> Cc_DateOperation { get; set; }
        public string Cc_Journal { get; set; }
        public string Cc_CodeMAJ { get; set; }
        public string Cc_LibJournal { get; set; }
        public string Cc_CpteColClt { get; set; }
        public string Cc_CleColClt { get; set; }
        public string Cc_LibCpteColClt { get; set; }
        public decimal SERIE { get; set; }
        public string TxnNo { get; set; }
    }
}