﻿using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class CompteBanque : BO, IBO<object>
    {
        public string id_utilisateur_createur { get; set; }
        public string id_compte { get; set; }
        public string id_banque { get; set; }
        public Compte compte { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public Banque banque { get; set; }
        public long date_creation { get; set; }

        public CompteBanque(string id)
        {
            this.id = id;
        }

        public CompteBanque() { }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.comptes_banque.Count + 1).ToString();
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

        public static List<Type> Classes_references
        {
            get
            {
                return
                    new List<Type>() {
                        typeof(Utilisateur)
                    };
            }
        }
    }
}