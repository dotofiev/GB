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
    
    public partial class Document
    {
        public string CpteJumelle { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentImg { get; set; }
        public Nullable<int> DocumentSize { get; set; }
        public string Remark { get; set; }
        public string Matricule { get; set; }
        public string LibEmploye { get; set; }
        public decimal DocumentId { get; set; }
    }
}