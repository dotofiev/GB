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
    
    public partial class CautionSit
    {
        public short Agence { get; set; }
        public string MatClient { get; set; }
        public int NumeroEngag { get; set; }
        public int Serie { get; set; }
        public Nullable<System.DateTime> DMLCaution { get; set; }
        public string TypeML { get; set; }
        public Nullable<double> MtMLCaution { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string LibAgence { get; set; }
        public string NomPrenom { get; set; }
    }
}
