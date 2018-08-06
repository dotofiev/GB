using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class ActiviteEconomique : BO
    {
        public long date_creation { get; set; }
        public long id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }

        public ActiviteEconomique(long id)
        {
            this.id = id;
        }

        public ActiviteEconomique() { }

        public override void Crer_Id()
        {
            this.id = Program.db.activites_economique.Count + 1;
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