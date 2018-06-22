using GB.Models;
using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using Newtonsoft.Json;
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
        public Connexion con { get { return Session["Connexion"] as Connexion; } set { Session["Connexion"] = value; } }
        public int id_lang { get { if (Session["id_lang"] == null) { return 0; } else { return (int)Session["id_lang"]; } } set { Session["id_lang"] = value; } }
        #endregion
        
        #region URLs
        public string url_data { get { return Server.MapPath("~/App_Data/"); } }
        public string url_resources { get { return Server.MapPath("~/Resources/"); } }
        public string url_plugins { get { return Server.MapPath("~/Plugins/"); } }
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
            Set_Cookie_Langue(id_lang);

            // -- Effectuer une redirection sur la même page -- // 
            return Redirect(Request.UrlReferrer.ToString());
        }

        // -- Mise à jour du cookie de langue -- //
        private void Set_Cookie_Langue(int id_lang)
        {
            Response.Cookies["id_lang"].Value = id_lang.ToString();
        }
        #endregion

        // -- Méthodes -- //
        #region Méthodes
        public virtual void Charger_Langue(string id_page) { }
        [HttpPost]
        public virtual ActionResult Charger_Table(string id_page) { return null; }

        public void Charger_Parametres()
        {
            // -- Version de l'application -- //
            this.ViewBag.VERSION_BUILD = AppSettings.VERSION_BUILD;

            // -- Nom de l'application -- //
            this.ViewBag.APP_NAME = AppSettings.APP_NAME;

            // -- Paramètres langue -- //
            this.ViewBag.Lang = new System.Dynamic.ExpandoObject();

            // -- Initialisation des données à traiter -- //
            this.ViewBag.donnee = new System.Dynamic.ExpandoObject();

            // -- Paramètres de test -- //
            this.ViewBag.Test = new System.Dynamic.ExpandoObject();

            // -- Langue de l'application -- //
            this.ViewBag.Lang.code = (this.id_lang == 0) ? GB_Enum_Langue.Anglais
                                                         : GB_Enum_Langue.Francais;

            // -- Label cookiee -- //
            this.ViewBag.Lang.Cookie_message    = App_Lang.Lang.Cookie_message;
            this.ViewBag.Lang.Cookie_button     = App_Lang.Lang.Cookie_button;
            this.ViewBag.Lang.Copyright         = App_Lang.Lang.Copyright;
            this.ViewBag.Lang.Process           = App_Lang.Lang.Process;

            // -- Lable bouton -- //
            this.ViewBag.Lang.New       = App_Lang.Lang.New;
            this.ViewBag.Lang.Delete    = App_Lang.Lang.Delete;
            this.ViewBag.Lang.Save      = App_Lang.Lang.Save;
            this.ViewBag.Lang.Print     = App_Lang.Lang.Print;
            this.ViewBag.Lang.Close     = App_Lang.Lang.Close;
            this.ViewBag.Lang.Form      = App_Lang.Lang.Form;

            // -- Autre -- //
            this.ViewBag.Lang.List_of_records = App_Lang.Lang.List_of_records;
        }

        // -- Retourner le fichier de la langue à affecter aux tables de données -- //
        public object Langue_DataTable()
        {
            try
            {
                return
                    JsonConvert.DeserializeObject(
                        System.IO.File.ReadAllText(url_plugins + "datatables/" + ((LangHelper.CurrentCulture == 0) ? "English.json"
                                                                                                                   : "French.json"))
                    );
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                return null;
            }
        }
        #endregion
    }
}