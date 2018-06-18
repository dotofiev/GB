using GB.Models;
using GB.Models.CryptoJS;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class ApplicationController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Main()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"Global Bank - ({App_Lang.Lang.Main})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue("Application-Main");

            return View();
        }
        #endregion

        #region HttpPost
        #endregion

        #region MyRegion
        public override void Charger_Langue(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;

            #region Home-Authentication
            if (id_page == "Application-Application")
            {
                this.ViewBag.Lang.Login_application = App_Lang.Lang.Login_application;
            }
            #endregion

        }
        #endregion
    }
}