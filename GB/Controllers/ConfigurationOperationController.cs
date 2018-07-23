using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Static;
using GB.Models.Tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    [AuthentificationRequis]
    public class ConfigurationOperationController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult TypePret()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Loans_type_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_TypePret);

            return View();
        }

        [HttpGet]
        public ActionResult MotifPret()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Loans_purpose_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_MotifPret);

            return View();
        }

        [HttpGet]
        public ActionResult ClassificationProvisionsPret()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Loans_provision_classification_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret);

            return View();
        }

        [HttpGet]
        public ActionResult TypeGarantie()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Guarantee_type_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_TypeGarantie);

            return View();
        }

        [HttpGet]
        public ActionResult Journal()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Journals_recording_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_Journal);

            return View();
        }

        [HttpGet]
        public ActionResult TypeActif()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Assets_type_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_TypeActif);

            return View();
        }
        #endregion

        #region HttpPost
        // -- Charger les données dans la table -- //
        [HttpPost]
        public override ActionResult Charger_Table(string id_page, string id_vue)
        {
            // -- Variable temporaire de refu d'autorisation -- //
            Boolean autorisation_refuse = false;

            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                AutorisationDAO.Verification_Autorisation(id_menu_actif, this.con.id_role, GB_Enum_Action_Controller.Lister, ref autorisation_refuse);

                List<object> donnee = new List<object>();

                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    foreach (var val in TypePretDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"typePret\" value=\"typePret_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = GBToString.PeriodiciteDePret(val.periodicite),
                                col_5 = val.periode_debut,
                                col_6 = val.periode_fin,
                                col_7 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    foreach (var val in MotifPretDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"motifPret\" value=\"motifPret_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    foreach (var val in ClassificationProvisionsPretDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"classificationProvisionsPret\" value=\"classificationProvisionsPret_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.nombre_jour_debut,
                                col_5 = val.nombre_jour_fin,
                                col_6 = $"{val.pourcentage} %",
                                col_7 = GBToString.FormuleClassificationProvisionsPret(val.formule),
                                col_8 = GBToString.TypeClassificationProvisionsPret(val.type),
                                col_9 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    foreach (var val in TypeGarantieDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"typeGarantie\" value=\"typeGarantie_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = GBToString.NatureTypeGarantie(val.nature),
                                col_6 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_7 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_8 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    foreach (var val in JournalDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"journal\" value=\"journal_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    foreach (var val in TypeActifDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"typeActif\" value=\"typeActif_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                                //col_5 = @"<button type=""button"" id=""table_donnee_modifier_id_{id}""
                                //                              title=""{Lang.Update}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_modifier({id})""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-retweet text-warning""></i>
                                //        </button>
                                //        <button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                //                              title=""{Lang.Delete}"" 
                                //                              class=""btn btn-xs btn-round""
                                //                              onClick=""table_donnee_supprimer({ids}, true)""
                                //                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                //          <i class=""fa fa-minus text-danger""></i>
                                //        </button>"
                                //        .Replace("{id}", val.id.ToString())
                                //        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id }))
                                //        .Replace("{Lang.Update}", App_Lang.Lang.Update)
                                //        .Replace("{Lang.Delete}", App_Lang.Lang.Delete)
                            }
                        );
                    }
                }
                #endregion

                #region TypePret introuvable
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
            finally
            {
                // -- Mise à jour les données à renvoyer -- //
                if (this.ViewBag.notification.est_echec)
                {
                    this.ViewBag.notification.donnee = new List<object>();

                    // -- Envoi du paramètre si l'autorisation a été refusé -- //
                    this.ViewBag.notification.dynamique.autorisation_refuse = autorisation_refuse;
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
        public ActionResult Selection_Enregistrement(string code, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TypePretDAO.Object(code);

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
                                                        libelle = obj.libelle,
                                                        periode_debut = obj.periode_debut,
                                                        periode_fin = obj.periode_fin,
                                                        periodicite = obj.periodicite,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = MotifPretDAO.Object(code);

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
                                                        libelle = obj.libelle,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ClassificationProvisionsPretDAO.Object(code);

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
                                                        libelle = obj.libelle,
                                                        nombre_jour_debut = obj.nombre_jour_debut,
                                                        nombre_jour_fin = obj.nombre_jour_fin,
                                                        formule = obj.formule,
                                                        type = obj.type,
                                                        pourcentage = obj.pourcentage,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TypeGarantieDAO.Object(code);

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

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = JournalDAO.Object(code);

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
                                                        libelle = obj.libelle,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TypeActifDAO.Object(code);

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
                                                        libelle = obj.libelle,
                                                    }
                                               );
                }
                #endregion

                #region TypePret introuvable
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
        public ActionResult Ajouter_Enregistrement(string id_page, string obj)
        {
            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                Verifier_Autorisation(GB_Enum_Action_Controller.Ajouter);

                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    // -- Service d'enregistrement -- //
                    TypePretDAO.Ajouter(GBConvert.JSON_To<TypePret>(obj));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service d'enregistrement -- //
                    MotifPretDAO.Ajouter(GBConvert.JSON_To<MotifPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service d'enregistrement -- //
                    ClassificationProvisionsPretDAO.Ajouter(GBConvert.JSON_To<ClassificationProvisionsPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service d'enregistrement -- //
                    TypeGarantieDAO.Ajouter(GBConvert.JSON_To<TypeGarantie>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service d'enregistrement -- //
                    JournalDAO.Ajouter(GBConvert.JSON_To<Journal>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service d'enregistrement -- //
                    TypeActifDAO.Ajouter(GBConvert.JSON_To<TypeActif>(obj));
                }
                #endregion

                #region TypePret introuvable
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

        // -- Modifier un enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Modifier_Enregistrement(string obj, string id_page)
        {
            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                Verifier_Autorisation(GB_Enum_Action_Controller.Modifier);

                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    // -- Service de modification -- //
                    TypePretDAO.Modifier(GBConvert.JSON_To<TypePret>(obj));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service de modification -- //
                    MotifPretDAO.Modifier(GBConvert.JSON_To<MotifPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service de modification -- //
                    ClassificationProvisionsPretDAO.Modifier(GBConvert.JSON_To<ClassificationProvisionsPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service de modification -- //
                    TypeGarantieDAO.Modifier(GBConvert.JSON_To<TypeGarantie>(obj));
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service de modification -- //
                    JournalDAO.Modifier(GBConvert.JSON_To<Journal>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service de modification -- //
                    TypeActifDAO.Modifier(GBConvert.JSON_To<TypeActif>(obj));
                }
                #endregion

                #region TypePret introuvable
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

        // -- Modifier un enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Supprimer_Enregistrement(string ids, string id_page)
        {
            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                Verifier_Autorisation(GB_Enum_Action_Controller.Supprimer);

                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    // -- Service de suppression -- //
                    TypePretDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service de suppression -- //
                    MotifPretDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service de suppression -- //
                    ClassificationProvisionsPretDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service de suppression -- //
                    TypeGarantieDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service de suppression -- //
                    JournalDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service de suppression -- //
                    TypeActifDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region TypePret introuvable
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
        public override void Charger_Langue_Et_Donnees(string id_page)
        {
            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = id_page;
            
            // -- Définition du menu actif -- //
            id_menu_actif = MenuDAO.Object(id_page.Split('-')[0], id_page.Split('-')[1]).id;

            #region ConfigurationOperation-TypePret
            if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Loans_type_management;
                this.ViewBag.Lang.Name       = App_Lang.Lang.Name;
                this.ViewBag.Lang.Begining_period = App_Lang.Lang.Begining_period;
                this.ViewBag.Lang.Ending_period = App_Lang.Lang.Ending_period;
                this.ViewBag.Lang.Periodicity = App_Lang.Lang.Periodicity;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.HTML_Select_periodicite = GBClass.HTML_periodicite_de_pret();
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Loans_type_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-MotifPret
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Loans_purpose_management;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Loans_purpose_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-ClassificationProvisionsPret
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Loans_provision_classification_management;
                this.ViewBag.Lang.Formula = App_Lang.Lang.Formula;
                this.ViewBag.Lang.Start_days = App_Lang.Lang.Start_days;
                this.ViewBag.Lang.End_days = App_Lang.Lang.End_days;
                this.ViewBag.Lang.Percentage = App_Lang.Lang.Percentage;
                this.ViewBag.Lang.Formula = App_Lang.Lang.Formula;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.HTML_Select_type = GBClass.HTML_type_classification_provisoire_de_pret();
                this.ViewBag.donnee.HTML_Select_formule = GBClass.HTML_formule_classification_provisoire_de_pret();
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Loans_provision_classification_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-TypeGarantie
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Guarantee_type_management;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.HTML_Select_nature = GBClass.HTML_nature_type_garantie();
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Guarantee_type_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-Journal
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Journals_recording_management;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Journals_recording_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-TypeActif
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Assets_type_management;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Assets_type_management
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