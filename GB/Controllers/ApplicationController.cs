using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.GB;
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
            Charger_Langue_Et_Donnees(GB_Enum_Menu.Application_Main);

            return View();
        }

        [HttpGet]
        public ActionResult Principale()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"Global Bank - ({App_Lang.Lang.Main})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees("Application-Principale");

            return View();
        }
        #endregion

        #region HttpPost
        #endregion

        #region Méthodes
        public override void Charger_Langue_Et_Donnees(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;

            #region Application-Main
            if (id_page == "Application-Main")
            {
                // -- Nom de l'utilisateur connecté -- //
                this.ViewBag.donnee.nom_utilisateur = this.con.utilisateur.nom_utilisateur;
                // -- Photo de l'utilisateur connecté -- //
                this.ViewBag.donnee.url_photo_profil = this.con.url_photo_profil;
                // -- Charger les menus de l'utilisateur -- //
                this.ViewBag.Menus = Menu.Source(AutorisationDAO.Lister(this.con.utilisateur.id_role));

                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Profil = App_Lang.Lang.Profile;
                this.ViewBag.Lang.Settings = App_Lang.Lang.Settings;
                this.ViewBag.Lang.Sign_Out = App_Lang.Lang.Sign_Out;
                this.ViewBag.Lang.Welcome = App_Lang.Lang.Welcome;
                this.ViewBag.Lang.Id = this.id_lang == 0 ? 1 
                                                    : 0;
                this.ViewBag.Lang.Title = this.id_lang == 0 ? App_Lang.Lang.French
                                                       : App_Lang.Lang.English;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    Lang = new {
                                                            Maintenance_message = App_Lang.Lang.Process_in_production,
                                                            All = App_Lang.Lang.All,
                                                            Update = App_Lang.Lang.Update,
                                                            Save = App_Lang.Lang.Save,
                                                            Confirm_action = App_Lang.Lang.Confirm_action.Replace("'", string.Empty),
                                                            Error_server_message = App_Lang.Lang.Error_server_message,
                                                            No = App_Lang.Lang.No,
                                                            Yes = App_Lang.Lang.Yes,
                                                            Close = App_Lang.Lang.Close,
                                                            No_item_selected = App_Lang.Lang.No_item_selected,
                                                            Select = App_Lang.Lang.Select,
                                                            Necessary_privilege_loading_action = App_Lang.Lang.Necessary_privilege_loading_action,
                                                            Permission_to_list_records_denied = App_Lang.Lang.Permission_to_list_records_denied,
                                                            The_file_must_not_exceed = App_Lang.Lang.The_file_must_not_exceed,
                                                            Empty = App_Lang.Lang.Empty,
                                                            Confirm = App_Lang.Lang.Confirm,
                                                            Cancel = App_Lang.Lang.Cancel,
                                                    },
                                                    // -- Paramètres -- //
                                                    DUREE_VISIBILITE_MESSAGE_BOX = AppSettings.DUREE_VISIBILITE_MESSAGE_BOX,
                                                    TAILLE_MAX_IMAGE_IMPORTATION = AppSettings.TAILLE_MAX_IMAGE_IMPORTATION,
                                                    UTILISATEUR = new {
                                                        id_utilisateur = this.con.utilisateur.id_utilisateur,
                                                        nom_utilisateur = this.con.utilisateur.nom_utilisateur
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region Application-Principale
            else if (id_page == "Application-Principale")
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = App_Lang.Lang.Home;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-home",
                                                        message = App_Lang.Lang.Home
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

        }
        #endregion
    }
}