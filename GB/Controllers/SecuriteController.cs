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
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_modifier({id})""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-retweet text-warning""></i>
                                        </button>
                                        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({id})""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region Module introuvble
                else
                {
                    throw new Exception("Le id_page n'a pas été retourné!");
                }
                #endregion

                // -- Notification -- //
                this.ViewBag.notification = new GBNotification(donnee);
            }
            #region catch & finally
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
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GBConvert.To_Object(this.ViewBag)
            );
        }

        // -- Selectionner un nouvel enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Selection_Enregistrement(long id, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TestClass.db_modules.FirstOrDefault(l => l.id == id);

                    // -- Vérifier si l'objet est trouvé -- //
                    if (obj == null)
                    {
                        throw new GBException(App_Lang.Lang.Object_not_found);
                    }

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(
                                                    new
                                                    {
                                                        id = obj.id,
                                                        code = obj.code,
                                                        libelle_en = obj.libelle_en,
                                                        libelle_fr = obj.libelle_fr,
                                                    }
                                               );
                }
                #endregion

                #region Module introuvble
                else
                {
                    throw new Exception("Le id_page n'a pas été retourné!");
                }
                #endregion
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

        // -- Enregistrer un nouvel enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Ajouter_Enregistrement(string id_page, Module obj)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Définition de l'identifiant -- //
                    obj.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    TestClass.db_modules.Add(obj);
                }
                #endregion

                #region Module introuvble
                else
                {
                    throw new Exception("Le id_page n'a pas été retourné!");
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.notification = new GBNotification(false);
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

        // -- Enregistrer un nouvel enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Modifier_Enregistrement(Module obj, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Enregistrement de la valeur -- //
                    TestClass.db_modules
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id == obj.id)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj.code;
                            l.libelle_en = obj.libelle_en;
                            l.libelle_fr = obj.libelle_fr;
                        });
                }
                #endregion

                #region Module introuvble
                else
                {
                    throw new Exception("Le id_page n'a pas été retourné!");
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.notification = new GBNotification(false);
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