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
    
    public partial class WriteOffLoan
    {
        public string Agence { get; set; }
        public decimal Serie { get; set; }
        public string Denomination { get; set; }
        public string CpteJumelleCC { get; set; }
        public string CpteJumelleCredit { get; set; }
        public Nullable<double> Capital { get; set; }
        public Nullable<double> Interet { get; set; }
        public Nullable<double> MtTVA { get; set; }
        public Nullable<int> NbDays { get; set; }
        public Nullable<System.DateTime> DateImpaye { get; set; }
        public string NumeroContrat { get; set; }
        public Nullable<System.DateTime> DateAccord { get; set; }
        public Nullable<double> MtPenalite { get; set; }
        public Nullable<System.DateTime> DateCptaPenalite { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public Nullable<double> provision { get; set; }
        public Nullable<double> amountToprovision { get; set; }
        public string matricule { get; set; }
        public string val { get; set; }
    }
}
