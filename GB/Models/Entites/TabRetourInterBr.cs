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
    
    public partial class TabRetourInterBr
    {
        public short Agence { get; set; }
        public Nullable<double> Amount { get; set; }
        public string Reference { get; set; }
        public string OptnType { get; set; }
        public Nullable<System.DateTime> DateOperation { get; set; }
        public string Description { get; set; }
        public string LibAgence { get; set; }
        public string SendAcct { get; set; }
        public string SendName { get; set; }
        public string ReceivAcct { get; set; }
        public string ReceivName { get; set; }
        public Nullable<short> AgenceRecep { get; set; }
        public string CpteGLIntBr { get; set; }
        public string CleCpteIntBr { get; set; }
        public string LibCpteGLIntBr { get; set; }
        public string CodeMaj { get; set; }
        public Nullable<double> comamount { get; set; }
        public string codemajcom { get; set; }
        public Nullable<double> tvaamount { get; set; }
        public string CpteGLDenoue { get; set; }
        public string CleCpteDenoue { get; set; }
        public string LibCpteGLDenoue { get; set; }
    }
}