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
    
    public partial class AutoCred
    {
        public string Agence { get; set; }
        public decimal Numero { get; set; }
        public Nullable<System.DateTime> DateAccord { get; set; }
        public Nullable<double> Montant { get; set; }
        public Nullable<System.DateTime> DateEch { get; set; }
        public string Blocage { get; set; }
        public string LibAgence { get; set; }
        public string LibClient { get; set; }
        public Nullable<System.DateTime> DateSaisie { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public string Client { get; set; }
        public string CpteJumelle { get; set; }
        public string Statut { get; set; }
        public Nullable<double> establishmentfee { get; set; }
        public Nullable<System.DateTime> DateModifStatut { get; set; }
    }
}
