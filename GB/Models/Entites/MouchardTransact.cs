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
    
    public partial class MouchardTransact
    {
        public string Agence { get; set; }
        public string TableTransact { get; set; }
        public string InfoTransact { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public string LibTable { get; set; }
        public Nullable<System.DateTime> DateTransact { get; set; }
        public string ComputerName { get; set; }
        public string TaskCode { get; set; }
        public string TaskDescription { get; set; }
        public decimal Series { get; set; }
        public string ancienneVal { get; set; }
        public string NouvelleVal { get; set; }
    }
}