using GB.Models.Tests;
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
        public long id_agence { get; set; }
        public long id_profession { get; set; }
        public long id_pouvoir { get; set; }
        public long id_autorite_signature { get; set; }
        public string compte { get; set; }
        public string mot_de_passe { get; set; }
        public string nom_utilisateur { get; set; }
        public bool ouverture_back_date { get; set; }
        public bool ouverture_branch { get; set; }
        public bool ouverture_back_date_travail { get; set; }
        public int duree_mot_de_passe { get; set; }
        public bool est_connecte { get; set; }
        public bool acces_historique_compte { get; set; }
        public bool est_suspendu { get; set; }
        public bool modifier_mot_de_passe { get; set; }
        public long date_mise_a_jour_mot_de_passe { get; set; }
        public Agence agence { get; set; }
        public Profession profession { get; set; }
        public AutoriteSignature autorite_signature { get; set; }

        public Utilisateur() { }

        public void Crer_Id()
        {
            this.id_utilisateur = Program.db.utilisateurs.Count + 1;
        }
    }
}