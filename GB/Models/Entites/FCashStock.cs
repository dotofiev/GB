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
    
    public partial class FCashStock
    {
        public Nullable<short> Agence { get; set; }
        public string Devise { get; set; }
        public int Serie { get; set; }
        public string Emetteur { get; set; }
        public string Ref { get; set; }
        public string CpteJumelleCC { get; set; }
        public string Denomination { get; set; }
        public Nullable<System.DateTime> DateAcquisition { get; set; }
        public string TypeAcquisition { get; set; }
        public Nullable<double> Montant { get; set; }
        public string Situation { get; set; }
        public Nullable<short> AgenceTransf { get; set; }
        public Nullable<System.DateTime> DateVente { get; set; }
        public string LibDevise { get; set; }
        public string LibAgence { get; set; }
        public string LibAgenceTransf { get; set; }
        public Nullable<float> DateCptaAcq { get; set; }
        public string Provenance { get; set; }
        public Nullable<System.DateTime> Datecreation { get; set; }
        public string Initial { get; set; }
        public Nullable<System.DateTime> DateRemb { get; set; }
        public Nullable<System.DateTime> DateSortie { get; set; }
    }
}
