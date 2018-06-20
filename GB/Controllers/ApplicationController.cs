using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    [AuthentificationRequis]
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

        #region Méthodes
        public override void Charger_Langue(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;

            #region Home-Authentication
            if (id_page == "Application-Main")
            {
                // -- Nom de l'utilisateur connecté -- //
                this.ViewBag.donnee.nom_utilisateur = this.con.nom_utilisateur;
                // -- Photo de l'utilisateur connecté -- //
                this.ViewBag.donnee.url_photo_profil = this.con.url_photo_profil;
                // -- Charger les menus de l'utilisateur -- //
                this.ViewBag.Menus = Menu.Source(this.con.id_utilisateur);

                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Profil = App_Lang.Lang.Profile;
                this.ViewBag.Lang.Settings = App_Lang.Lang.Settings;
                this.ViewBag.Lang.Sign_Out = App_Lang.Lang.Sign_Out;
                this.ViewBag.Lang.Welcome = App_Lang.Lang.Welcome;
                this.ViewBag.Lang.Id = id_lang == 0 ? 1 
                                                    : 0;
                this.ViewBag.Lang.Title = id_lang == 0 ? App_Lang.Lang.French
                                                       : App_Lang.Lang.English;
                #endregion
            }
            #endregion

        }
        #endregion
    }
}