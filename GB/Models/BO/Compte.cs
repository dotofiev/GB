using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Compte : BO
    {
        public string numero_compte { get; set; }
        public string nature { get; set; }
        public string statut { get; set; }
        public string cle { get; set; }
        public long id_devise { get; set; }
        public Devise devise { get; set; }
        public long id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public long date_creation { get; set; }

        public Compte(long id)
        {
            this.id = id;
        }

        public Compte() { }

        public override void Crer_Id()
        {
            this.id = Program.db.comptes.Count + 1;
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