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
    
    public partial class TmpLiqDeclaration
    {
        public string Agence { get; set; }
        public string LibAgence { get; set; }
        public string Matricule { get; set; }
        public string GLAccount { get; set; }
        public string Denomination { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public Nullable<double> OpenBal { get; set; }
        public Nullable<double> TotDebit { get; set; }
        public Nullable<double> TotCredit { get; set; }
        public Nullable<double> ClosingBal { get; set; }
        public string Sense { get; set; }
        public decimal Pk { get; set; }
    }
}