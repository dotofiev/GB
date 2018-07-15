﻿using GB.Models;
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
    public class SecuriteUtilisateurController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Utilisateur()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.User_Management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.SecuriteUtilisateur_Utilisateur);

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
                #region SecuriteUtilisateur-Utilisateur
                if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
                {
                    foreach (var val in UtilisateurDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"utilisateur\" value=\"utilisateur_{val.id_utilisateur}\">",
                                col_4 = val.agence?.code ?? string.Empty,
                                col_2 = val.compte,
                                col_3 = val.nom_utilisateur,
                                col_5 = val.profession?.libelle ?? string.Empty,
                                col_6 = GBToString.Oui_Non(val.ouverture_back_date),
                                col_7 = GBToString.Oui_Non(val.ouverture_branch),
                                col_8 = GBToString.Oui_Non(val.ouverture_back_date_travail),
                                col_9 = GBToString.Oui_Non(val.est_suspendu),
                                col_10 = GBToString.Oui_Non(val.acces_historique_compte),
                                col_11 = $"{val.duree_mot_de_passe} {App_Lang.Lang.Month}(s)",
                                col_12 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
                                                              title=""{Lang.Delete}"" 
                                                              class=""btn btn-xs btn-round""
                                                              onClick=""table_donnee_supprimer({ids}, true)""
                                                              data-loading-text=""<i class='fa fa-circle-o-notch fa-spin'></i>"">
                                          <i class=""fa fa-minus text-danger""></i>
                                        </button>"
                                        .Replace("{id}", val.id_utilisateur.ToString())
                                        .Replace("{ids}", GBConvert.To_JavaScript(new long[] { val.id_utilisateur }))
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

                #region Module introuvable
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
        public ActionResult Selection_Enregistrement(string compte, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region SecuriteUtilisateur-Utilisateur
                if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = UtilisateurDAO.Object(compte);

                    // -- Vérifier si l'objet est trouvé -- //
                    if (obj == null)
                    {
                        throw new GBException(App_Lang.Lang.Object_not_found);
                    }

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(
                                                    new
                                                    {
                                                        id_utilisateur = obj.id_utilisateur,
                                                        id_agence = obj.id_agence,
                                                        id_profession = obj.id_profession,
                                                        compte = obj.compte,
                                                        nom_utilisateur = obj.nom_utilisateur,
                                                        mot_de_passe = obj.mot_de_passe,
                                                        ouverture_back_date = obj.ouverture_back_date.ToString(),
                                                        ouverture_back_date_travail = obj.ouverture_back_date_travail.ToString(),
                                                        ouverture_branch = obj.ouverture_branch.ToString(),
                                                        est_connecte = obj.est_connecte.ToString(),
                                                        est_suspendu = obj.est_suspendu.ToString(),
                                                        modifier_mot_de_passe = obj.modifier_mot_de_passe.ToString(),
                                                        acces_historique_compte = obj.acces_historique_compte.ToString(),
                                                        duree_mot_de_passe = obj.duree_mot_de_passe
                                                    }
                                               );
                }
                #endregion

                #region Module introuvable
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
                #region SecuriteUtilisateur-Utilisateur
                if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
                {
                    // -- Service d'enregistrement -- //
                    UtilisateurDAO.Ajouter(GBConvert.JSON_To<Utilisateur>(obj));
                }
                #endregion

                #region Module introuvable
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
                #region SecuriteUtilisateur-Utilisateur
                if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
                {
                    // -- Service de modification -- //
                    UtilisateurDAO.Modifier(GBConvert.JSON_To<Utilisateur>(obj));
                }
                #endregion

                #region Module introuvable
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
                #region SecuriteUtilisateur-Utilisateur
                if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
                {
                    // -- Service de suppression -- //
                    UtilisateurDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region Module introuvable
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

            #region SecuriteUtilisateur-Utilisateur
            if (id_page == GB_Enum_Menu.SecuriteUtilisateur_Utilisateur)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.User_Management;
                this.ViewBag.Lang.Login = App_Lang.Lang.Login;
                this.ViewBag.Lang.Name = App_Lang.Lang.Name;
                this.ViewBag.Lang.Agency = App_Lang.Lang.Agency;
                this.ViewBag.Lang.Job = App_Lang.Lang.Job;
                this.ViewBag.Lang.Open_back_date = App_Lang.Lang.Open_back_date;
                this.ViewBag.Lang.Open_back_working_date = App_Lang.Lang.Open_back_working_date;
                this.ViewBag.Lang.Open_branch = App_Lang.Lang.Open_branch;
                this.ViewBag.Lang.Connection_status = App_Lang.Lang.Connection_status;
                this.ViewBag.Lang.Suspended = App_Lang.Lang.Suspended;
                this.ViewBag.Lang.Password_expiration = App_Lang.Lang.Password_expiration;
                this.ViewBag.Lang.Employee_historical_access = App_Lang.Lang.Employee_historical_access;
                this.ViewBag.Lang.Password = App_Lang.Lang.Password;
                this.ViewBag.Lang.Value = App_Lang.Lang.Value;
                this.ViewBag.Lang.Confirm = App_Lang.Lang.Confirm;
                this.ViewBag.Lang.Activate_edit = App_Lang.Lang.Activate_edit;
                this.ViewBag.Lang.Expiration_duration = App_Lang.Lang.Expiration_duration;
                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_agence
                this.ViewBag.donnee.HTML_Select_code_agence =
                    $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                this.ViewBag.donnee.HTML_Select_libelle_agence =
                    $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                foreach (var val in AgenceDAO.Lister())
                {
                    this.ViewBag.donnee.HTML_Select_code_agence +=
                        $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    this.ViewBag.donnee.HTML_Select_libelle_agence +=
                        $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                }
                #endregion
                #region HTML_Select_profession
                this.ViewBag.donnee.HTML_Select_code_profession =
                    $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                this.ViewBag.donnee.HTML_Select_libelle_profession =
                    $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                foreach (var val in ProfessionDAO.Lister())
                {
                    this.ViewBag.donnee.HTML_Select_code_profession +=
                        $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    this.ViewBag.donnee.HTML_Select_libelle_profession +=
                        $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                }
                #endregion
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.User_Management
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