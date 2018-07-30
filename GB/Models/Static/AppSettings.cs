using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class AppSettings
    {
        public static string VERSION_BUILD { get { return System.Configuration.ConfigurationManager.AppSettings["VERSION_BUILD"]; } }
        public static string ENCRYPTION_KEY_AES { get { return System.Configuration.ConfigurationManager.AppSettings["ENCRYPTION_KEY_AES"]; } }
        public static string URL_APPLICATION { get { return System.Configuration.ConfigurationManager.AppSettings["URL_APPLICATION"]; } }
        public static string APP_NAME { get { return System.Configuration.ConfigurationManager.AppSettings["APP_NAME"]; } }
        public static int DUREE_VISIBILITE_MESSAGE_BOX { get { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DUREE_VISIBILITE_MESSAGE_BOX"]); } }
        public static int TAILLE_MAX_IMAGE_IMPORTATION { get { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TAILLE_MAX_IMAGE_IMPORTATION"]); } }
        public static string FORMAT_DATE { get { return System.Configuration.ConfigurationManager.AppSettings["FORMAT_DATE"]; } }
        public static bool DONNEE_EN_TEMPS_REEL { get { return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["DONNEE_EN_TEMPS_REEL"]); } }
    }
}