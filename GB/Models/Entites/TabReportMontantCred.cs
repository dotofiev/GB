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
    
    public partial class TabReportMontantCred
    {
        public string NumeroContrat { get; set; }
        public string CpteJumelleCC { get; set; }
        public Nullable<double> TotalRembCapital { get; set; }
        public Nullable<double> TotalARembCapital { get; set; }
        public Nullable<double> TotalRembInt { get; set; }
        public Nullable<double> TotalARembInt { get; set; }
        public Nullable<double> TotalRembTVA { get; set; }
        public Nullable<double> TotalARembTVA { get; set; }
        public Nullable<double> TotalImpaye { get; set; }
        public Nullable<double> TotalContentieux { get; set; }
        public Nullable<double> TotalAgioRes { get; set; }
        public Nullable<double> TotalArTVA { get; set; }
        public Nullable<int> EcheanceCours { get; set; }
        public string MessageDesc { get; set; }
    }
}