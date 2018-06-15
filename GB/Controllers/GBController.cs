using GB.Models.Helper;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class GBController : Controller
    {
        #region Variables
        public int id_lang { get { if (Session["id_lang"] == null) { return 0; } else { return (int)Session["id_lang"]; } } set { Session["id_lang"] = value; } }
        #endregion

        // -- Code de gestion de la langue en session -- //
        #region Code de gestion de la langue en session
        protected override void ExecuteCore()
        {
            try
            {
                int Culture = 0;

                if (this.Session == null || Session["id_lang"] == null)
                {
                    int.TryParse(Thread.CurrentThread.CurrentCulture.Name, out Culture);
                    this.id_lang = Culture;
                }
                else
                {
                    Culture = this.id_lang;
                }

                // -- Mise à jour de l'etat de la langue -- //
                LangHelper.CurrentCulture = Culture;

                base.ExecuteCore();
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }

        [HttpGet]
        public ActionResult Set_Langue(int id_lang)
        {
            // Change the current culture for this user.
            LangHelper.CurrentCulture = id_lang;

            // Cache the new current culture into the user HTTP session. 
            this.id_lang = id_lang;

            // -- Mise à jour de la langue dans le cookie utilisateur -- //
            //MiseAJourCookieLangue(id_lang);

            // -- Effectuer une redirection sur la même page -- // 
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion

        // -- Méthodes -- //
        #region Méthodes
        public virtual void Charger_Langue(string id_page) { }

        public void Charger_Parametres()
        {
            // -- Versio nde l'application -- //
            this.ViewBag.VERSION_BUILD = AppSettings.VERSION_BUILD;

            // -- Paramètres langue -- //
            this.ViewBag.Lang = new System.Dynamic.ExpandoObject();

            // -- Langue de l'application -- //
            this.ViewBag.Lang.code = (this.id_lang == 0) ? GB_Enum_Langue.Anglais
                                                         : GB_Enum_Langue.Francais;

            // -- Label cookiee -- //
            this.ViewBag.Lang.Cookie_message    = App_Lang.Lang.Cookie_message;
            this.ViewBag.Lang.Cookie_button     = App_Lang.Lang.Cookie_button;
            this.ViewBag.Lang.Copyright         = App_Lang.Lang.Copyright;
        }
        #endregion
    }
}