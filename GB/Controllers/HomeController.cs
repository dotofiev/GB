using GB.Models;
using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class HomeController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Authentication()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"Global Bank - ({App_Lang.Lang.Authentication})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees("Home-Authentication");

            // -- Initialiser l'object connexion de l'utilisateur -- //
            this.con = new Connexion(Session.SessionID);

            // -- Test -- //
            this.ViewBag.Test.compte = TestClass.compte;
            this.ViewBag.Test.mot_de_passe = TestClass.mot_de_passe;

            return View();
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public ActionResult Connexion(string compte, string mot_de_passe)
        {
            try
            {
                // -- Vérifier la conformité des données -- //
                if (compte != TestClass.compte || mot_de_passe != TestClass.mot_de_passe)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed);
                }

                // -- Authentifier l'objet connexion -- //
                this.con.Authentification(compte, mot_de_passe);

                // -- Notification -- //
                this.ViewBag.notification = new GBNotification(
                                                new {
                                                    url = Url.Action("Main", "Application")
                                                }
                                            );
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(true);
                }
                else
                {
                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(ex.Message, true);
                }
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GBConvert.To_Object(this.ViewBag)
            );
        }

        [HttpPost]
        public ActionResult Deconnexion()
        {
            try
            {
                // -- Déconnexion de l'objet connexion -- //
                this.con.Deconnexion();

                // -- Notification -- //
                this.ViewBag.notification = new GBNotification(
                                                new
                                                {
                                                    url = Url.Action("Authentication", "Home")
                                                }
                                            );
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(true);
                }
                else
                {
                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(ex.Message, true);
                }
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GBConvert.To_Object(this.ViewBag)
            );
        }
        #endregion

        #region Méthodes
        public override void Charger_Langue_Et_Donnees(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;

            #region Home-Authentication
            if (id_page == "Home-Authentication")
            {
                this.ViewBag.Lang.Login = App_Lang.Lang.Login;
                this.ViewBag.Lang.Password = App_Lang.Lang.Password;
                this.ViewBag.Lang.Application_language = App_Lang.Lang.Application_language;
                this.ViewBag.Lang.English = App_Lang.Lang.English;
                this.ViewBag.Lang.French = App_Lang.Lang.French;
                this.ViewBag.Lang.To_log_in = App_Lang.Lang.To_log_in;

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Lang = new
                                                    {
                                                        Error_server_message = App_Lang.Lang.Error_server_message,
                                                    },
                                                    // -- Paramètres -- //
                                                    DUREE_VISIBILITE_MESSAGE_BOX = AppSettings.DUREE_VISIBILITE_MESSAGE_BOX,
                                                }
                                            );
                #endregion
            }
            #endregion

        }
        #endregion
    }
}