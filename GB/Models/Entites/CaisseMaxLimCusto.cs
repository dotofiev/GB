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
    
    public partial class CaisseMaxLimCusto
    {
        public string CodeCaisse { get; set; }
        public string devise { get; set; }
        public string Libelle { get; set; }
        public Nullable<double> MontantDep { get; set; }
        public Nullable<double> DebitJour { get; set; }
        public Nullable<double> CreditJour { get; set; }
        public string Compte { get; set; }
        public string Cle { get; set; }
        public string CpteJumelle { get; set; }
        public string Denomination { get; set; }
        public string LibCompte { get; set; }
        public System.DateTime DateJour { get; set; }
        public string Employe { get; set; }
        public string LibEmploye { get; set; }
        public Nullable<double> MaxAmount { get; set; }
        public string StatusOp { get; set; }
        public string agence { get; set; }
        public decimal serie { get; set; }
    }
}
