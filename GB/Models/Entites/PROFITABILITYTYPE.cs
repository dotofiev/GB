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
    
    public partial class PROFITABILITYTYPE
    {
        public string PROFITABILITYNAME { get; set; }
        public string PROFGROUPNAME { get; set; }
        public string PROFITYPE { get; set; }
        public string PROFITDESCRIPTION { get; set; }
    
        public virtual PROFITABILITYGROUP PROFITABILITYGROUP { get; set; }
    }
}
