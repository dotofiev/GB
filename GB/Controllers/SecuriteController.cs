using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    [AuthentificationRequis]
    public class SecuriteController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Module()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Module_Management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue("Securite-Module");

            return View();
        }
        #endregion

        #region HttpPost
        // -- Charger les données dans la table -- //
        [HttpPost]
        public override ActionResult Charger_Table(string id_page)
        {
            try
            {
                List<object> donnee = new List<object>();

                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    foreach (var val in TestClass.db_modules)
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"module\" value=\"module_{val.id}\">",
                                col_2 = val.id,
                                col_3 = val.code,
                                col_4 = val.libelle_fr,
                                col_5 = val.libelle_en,
                                col_6 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}"" 
                                                              title=""{Lang.Update}"" 
                                                              onclick=""modifier_table_donnee({id})""
                                                              class=""btn btn-xs btn-round btn-warning table-bouton-modifier-iroll""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-retweet""></i>
                                        </button>
                                        <button type=""button"" id=""table_donnee_supprimer_id_{id}"" 
                                                              title=""{Lang.Delete}"" 
                                                              onclick=""supprimer_table_donnee({id}, {ids})""
                                                              class=""btn btn-xs btn-round btn-danger table-bouton-supprimer-iroll""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                // -- Notification -- //
                this.ViewBag.notification = new GBNotification(donnee);
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                // -- Réccupération du message d'exception -- //
                this.ViewBag.notification = new GBNotification(true);
            }
            finally
            {
                // -- Mise à jour les données à renvoyer -- //
                if (this.ViewBag.notification.est_echec)
                {
                    this.ViewBag.notification.donnee = new List<object>();
                }
            }

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GBConvert.To_Object(this.ViewBag)
            );
        }
        #endregion

        #region Méthodes
        public override void Charger_Langue(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;

            #region Securite-Module
            if (id_page == "Securite-Module")
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = App_Lang.Lang.Module_Management;
                this.ViewBag.Lang.Name_french       = App_Lang.Lang.Name + "-" + App_Lang.Lang.French;
                this.ViewBag.Lang.Name_english      = App_Lang.Lang.Name + "-" + App_Lang.Lang.English;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                }
                                            );
                #endregion
            }
            #endregion

        }
        #endregion
    }
}