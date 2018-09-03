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
    public class CongeBanque : BOClass, IBO<object>
    {
        public int jour { get; set; }
        public int mois { get; set; }
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public long date_creation { get; set; }

        public CongeBanque(string id)
        {
            this.id = id;
        }

        public CongeBanque() { }

        public void Crer_Id()
        {
            this.id = (Program.db.conges_banque.Count + 1).ToString();
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

        public static List<string> Classes_references
        {
            get
            {
                return
                    new List<string>() {
                        typeof(Utilisateur).Name,
                    };
            }
        }
    }
}