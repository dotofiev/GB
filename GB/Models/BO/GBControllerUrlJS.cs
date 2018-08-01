using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class GBControllerUrlJS
    {
        public string url_ajax_ajout_enregistrement;
        public string url_ajax_dataTable;
        public string url_ajax_easyAutocomplete;
        public string url_ajax_recharger_easyAutocomplete;
        public string url_ajax_modification_enregistrement;
        public string url_ajax_selection_enregistrement;
        public string url_ajax_suppression_enregistrement;
        public string url_controlleur;

        public GBControllerUrlJS() { }

        public GBControllerUrlJS(object controlleur, string id_page)
        {
            string nom_controlleur = controlleur.GetType().Name.Replace("Controller", string.Empty);

            this.url_ajax_dataTable = $"/{nom_controlleur}/Charger_Table/?id_page={id_page}";
            this.url_ajax_suppression_enregistrement = $"/{nom_controlleur}/Supprimer_Enregistrement/";
            this.url_ajax_ajout_enregistrement = $"/{nom_controlleur}/Ajouter_Enregistrement/";
            this.url_ajax_easyAutocomplete = $"/{nom_controlleur}/Charger_EasyAutocomplete/?id_page={id_page}";
            this.url_ajax_recharger_easyAutocomplete = $"/{nom_controlleur}/Recharger_EasyAutocomplete/?id_page={id_page}";
            this.url_controlleur = $"/{nom_controlleur}/";
            this.url_ajax_modification_enregistrement = $"/{nom_controlleur}/Modifier_Enregistrement/";
            this.url_ajax_selection_enregistrement = $"/{nom_controlleur}/Selection_Enregistrement/";
        }
    }
}