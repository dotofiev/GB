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
    
    public partial class SalEmp
    {
        public int MonthYear { get; set; }
        public string Institution { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string MatriSalaire { get; set; }
        public string NomEmploye { get; set; }
        public Nullable<double> MontSalaire { get; set; }
        public string CpteJumelle { get; set; }
        public System.DateTime DateSalaire { get; set; }
        public string CodeMaj { get; set; }
        public int Series { get; set; }
    }
}
