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
    
    public partial class GlHistRienB
    {
        public int Agence { get; set; }
        public string Devise { get; set; }
        public string Compte { get; set; }
        public string Cle { get; set; }
        public System.DateTime DateOperation { get; set; }
        public string Journal { get; set; }
        public int Folio { get; set; }
        public int Ligne { get; set; }
        public int NumEcrit { get; set; }
        public string Tiers { get; set; }
        public string CleTiers { get; set; }
        public string Service { get; set; }
        public string CodeLibelle { get; set; }
        public string Libelle { get; set; }
        public string RefEcrit { get; set; }
        public string RefOperation { get; set; }
        public string RefDenotage { get; set; }
        public string SvceEmet { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string Description { get; set; }
        public string DateValeur { get; set; }
        public Nullable<System.DateTime> DateEch { get; set; }
        public Nullable<System.DateTime> DateMaj { get; set; }
        public string LibelleCpte { get; set; }
        public string LibelleTiers { get; set; }
        public string LibelleSvce { get; set; }
        public string CodeVent { get; set; }
        public Nullable<int> CodeEmpl { get; set; }
        public string LibAgence { get; set; }
        public string LibDevise { get; set; }
        public string LibJournal { get; set; }
        public Nullable<System.DateTime> DateSaisie { get; set; }
        public string Lettrage { get; set; }
        public string Pointage { get; set; }
        public Nullable<System.DateTime> DateTransf { get; set; }
        public Nullable<int> Piece { get; set; }
        public string LibEmploye { get; set; }
        public string CpteJumelle { get; set; }
        public string Denomination { get; set; }
    }
}
