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
    
    public partial class tabBudgetTransaction
    {
        public decimal BTrnCode { get; set; }
        public string Agence { get; set; }
        public string Codecentre { get; set; }
        public string Description { get; set; }
        public Nullable<double> DebitAmount { get; set; }
        public string Authorisedby { get; set; }
        public string BudgetID { get; set; }
        public Nullable<System.DateTime> TrnDate { get; set; }
        public Nullable<double> CreditAmount { get; set; }
        public Nullable<System.DateTime> DateCpta { get; set; }
        public string employe { get; set; }
        public string LibEmploye { get; set; }
        public Nullable<int> fiscalid { get; set; }
        public Nullable<double> TaxAmount { get; set; }
        public Nullable<double> ActualExpense { get; set; }
        public string Cptejumelle { get; set; }
        public string Denomination { get; set; }
        public string reference { get; set; }
        public string StatutModif { get; set; }
        public string TypeBudget { get; set; }
    }
}
