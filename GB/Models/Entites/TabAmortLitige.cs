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
    
    public partial class TabAmortLitige
    {
        public int Echeance { get; set; }
        public string NumeroContrat { get; set; }
        public Nullable<System.DateTime> DteEcheance { get; set; }
        public Nullable<double> AmCap { get; set; }
        public Nullable<double> IntP { get; set; }
        public Nullable<double> TvaP { get; set; }
        public Nullable<double> Anuite { get; set; }
        public Nullable<double> CapRD { get; set; }
        public string TypeRemb { get; set; }
    }
}