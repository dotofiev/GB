using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace GB.Models.Static
{
    public static class GBClass
    {
        // -- Déclarer une instance de log4net -- //
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Vérifie qu'une adresse site web est existante
        /// </summary>
        public static bool Est_Site_Web(string adresse_site_web)
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage result = Client.GetAsync(new Uri(adresse_site_web)).Result;

                    return
                        (result.StatusCode == HttpStatusCode.Accepted || result.StatusCode == HttpStatusCode.OK) ? true
                                                                                                                 : false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtenir le code source html d'une page web
        /// </summary>
        public static string HTML_Site_Web(string adresse_site_web)
        {
            try
            {
                // -- Teste si l'adresse est valide -- //
                if (Est_Site_Web(adresse_site_web))
                {
                    // -- Creation de la requete -- //
                    HttpWebRequest request = WebRequest.Create(adresse_site_web) as HttpWebRequest;

                    // -- Réccupération de la réponse -- //
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                    // -- Lecture du contenu de la réponse -- //
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        return
                            streamReader.ReadToEnd();
                    }
                }
            }
            catch { }

            return
                string.Empty;
        }
        
        /// <summary>
        /// Obtenir les options de combo box OUI ou NON
        /// </summary>
        public static string HTML_Oui_Non()
        {
            return
                $"<option value=\"true\" title=\"{App_Lang.Lang.Yes}\">{App_Lang.Lang.Yes}</option>" +
                $"<option value=\"false\" title=\"{App_Lang.Lang.No}\">{App_Lang.Lang.No}</option>";
        }

        /// <summary>
        /// Obtenir les options de combo box OUI ou NON
        /// </summary>
        public static string HTML_Non_Oui()
        {
            return
                $"<option value=\"false\" title=\"{App_Lang.Lang.No}\">{App_Lang.Lang.No}</option>" +
                $"<option value=\"true\" title=\"{App_Lang.Lang.Yes}\">{App_Lang.Lang.Yes}</option>";
        }

        /// <summary>
        /// Obtenir les options de combo box FULL ou DIFFERENTIAL
        /// </summary>
        public static string HTML_Methode_de_sauvegarde()
        {
            return
                $"<option value=\"{"FULL"}\" title=\"{App_Lang.Lang.Full}\">{App_Lang.Lang.Full}</option>" +
                $"<option value=\"{"DIFFERENTIAL"}\" title=\"{App_Lang.Lang.Differential}\">{App_Lang.Lang.Differential}</option>";
        }

        /// <summary>
        /// Obtenir les options de combo box FULL ou DIFFERENTIAL
        /// </summary>
        public static string HTML_methode_de_post_interet_reserver()
        {
            return
                $"<option value=\"{"SOLDE"}\" title=\"{App_Lang.Lang.Balance}\">{App_Lang.Lang.Balance}</option>" +
                $"<option value=\"{"DERNIERMVT"}\" title=\"{App_Lang.Lang.Last_transaction}\">{App_Lang.Lang.Last_transaction}</option>";
        }

        /// <summary>
        /// Obtenir les options de combo box type de produit
        /// </summary>
        public static string HTML_type_produit()
        {
            return
                $"<option value=\"{"SAVING"}\" title=\"{App_Lang.Lang.Saving}\">{App_Lang.Lang.Saving}</option>" +
                $"<option value=\"{"CURRENT"}\" title=\"{App_Lang.Lang.Current}\">{App_Lang.Lang.Current}</option>" +
                $"<option value=\"{"LOAN"}\" title=\"{App_Lang.Lang.Loan}\">{App_Lang.Lang.Loan}</option>" +
                $"<option value=\"{"UNPAID"}\" title=\"{App_Lang.Lang.Unpaid}\">{App_Lang.Lang.Unpaid}</option>" +
                $"<option value=\"{"LITIGATION"}\" title=\"{App_Lang.Lang.Litigation}\">{App_Lang.Lang.Litigation}</option>" +
                //$"<option value=\"{"TERM DEPOSIT"}\" title=\"{App_Lang.Lang.Time_deposit}\">{App_Lang.Lang.Time_deposit}</option>" +
                $"<option value=\"{"TIME DEPOSIT"}\" title=\"{App_Lang.Lang.Time_deposit}\">{App_Lang.Lang.Time_deposit}</option>" +
                $"<option value=\"{"RESERVE INTEREST"}\" title=\"{App_Lang.Lang.Reserve_interest}\">{App_Lang.Lang.Reserve_interest}</option>" +
                $"<option value=\"{"GARANTIE DEPOSIT"}\" title=\"{App_Lang.Lang.Garantie_deposit}\">{App_Lang.Lang.Current}</option>" +
                $"<option value=\"{"COLLECTION"}\" title=\"{"Collection"}\">{"Collection"}</option>";
        }
    }
}