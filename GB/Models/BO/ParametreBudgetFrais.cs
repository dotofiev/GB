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
    public class ParametreBudgetFrais : BO, IBO<object>
    {
        public string id_compte { get; set; }
        public Compte compte { get; set; }
        public bool autoriser_control_budget { get; set; }

        public ParametreBudgetFrais(string id)
        {
            this.id = id;
        }

        public ParametreBudgetFrais() { }

        public void Crer_Id()
        {
            this.id = (Program.db.parametres_budget_frais.Count + 1).ToString();
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