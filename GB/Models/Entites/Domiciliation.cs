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
    
    public partial class Domiciliation
    {
        public Nullable<short> Agence { get; set; }
        public int Serie { get; set; }
        public string CpteJumelleCC { get; set; }
        public string Denomination { get; set; }
        public Nullable<System.DateTime> DateOuverture { get; set; }
        public string Nature { get; set; }
        public string Devise { get; set; }
        public string LibDevise { get; set; }
        public string NumDomiciliation { get; set; }
        public string PaysProvenance { get; set; }
        public string LibPaysProvenance { get; set; }
        public Nullable<double> Montant { get; set; }
        public Nullable<double> Cours { get; set; }
        public Nullable<double> CVCFA { get; set; }
        public Nullable<double> Commissions { get; set; }
        public Nullable<double> MtTVA { get; set; }
        public Nullable<int> Employe { get; set; }
        public string LibEmploye { get; set; }
        public string Description { get; set; }
        public string DescriptionB { get; set; }
        public Nullable<bool> CodeCalCommis { get; set; }
        public string LibAgence { get; set; }
        public Nullable<System.DateTime> DateDebutDom { get; set; }
        public Nullable<System.DateTime> DateFinDom { get; set; }
        public string Fournisseur { get; set; }
        public string DomFournisseur { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string AdresseBenef { get; set; }
    }
}
