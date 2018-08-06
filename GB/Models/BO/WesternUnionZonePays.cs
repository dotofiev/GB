using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class WesternUnionZonePays : BO
    {
        
        public long id_pays { get; set; }
        public Pays pays { get; set; }
        public string zone { get; set; }

        public WesternUnionZonePays(long id)
        {
            this.id = id;
        }

        public WesternUnionZonePays() { }

        public override void Crer_Id()
        {
            this.id = Program.db.western_union_zones_pays.Count + 1;
        }
    }
}