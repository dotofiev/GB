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
    
    public partial class CustomerRelationship
    {
        public int CustRelCode { get; set; }
        public string CustRelName { get; set; }
        public string CustRelSurname { get; set; }
        public string CustRelTel { get; set; }
        public string CustRelEmail { get; set; }
        public string Shortee { get; set; }
        public string ShorteeTel { get; set; }
        public Nullable<double> AmountShortee { get; set; }
        public string ShorteeGuarantee { get; set; }
        public Nullable<int> Employe { get; set; }
        public string nomEmploye { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string Cnitemoin { get; set; }
    }
}