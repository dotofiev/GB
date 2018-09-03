using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class WesternUnionZonePays : BO, IBO<object>
    {
        
        public string id_pays { get; set; }
        public PAYS pays { get; set; }
        public string zone { get; set; }

        public WesternUnionZonePays(string id)
        {
            this.id = id;
        }

        public WesternUnionZonePays() { }

        public void Crer_Id()
        {
            this.id = (Program.db.western_union_zones_pays.Count + 1).ToString();
        }

        public object ToEntities(Dictionary<string, object> parametres = null)
        {
            throw new NotImplementedException();
        }

        public void FromEntities(object entitie)
        {
            throw new NotImplementedException();
        }

        public void ModifyEntities(object entitie)
        {
            throw new NotImplementedException();
        }
    }
}