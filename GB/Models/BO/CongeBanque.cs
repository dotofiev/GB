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
    public class CongeBanque : BO
    {
        public int jour { get; set; }
        public int mois { get; set; }
        public long id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        public long date_creation { get; set; }

        public CongeBanque(long id)
        {
            this.id = id;
        }

        public CongeBanque() { }

        public override void Crer_Id()
        {
            this.id = Program.db.conges_banque.Count + 1;
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