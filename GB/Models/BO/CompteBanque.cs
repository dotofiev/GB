using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class CompteBanque : BO
    {
        public long id_utilisateur_createur { get; set; }
        public long id_compte { get; set; }
        public long id_banque { get; set; }
        public Compte compte { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public Banque banque { get; set; }
        public long date_creation { get; set; }

        public CompteBanque(long id)
        {
            this.id = id;
        }

        public CompteBanque() { }

        public override void Crer_Id()
        {
            this.id = Tests.Program.db.comptes_banque.Count + 1;
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