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
    }
}