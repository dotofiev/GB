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
    public class Compte : BO, IBO<object>
    {
        public string numero_compte { get; set; }
        public string nature { get; set; }
        public string statut { get; set; }
        public string cle { get; set; }
        public bool type_operation_compte_client_et_compte_gl { get; set; }
        public bool type_operation_compte_gl_et_compte_gl { get; set; }
        public string id_devise { get; set; }
        public Devise devise { get; set; }
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public long date_creation { get; set; }

        public Compte(string id)
        {
            this.id = id;
        }

        public Compte() { }

        public void Crer_Id()
        {
            this.id = (Program.db.comptes.Count + 1).ToString();
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
                        typeof(Devise).Name,
                    };
            }
        }
    }
}