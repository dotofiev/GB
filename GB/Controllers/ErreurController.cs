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
        public ActionResult Page(string dt, string id_lang)
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Traitement à effectuer -- //
            #region Traitement à effectuer
            try
            {
                // -- Mise à jour de l'etat de la langue -- //
                LangHelper.CurrentCulture = Convert.ToInt32(id_lang);

                // -- Réccupération des variables -- //
                Dictionary<string, string> parametres = GBConvert.JSON_To<Dictionary<string, string>>(Models.Cryptage.Program.DecryptStringAES(dt));

                // -- Code de l'erreur -- //
                this.ViewBag.code = parametres["code"];

                // -- Titre descriptif de l'erreur -- //
                this.ViewBag.message = parametres["code"] == "404" ? App_Lang.Lang.Page_not_found
                                                                   : App_Lang.Lang.Internal_error;

                // -- Message descriptif de l'erreur -- //
                this.ViewBag.description = parametres["code"] == "404" ? App_Lang.Lang.Page_not_found_message
                                                                       : parametres["message"];

                // -- Liend de redirection pour la page d'authentification -- //
                this.ViewBag.url = Url.Action("Authentication", "Home");
                
                // -- Titre de la page -- //
                this.ViewBag.Title = $"Global Bank - ({parametres["code"]} {App_Lang.Lang.Error})";

                // -- Langue -- //
                this.ViewBag.Lang.Reconnect = App_Lang.Lang.Reconnect;
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