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
    
    public partial class ImmoHist
    {
        public decimal Series { get; set; }
        public string Numero { get; set; }
        public string Designation { get; set; }
        public Nullable<int> numEcheance { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateDernCalAm { get; set; }
        public string RefTransaction { get; set; }
        public string Agence { get; set; }
        public Nullable<double> AmortCummule { get; set; }
        public string StateAcct { get; set; }
        public Nullable<double> ValeurResiduelle { get; set; }
        public string PeriodiciteAm { get; set; }
        public string PeriodiciteAcct { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public string CpteImmob { get; set; }
        public string CpteAmortissement { get; set; }
        public string CpteDepreciation { get; set; }
        public string StatAccDep { get; set; }
    }
}