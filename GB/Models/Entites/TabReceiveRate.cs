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
    
    public partial class TabReceiveRate
    {
        public int RateID { get; set; }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public Nullable<double> ComTouTaxe { get; set; }
        public Nullable<double> TauxCalcul { get; set; }
    }
}
