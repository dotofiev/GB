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
    
    public partial class CpteCltHistBBF
    {
        public int Agence { get; set; }
        public string Devise { get; set; }
        public string cptecol { get; set; }
        public string CpteJumelle { get; set; }
        public Nullable<double> SDebit { get; set; }
        public Nullable<double> Scredit { get; set; }
        public System.DateTime Enddate { get; set; }
        public string CodeMaj { get; set; }
    }
}
