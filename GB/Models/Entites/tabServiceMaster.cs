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
    
    public partial class tabServiceMaster
    {
        public string SrvCode { get; set; }
        public string SrvName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ServiceDescp { get; set; }
        public string RecStatus { get; set; }
        public Nullable<int> DirectorateID { get; set; }
        public Nullable<int> ACID { get; set; }
    }
}