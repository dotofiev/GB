using GB.Models.BO;
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
    public class Societe : BOClass, IBO<object>
    {
        public string id_agence { get; set; }
        public string id_compte_transit { get; set; }
        public string id_compte_paiement { get; set; }
        public string id_compte_pret { get; set; }
        public string id_compte_interet_pret { get; set; }
        public Compte compte_transit { get; set; }
        public Compte compte_paiement { get; set; }
        public Compte compte_pret { get; set; }
        public Compte compte_interet_pret { get; set; }
        public Agence agence { get; set; }
        public string base_de_calcul { get; set; }
        public string type_traitement { get; set; }

        public Societe(string id)
        {
            this.id = id;
        }

        public Societe() { }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.societes.Count + 1).ToString();
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
                        typeof(Utilisateur).Name
                    };
            }
        }
    }
}