using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class TypePret : BO, IBO<object>
    {
        public int periode_debut { get; set; }
        public int periode_fin { get; set; }
        public string periodicite { get; set; }

        public TypePret(string id)
        {
            this.id = id;
        }

        public TypePret() { }

        public void Crer_Id()
        {
            this.id = (Program.db.types_pret.Count + 1).ToString();
        }

        public object ToEntities()
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