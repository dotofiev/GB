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
    public class Banque : BO, IBO<object>
    {
        public string id_utilisateur_createur { get; set; }
        public string adresse_1 { get; set; }
        public string adresse_2 { get; set; }
        public string ville { get; set; }
        public string id_pays { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public PAYS pays { get; set; }
        public long date_creation { get; set; }

        public Banque(string id)
        {
            this.id = id;
        }

        public Banque() { }

        public void Crer_Id()
        {
            this.id = (Program.db.banques.Count + 1).ToString();
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