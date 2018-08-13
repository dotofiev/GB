using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Societe : BO
    {
        public long id_agence { get; set; }
        public long id_compte_transit { get; set; }
        public long id_compte_paiement { get; set; }
        public long id_compte_pret { get; set; }
        public long id_compte_interet_pret { get; set; }
        public Compte compte_transit { get; set; }
        public Compte compte_paiement { get; set; }
        public Compte compte_pret { get; set; }
        public Compte compte_interet_pret { get; set; }
        public Agence agence { get; set; }
        public string base_de_calcul { get; set; }
        public string type_traitement { get; set; }

        public Societe(long id)
        {
            this.id = id;
        }

        public Societe() { }

        public override void Crer_Id()
        {
            this.id = Tests.Program.db.societes.Count + 1;
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