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
    
    public partial class TempTabBadUnpaid
    {
        public int Agence { get; set; }
        public string CpteJumelle { get; set; }
        public string Denomination { get; set; }
        public string CpteJumelleImp { get; set; }
        public Nullable<double> TotRembMensuelUnp { get; set; }
        public Nullable<double> TotInteretMoisUnp { get; set; }
        public Nullable<double> TotTvaMoisUnp { get; set; }
        public Nullable<double> TotRembMensuelHisto { get; set; }
    }
}
