using GB.Models;
using GB.Models.Helper;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class ErreurController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Page(string dt)
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Traitement à effectuer -- //
            #region Traitement à effectuer
            try
            {
                // -- Identifiant de la page -- //
                this.ViewBag.Id_page = GB_Enum_Menu.Erreur_Page;

                // -- Réccupération des variables -- //
                Dictionary<string, string> parametres = GBConvert.JSON_To<Dictionary<string, string>>(Models.Cryptage.Program.DecryptStringAES(dt));

                // -- Mise à jour de l'etat de la langue -- //
                LangHelper.CurrentCulture = Convert.ToInt32(parametres["id_lang"]);

                // -- Code de l'erreur -- //
                this.ViewBag.donnee.code = parametres["code"];

                // -- Titre descriptif de l'erreur -- //
                this.ViewBag.donnee.message = parametres["code"] == "404" ? App_Lang.Lang.Page_not_found
                                                                          : App_Lang.Lang.Internal_error;

                // -- Message descriptif de l'erreur -- //
                this.ViewBag.donnee.description = parametres["code"] == "404" ? App_Lang.Lang.Page_not_found_message
                                                                              : (AppSettings.MODE_DEV) ? parametres["message"]
                                                                                                       : App_Lang.Lang.Error_message_notification;

                // -- Liend de redirection pour la page d'authentification -- //
                this.ViewBag.donnee.url = Url.Action("Authentication", "Home");
                
                // -- Titre de la page -- //
                this.ViewBag.donnee.Title = $"Global Bank - ({parametres["code"]} {App_Lang.Lang.Error})";

                // -- Langue -- //
                this.ViewBag.Lang.Reconnect = App_Lang.Lang.Reconnect;

                // -- Réccupération du statut de connexion de l'utilisateur -- //
                this.ViewBag.donnee.reconnecter = Convert.ToBoolean(parametres["reconnecter"]);

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = GB_Enum_Menu.Erreur_Page,
                                                    titre = this.ViewBag.donnee.Title,
                                                    reconnecter = Convert.ToBoolean(parametres["reconnecter"])
                                                }
                                            );
                #endregion
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                // -- Redirection vers la page d'authentification -- //
                return RedirectToAction("Authentication", "Home");
            }
            #endregion

            return View();
        }
        #endregion
    }
}