using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.Tests;
using GB.Models.Interfaces;
using System.Data.Entity.Core.Objects;

namespace GB.Models.BO
{
    public class ExerciceFiscal : BOClass, IBO<object>
    {
        public string statut { get; set; }
        public string budget_id { get; set; }
        public string date_debut { get; set; }
        public string date_fin { get; set; }

        public void Crer_Id()
        {
            this.id = (Program.db.exercices_fiscal.Count + 1).ToString();
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