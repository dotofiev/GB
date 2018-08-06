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
    public class Parametre : BO
    {
        public int nombre_ligne_historique_compte { get; set; }
        public bool utilisation_chequier { get; set; }
        public int nombre_jour_avant_apuration_credit { get; set; }
        public int periode_dormante { get; set; }
        public int periode_litige { get; set; }
        public bool utilisation_version_centrale { get; set; }
        public int periode_de_non_paiement { get; set; }
        public bool controler_le_nombre_de_pret { get; set; }
        public bool controler_le_nombre_de_comptes { get; set; }
        public bool tva { get; set; }
        public bool controler_session { get; set; }
        public int duree_session { get; set; }
        public bool sms_banking { get; set; }
        public int nombre_de_jour_ouverture_back_date { get; set; }
        public string methode_de_post_interet_reserver { get; set; }
        public bool utilisation_litige_methode_cobac { get; set; }
        public bool modifier_les_attributs_client_dans_la_branch { get; set; }
        public bool conter_le_nombre_de_page_dans_historique { get; set; }
        public bool mise_a_jour_position_client { get; set; }
        public bool poster_credit { get; set; }
        public bool poster_litige_pret { get; set; }
        public bool poster_collection_locale { get; set; }
        public bool western_union { get; set; }
        public bool poster_bon_de_caisse_et_depot_a_terme { get; set; }
        public string methode_de_sauvegarde { get; set; }
        public string lien_sauvegarde_numero_1 { get; set; }
        public string lien_sauvegarde_numero_2 { get; set; }

        public Parametre(long id)
        {
            this.id = id;
        }

        public Parametre() { }

        public override void Crer_Id()
        {
            this.id = Program.db.parametres.Count + 1;
        }
    }
}