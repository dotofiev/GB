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
    }
}