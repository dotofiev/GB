using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Variables
        public int id_lang { get { if (Session["id_lang"] == null) { return 0; } else { return (int)Session["id_lang"]; } } set { Session["id_lang"] = value; } }
        #endregion

        #region Methodes
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // -- Autoriser la configuration de log4net -- //
            log4net.Config.XmlConfigurator.Configure();

            // -- Définition de la culture de langue par défaut -- //
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(GB_Enum_Langue.Anglais);
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            // -- Log du démarage de l'application -- //
            GBClass.Log.Info("Démarrage de l'application");
        }

        // -- Lorsque la session démare -- //
        protected void Session_OnStart()
        {
            // -- Mise à jour de la langue en fonction du dernier utilisateur connecté -- //
            #region Gestion de langue
            if (Request.Cookies.Get("id_lang") != null)
            {
                // -- Réccupération de l'identifian de la langue -- //
                this.id_lang = Convert.ToInt32(Request.Cookies.Get("id_lang").Value);
            }
            else
            {
                // -- Définition de la langue française par défaut -- //
                this.id_lang = 0;
                // -- Mise à jour de l'identification de la langue dans le cookie -- //
                Response.Cookies["id_lang"].Value = "0";
            }
            #endregion

            // -- Log du début d'une session -- //
            GBClass.Log.Info("Début session: {session:" + Session.SessionID + "}");
        }
        #endregion
    }
}
