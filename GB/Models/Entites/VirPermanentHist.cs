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
    
    public partial class VirPermanentHist
    {
        public Nullable<short> Agence { get; set; }
        public string CpteDonneur { get; set; }
        public string TypeVir { get; set; }
        public Nullable<short> Liaison { get; set; }
        public string LibLiaison { get; set; }
        public string BqueBenef { get; set; }
        public string CpteBqueB { get; set; }
        public string CpteBenef { get; set; }
        public string DenoBenef { get; set; }
        public Nullable<System.DateTime> DateOrdre { get; set; }
        public Nullable<double> Montant { get; set; }
        public Nullable<System.DateTime> DateDernierVir { get; set; }
        public string Situation { get; set; }
        public Nullable<double> Commission { get; set; }
        public Nullable<double> Taxe { get; set; }
        public string Description { get; set; }
        public string Fonction { get; set; }
        public string LibAgence { get; set; }
        public string LibCpteDonneur { get; set; }
        public int SerieNum { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string CpteBenefInt { get; set; }
        public string LibCpteBenefInt { get; set; }
        public Nullable<short> Employe { get; set; }
        public string LibEmploye { get; set; }
        public string Statut { get; set; }
        public string LibBqueBenef { get; set; }
        public string CleCpte { get; set; }
        public string Tracer { get; set; }
        public Nullable<System.DateTime> Datevals { get; set; }
        public Nullable<System.DateTime> DateVals2 { get; set; }
        public Nullable<System.DateTime> Datemodif { get; set; }
        public Nullable<short> DateVir { get; set; }
        public Nullable<System.DateTime> DateCptaVir { get; set; }
    }
}