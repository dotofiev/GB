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
    
    public partial class FCRemb
    {
        public int Agence { get; set; }
        public System.DateTime DateRemb { get; set; }
        public Nullable<System.DateTime> DateOp { get; set; }
        public string Reference { get; set; }
        public string RefFC { get; set; }
        public string CpteJumelleCC { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string LibAgence { get; set; }
        public Nullable<int> AgEmettrice { get; set; }
        public string LibAgEmettrice { get; set; }
        public Nullable<double> Montant { get; set; }
        public string @ref { get; set; }
        public Nullable<int> AgenceProv { get; set; }
        public string LibAgenceProv { get; set; }
    }
}