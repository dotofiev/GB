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
    public class ParametreBanque : BOClass, IBO<object>
    {
        public string id_devise { get; set; }
        public Devise devise { get; set; }
        public double taux { get; set; }
        public int montant { get; set; }
        public int montant_minimal { get; set; }
        public int montant_maximal { get; set; }

        public ParametreBanque(string id)
        {
            this.id = id;
        }

        public ParametreBanque() { }

        public void Crer_Id()
        {
            this.id = (Program.db.parametres_banque.Count + 1).ToString();
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