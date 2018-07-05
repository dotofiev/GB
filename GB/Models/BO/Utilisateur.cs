using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Utilisateur
    {
        public long id_utilisateur { get; set; }
        public long id_role { get; set; }
        public string compte { get; set; }
        public string mot_de_passe { get; set; }
        public string nom_utilisateur { get; set; }

        public Utilisateur() { }
    }
}