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
    
    public partial class AuditEmpPrivSet
    {
        public int Agence { get; set; }
        public short Matricule { get; set; }
        public string LibEmploye { get; set; }
        public bool Ajout { get; set; }
        public bool Modif { get; set; }
        public bool Delete { get; set; }
        public bool List { get; set; }
        public bool PrintD { get; set; }
        public string RecordSrce { get; set; }
        public string ApplicationName { get; set; }
        public string privFunction { get; set; }
        public Nullable<short> Employe { get; set; }
        public string NomEmploye { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
        public string Libagence { get; set; }
        public string RowStatus { get; set; }
    }
}
