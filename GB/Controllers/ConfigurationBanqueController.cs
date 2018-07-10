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
    public class ConfigurationBanqueController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Institution()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Institution_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Institution);

            return View();
        }

        [HttpGet]
        public ActionResult Agence()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Agence_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Agence);

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
                #region ConfigurationBanque-Institution
                if (id_page == GB_Enum_Menu.ConfigurationBanque_Institution)
                {
                    foreach (var val in InstitutionDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"institution\" value=\"institution_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.type,
                                col_5 = val.cobac_id,
                                col_6 = val.pub,
                                col_7 = val.motto,
                                col_8 = val.logo?.libelle ?? App_Lang.Lang.Empty,
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

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    foreach (var val in AgenceDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"agence\" value=\"agence_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.pays,
                                col_5 = val.ville,
                                col_6 = val.adresse,
                                col_7 = val.telephone,
                                col_8 = val.bp,
                                col_9 = val.fax,
                                col_10 = val.cobac_id,
                                col_11 = val.beac_id,
                                col_12 = val.utilisateur?.nom_utilisateur?? App_Lang.Lang.Empty,
                                col_13 = val.ip,
                                col_14 = val.mot_de_passe,
                                col_15 = @"<button type=""button"" id=""table_donnee_supprimer_id_{id}""
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

                #region Institution introuvble
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

        // -- Charger les données dans le auto complete -- //
        public override object Charger_EasyAutocomplete(string id_page, string id_vue)
        {
            List<object> donnee = new List<object>();

            try
            {
                #region ConfigurationBanque-Agence
                if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Si la liste des utilisateurs en session est vide, la mettre à jour -- //
                    if ((this.con.donnee.utilisateurs as List<Utilisateur>).Count == 0)
                    {
                        this.con.donnee.utilisateurs = UtilisateurDAO.Lister();
                    }

                    // -- Charger la liste des résultats -- //
                    foreach (var val in (this.con.donnee.utilisateurs as List<Utilisateur>))
                    {
                        donnee.Add(
                            new
                            {
                                id_utilisateur = val.id_utilisateur,
                                compte = val.compte,
                                nom_utilisateur = val.nom_utilisateur
                            }
                        );
                    }
                }
                #endregion
            }
            #region catch & finally
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);
                }
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return GBConvert.To_JSONString(donnee);
        }

        // -- Selectionner un nouvel enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Selection_Enregistrement(string code, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region ConfigurationBanque-Institution
                if (id_page == GB_Enum_Menu.ConfigurationBanque_Institution)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = InstitutionDAO.Object(code);

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
                                                        motto = obj.motto,
                                                        pub = obj.pub,
                                                        cobac_id = obj.cobac_id,
                                                        type = obj.type,
                                                        image = (obj.logo.fichier != null && obj.logo.fichier.Length != 0) ? GBConvert.To_Base64Image(obj.logo.fichier, ".jpg") 
                                                                                                                           : null,
                                                        image_statut = (obj.logo?.fichier?.Count() ?? 0) != 0 ? 2 
                                                                                                              : 0, 
                                                        image_libelle = obj.logo.libelle?? App_Lang.Lang.Empty + " ...",
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = AgenceDAO.Object(code);

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
                                                        pays = obj.pays,
                                                        ville = obj.ville,
                                                        adresse = obj.adresse,
                                                        telephone = obj.telephone,
                                                        bp = obj.bp,
                                                        fax = obj.fax,
                                                        cobac_id = obj.cobac_id,
                                                        beac_id = obj.beac_id,
                                                        ip = obj.ip,
                                                        mot_de_passe = obj.mot_de_passe,
                                                        id_utilisateur = obj.id_utilisateur,
                                                        utilisateur_compte = obj.utilisateur?.compte ?? null,
                                                        utilisateur_nom = obj.utilisateur?.nom_utilisateur?? null,
                                                    }
                                               );
                }
                #endregion

                #region Institution introuvble
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
                #region ConfigurationBanque-Institution
                if (obj == null)
                {
                    // -- Mise à jour de l'identifiant de la page -- //
                    id_page = GB_Enum_Menu.ConfigurationBanque_Institution;

                    // -- Réccupération des données -- //
                    Institution obj_type = new Institution()
                    {
                        cobac_id = Request.Params.Get("cobac_id"),
                        code = Request.Params.Get("code"),
                        id = (int)Convert.ToDouble(Request.Params.Get("id")),
                        libelle = Request.Params.Get("libelle"),
                        type = Request.Params.Get("type"),
                        pub = Request.Params.Get("cobac_id"),
                        motto = Request.Params.Get("motto")
                    };

                    // -- Mise à jour du fichier soumis -- //
                    if (Request.Files.Count > 0)
                    {
                        // -- Réccuération du contenur du fichier -- //
                        obj_type.logo.fichier = GBConvert.To_ByteArray(Request.Files[0].InputStream);
                        // -- Réccupération du nom du fichier -- //
                        obj_type.logo.libelle = Request.Files[0].FileName;
                    }

                    // -- Service d'enregistrement -- //
                    InstitutionDAO.Ajouter(obj_type);
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service d'enregistrement -- //
                    AgenceDAO.Ajouter(GBConvert.JSON_To<Agence>(obj));
                }
                #endregion

                #region Institution introuvble
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
                #region ConfigurationBanque-Institution
                if (obj == null)
                {
                    // -- Mise à jour de l'identifiant de la page -- //
                    id_page = GB_Enum_Menu.ConfigurationBanque_Institution;

                    // -- Statut de la modification de l'aimge -- //
                    string image_statut = Request.Params.Get("image_statut");

                    // -- Réccupération des données -- //
                    Institution obj_type = new Institution()
                    {
                        cobac_id = Request.Params.Get("cobac_id"),
                        code = Request.Params.Get("code"),
                        id = (int)Convert.ToDouble(Request.Params.Get("id")),
                        libelle = Request.Params.Get("libelle"),
                        type = Request.Params.Get("type"),
                        pub = Request.Params.Get("cobac_id"),
                        motto = Request.Params.Get("motto")
                    };

                    // -- Mise à jour du fichier soumis -- //
                    // -- AJouter l'image -- //
                    if (image_statut == "1")
                    {
                        if (Request.Files.Count > 0)
                        {
                            // -- Réccuération du contenur du fichier -- //
                            obj_type.logo.fichier = GBConvert.To_ByteArray(Request.Files[0].InputStream);
                            // -- Réccupération du nom du fichier -- //
                            obj_type.logo.libelle = Request.Files[0].FileName;
                        }
                    }
                    // -- Supprimer l'image -- //
                    else if(image_statut == "0")
                    {
                        obj_type.logo = null;
                    }
                    // -- Si non garder la même image -- //
                    else
                    {
                        obj_type.logo = new GBFichier();
                    }

                    // -- Service de modification -- //
                    InstitutionDAO.Modifier(obj_type);
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service de modification -- //
                    AgenceDAO.Modifier(GBConvert.JSON_To<Agence>(obj));
                }
                #endregion

                #region Institution introuvble
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
                #region ConfigurationBanque-Institution
                if (id_page == GB_Enum_Menu.ConfigurationBanque_Institution)
                {
                    // -- Service de suppression -- //
                    InstitutionDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service de suppression -- //
                    AgenceDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region Institution introuvble
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

            #region ConfigurationBanque-Institution
            if (id_page == GB_Enum_Menu.ConfigurationBanque_Institution)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Institution_management;
                this.ViewBag.Lang.Name       = App_Lang.Lang.Name;
                this.ViewBag.Lang.Abbreviation = App_Lang.Lang.Abbreviation;
                this.ViewBag.Lang.Browse = App_Lang.Lang.Browse;
                this.ViewBag.Lang.Empty = App_Lang.Lang.Empty;
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

            #region ConfigurationBanque-Agence
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Agence_management;
                this.ViewBag.Lang.Name = App_Lang.Lang.Name;
                this.ViewBag.Lang.Countrie = App_Lang.Lang.Countrie;
                this.ViewBag.Lang.Town = App_Lang.Lang.Town;
                this.ViewBag.Lang.Address = App_Lang.Lang.Address;
                this.ViewBag.Lang.Phone = App_Lang.Lang.Phone;
                this.ViewBag.Lang.Postal_code = App_Lang.Lang.Postal_code;
                this.ViewBag.Lang.User = App_Lang.Lang.User;
                this.ViewBag.Lang.IP_Address = App_Lang.Lang.IP_Address;
                this.ViewBag.Lang.Password = App_Lang.Lang.Password;
                this.ViewBag.Lang.Server = App_Lang.Lang.Server;
                this.ViewBag.Lang.Branch_manager = App_Lang.Lang.Branch_manager;
                this.ViewBag.Lang.Login = App_Lang.Lang.Login;
                this.ViewBag.Lang.Search_by = App_Lang.Lang.Search_by;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- Utilisateur -- //
                this.con.donnee.utilisateurs = new List<Utilisateur>();
                #endregion
            }
            #endregion

        }
        #endregion
    }
}