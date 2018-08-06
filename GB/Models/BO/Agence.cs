using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Agence : BO
    {
        public long id_utilisateur { get; set; }
        public Utilisateur utilisateur { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string bp { get; set; }
        public string telephone { get; set; }
        public string pays { get; set; }
        public string fax { get; set; }
        public string cobac_id { get; set; }
        public string beac_id { get; set; }
        public string ip { get; set; }
        public string mot_de_passe { get; set; }

        public Agence(long id)
        {
            this.id = id;
        }

        public Agence() { }

        public override void Crer_Id()
        {
            this.id = Tests.Program.db.agences.Count + 1;
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