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
    
    public partial class AuditIntegrateFile
    {
        public int Agence { get; set; }
        public string LibAgence { get; set; }
        public System.DateTime DateIntegrate { get; set; }
        public string FichierIntagrate { get; set; }
        public Nullable<int> Employe { get; set; }
        public string LibEmploye { get; set; }
        public string OperationType { get; set; }
        public string Status { get; set; }
        public string RowStatus { get; set; }
    }
}
