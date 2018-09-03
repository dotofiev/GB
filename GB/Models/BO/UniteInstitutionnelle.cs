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
    public class UniteInstitutionnelle : BOClass, IBO<object>
    {
        public long date_creation { get; set; }
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }

        public UniteInstitutionnelle(string id)
        {
            this.id = id;
        }

        public UniteInstitutionnelle() { }

        public void Crer_Id()
        {
            this.id = (Program.db.unites_institutionnelle.Count + 1).ToString();
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