using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.GB;
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
            Charger_Langue_Et_Donnees(GB_Enum_Menu.Securite_Module);

            return View();
        }

        [HttpGet]
        public ActionResult Role()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Role_and_privilege_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.Securite_Role);

            return View();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Menu_Management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.Securite_Menu);

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
                AutorisationDAO.Verification_Autorisation(id_menu_actif, this.con.utilisateur.id_role, GB_Enum_Action_Controller.Lister, ref autorisation_refuse);

                List<object> donnee = new List<object>();

                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == GB_Enum_Menu.Securite_Module)
                {
                    foreach (var val in ModuleDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "module"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region Securite-Role
                else if (id_page == GB_Enum_Menu.Securite_Role)
                {
                    // -- Si la vue n'est pas soumise -- //
                    if (string.IsNullOrEmpty(id_vue))
                    {
                        foreach (var val in RoleDAO.Lister())
                        {
                            donnee.Add(
                                new
                                {
                                    col_1 = GBClass.HTML_Checkbox_Table(val.id, "role"),
                                    col_2 = val.code,
                                    col_3 = val.libelle_fr,
                                    col_4 = val.libelle_en,
                                    col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                                }
                            );
                        }
                    }
                    // -- Si c'est la vue configuration -- //
                    else if (id_vue == "autorisation")
                    {
                        foreach (var val in (this.con.donnee.autorisation as List<Autorisation>).Where(l => l.id_role == Convert.ToInt64(this.con.donnee.id_role)))
                        {
                            donnee.Add(
                                new
                                {
                                    col_1 = GBClass.HTML_Checkbox_Table(val.id, "autorisation"),
                                    col_2 = val.menu.code,
                                    col_3 = (this.id_lang == 0) ? val.menu.libelle_en 
                                                                : val.menu.libelle_fr,
                                    col_4 = (val.ajouter) ? @"<i class=""fa fa-check fa-2x""></i>"
                                                          : @"<i class=""fa fa-remove fa-2x""></i>",
                                    col_5 = (val.modifier) ? @"<i class=""fa fa-check fa-2x""></i>"
                                                           : @"<i class=""fa fa-remove fa-2x""></i>",
                                    col_6 = (val.supprimer) ? @"<i class=""fa fa-check fa-2x""></i>"
                                                            : @"<i class=""fa fa-remove fa-2x""></i>",
                                    col_7 = (val.imprimer) ? @"<i class=""fa fa-check fa-2x""></i>"
                                                           : @"<i class=""fa fa-remove fa-2x""></i>",
                                    col_8 = (val.lister) ? @"<i class=""fa fa-check fa-2x""></i>"
                                                         : @"<i class=""fa fa-remove fa-2x""></i>"
                                }
                            );
                        }
                    }
                    // -- Si c'est la vue configuration -- //
                    else if (id_vue == "menu")
                    {
                        foreach (var val in (this.con.donnee.autorisation_disponible as List<Autorisation>))
                        {
                            donnee.Add(
                                new
                                {
                                    col_1 = $"<input type=\"checkbox\" class=\"flat\" id_menu=\"{val.id_menu}\" name=\"menu\" value=\"menu_{val.id_menu}\" etat=\"false\" >",
                                    col_2 = (this.id_lang == 0) ? val.menu.libelle_en
                                                                : val.menu.libelle_fr,
                                    col_3 = (this.id_lang == 0) ? val.menu.groupe_menu.libelle_en
                                                                : val.menu.groupe_menu.libelle_fr,
                                    col_4 = (this.id_lang == 0) ? val.menu.groupe_menu.module.libelle_en
                                                                : val.menu.groupe_menu.module.libelle_fr,
                                    col_5 = $"<input type=\"checkbox\" class=\"flat-blue\" id_menu=\"{val.id_menu}\" name=\"ajouter\" etat=\"false\" />",
                                    col_6 = $"<input type=\"checkbox\" class=\"flat-blue\" id_menu=\"{val.id_menu}\" name=\"modifier\" etat=\"false\" />",
                                    col_7 = $"<input type=\"checkbox\" class=\"flat-blue\" id_menu=\"{val.id_menu}\" name=\"supprimer\" etat=\"false\" />",
                                    col_8 = $"<input type=\"checkbox\" class=\"flat-blue\" id_menu=\"{val.id_menu}\" name=\"imprimer\" etat=\"false\" />",
                                    col_9 = $"<input type=\"checkbox\" class=\"flat-blue\" id_menu=\"{val.id_menu}\" name=\"lister\" etat=\"false\" />",
                                }
                            );
                        }
                    }
                }
                #endregion

                #region Securite-Menu
                else if (id_page == GB_Enum_Menu.Securite_Menu)
                {
                    foreach (var val in MenuDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "menu"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = (id_lang == 0) ? val.groupe_menu.libelle_en 
                                                       : val.libelle_fr,
                                col_6 = val.view,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
        public ActionResult Selection_Enregistrement(string code, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == GB_Enum_Menu.Securite_Module)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ModuleDAO.ObjectCode(code);

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

                #region Securite-Role
                else if (id_page == GB_Enum_Menu.Securite_Role)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = RoleDAO.ObjectCode(code);

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

                #region Securite-Menu
                else if (id_page == GB_Enum_Menu.Securite_Menu)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = MenuDAO.ObjectCode(code);

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
                                                        id_controller = obj.id_controller,
                                                        view = obj.view,
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

        // -- Rchercher les autorisations d'un role -- //
        [HttpPost]
        public ActionResult Role_Rechercher_Autorisation(string id_role)
        {
            try
            {
                // -- Départ de l'id session -- //
                long id_autorisation = Convert.ToInt32(AutorisationDAO.Crer_Id()) + 1;
                // -- Définition de l'id_role rechercher -- //
                this.con.donnee.id_role = id_role;
                // -- Mise à jour des autorisation -- //
                this.con.donnee.autorisation = new List<Autorisation>();
                (this.con.donnee.autorisation as List<Autorisation>).AddRange(AutorisationDAO.Lister(id_role));
                // -- Mise à jour des autorisation disponible -- //
                this.con.donnee.autorisation_disponible = new List<Autorisation>();
                (this.con.donnee.autorisation_disponible as List<Autorisation>).AddRange(
                    MenuDAO.Lister()
                           .Where(l =>
                                (this.con.donnee.autorisation as List<Autorisation>).Count(ll => ll.id == l.id) == 0
                           )
                           .Select(l =>
                                new Autorisation()
                                {
                                    id = (id_autorisation++).ToString(),
                                    code = (id_autorisation - 1).ToString(),
                                    ajouter = false,
                                    modifier = false,
                                    supprimer = false,
                                    imprimer = false,
                                    lister = false,
                                    id_menu = l.id,
                                    id_role = id_role,
                                    menu = l,
                                    role = RoleDAO.Object(id_role)
                                }
                            )
                );

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

        // -- Rchercher les autorisations d'un role -- //
        [HttpPost]
        public ActionResult Role_Modifier_Autorisation(string ids, string id_action, string etat)
        {
            try
            {
                // -- Mise à jour des autorisation en session -- //
                GBConvert.JSON_To<List<string>>(ids).ForEach(id_menu =>
                {
                    if (id_action == "1")
                    {
                        (this.con.donnee.autorisation as List<Autorisation>).FirstOrDefault(l => l.id_menu == id_menu).ajouter = (etat == "1");
                    }
                    else if (id_action == "2")
                    {
                        (this.con.donnee.autorisation as List<Autorisation>).FirstOrDefault(l => l.id_menu == id_menu).modifier = (etat == "1");
                    }
                    else if (id_action == "3")
                    {
                        (this.con.donnee.autorisation as List<Autorisation>).FirstOrDefault(l => l.id_menu == id_menu).supprimer = (etat == "1");
                    }
                    else if (id_action == "4")
                    {
                        (this.con.donnee.autorisation as List<Autorisation>).FirstOrDefault(l => l.id_menu == id_menu).imprimer = (etat == "1");
                    }
                    else
                    {
                        (this.con.donnee.autorisation as List<Autorisation>).FirstOrDefault(l => l.id_menu == id_menu).lister = (etat == "1");
                    }
                });

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

        // -- Ajouter ou supprimer des menus à un rôle -- //
        [HttpPost]
        public ActionResult Role_Ajouter_Supprimer_Menu(string data, Boolean ajouter)
        {
            try
            {
                // -- Traitement en fonction de l'action -- //
                #region ajouter
                if (ajouter)
                {
                    // -- Convertion de la selection -- //
                    List<Autorisation> selection = GBConvert.JSON_To<List<Autorisation>>(data);

                    // -- Suppression des autorisation non configuré -- //
                    selection.RemoveAll(l => !l.ajouter && !l.modifier && !l.supprimer && !l.imprimer && !l.lister);

                    // -- Vérifier si la liste contient encore des données -- //
                    if (selection.Count == 0)
                    {
                        throw new GBException("Aucun menu configuré!");
                    }

                    // -- Suppression des autorisations disponible -- //
                    (this.con.donnee.autorisation_disponible as List<Autorisation>).RemoveAll(l => selection.Count(ll => ll.id_menu == l.id_menu) != 0);

                    // -- Mise à jour des references de la selection -- //
                    selection.ForEach(l =>
                    {
                        l.id_role = Convert.ToInt64(this.con.donnee.id_role);
                        l.role = RoleDAO.Object(Convert.ToInt64(this.con.donnee.id_role));
                        l.menu = MenuDAO.Object(l.id_menu);
                    });

                    // -- AJout dans les autorisation temporaire -- //
                    (this.con.donnee.autorisation as List<Autorisation>).AddRange(selection);
                }
                #endregion

                #region supprimer
                else
                {
                    // -- Convertion de la selection -- //
                    List<string> ids = GBConvert.JSON_To<List<string>>(data);

                    // -- Suppression dans les autorisation temporaire -- //
                    (this.con.donnee.autorisation as List<Autorisation>).RemoveAll(l => ids.Count(ll => ll == l.id_menu) != 0);

                    // -- Ajout à la liste des autorisations disponible -- //
                    ids.ForEach(id_menu =>
                    {
                        (this.con.donnee.autorisation_disponible as List<Autorisation>).Add(
                            new Autorisation
                            {
                                id = GBClass.id_par_defaut,
                                id_menu = id_menu,
                                id_role = Convert.ToInt64(this.con.donnee.id_role),
                                ajouter = false,
                                modifier = false,
                                supprimer = false,
                                imprimer = false,
                                lister = false,
                                role = RoleDAO.Object(Convert.ToInt64(this.con.donnee.id_role)),
                                menu = MenuDAO.Object(id_menu)
                            }
                        );
                    });
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

        // -- Enregistrer les modifications survenue sur les autorisations -- //
        [HttpPost]
        public ActionResult Role_Enregistrer_Modification()
        {
            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                Verifier_Autorisation(GB_Enum_Action_Controller.Modifier);

                // -- Mise à jour des traitements -- //
                autorisationDAO.Modifier((this.con.donnee.autorisation as List<Autorisation>), this.con.donnee.id_role);

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
        public ActionResult Ajouter_Enregistrement(string id_page, string obj)
        {
            try
            {
                // -- Vérifier l'autorisation de l'action -- //
                Verifier_Autorisation(GB_Enum_Action_Controller.Ajouter);

                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == GB_Enum_Menu.Securite_Module)
                {
                    // -- Service d'enregistrement -- //
                    moduleDAO.Ajouter(GBConvert.JSON_To<Module>(obj));
                }
                #endregion

                #region Securite-Role
                else if (id_page == GB_Enum_Menu.Securite_Role)
                {
                    // -- Service d'enregistrement -- //
                    roleDAO.Ajouter(GBConvert.JSON_To<Role>(obj));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == GB_Enum_Menu.Securite_Menu)
                {
                    // -- Service d'enregistrement -- //
                    menuDAO.Ajouter(GBConvert.JSON_To<Menu>(obj));
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
                #region Securite-Module
                if (id_page == GB_Enum_Menu.Securite_Module)
                {
                    // -- Service de modification -- //
                    moduleDAO.Modifier(GBConvert.JSON_To<Module>(obj));
                }
                #endregion

                #region Securite-Role
                else if (id_page == GB_Enum_Menu.Securite_Role)
                {
                    // -- Service de modification -- //
                    roleDAO.Modifier(GBConvert.JSON_To<Role>(obj));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == GB_Enum_Menu.Securite_Menu)
                {
                    // -- Service de modification -- //
                    menuDAO.Modifier(GBConvert.JSON_To<Menu>(obj));
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
                #region Securite-Module
                if (id_page == GB_Enum_Menu.Securite_Module)
                {
                    // -- Service de suppression -- //
                    moduleDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region Securite-Role
                else if (id_page == GB_Enum_Menu.Securite_Role)
                {
                    // -- Service de suppression -- //
                    roleDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == GB_Enum_Menu.Securite_Menu)
                {
                    // -- Service de suppression -- //
                    menuDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
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


        // -- Retourner le fichier de la langue à affecter aux tables de données -- //
        [HttpPost]
        public ActionResult Arbre_Menu(string id_controller)
        {
            try
            {
                // -- Resultat -- //
                string donnee = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                if (!string.IsNullOrEmpty(id_controller))
                {
                    // -- réccupération du contenu JSON -- //
                    dynamic dynamic_obj = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(url_data + "arbre_menu.json"));

                    // -- Parcours de la liste -- //
                    for (int i = 0; i < (dynamic_obj as Newtonsoft.Json.Linq.JArray).Count; i++)
                    {
                        // -- Vérifier si c'est le bon controlleur -- //
                        if (id_controller == Convert.ToString((dynamic_obj[i]["controller"]["id"] as Newtonsoft.Json.Linq.JValue).Value))
                        {
                            // -- Parcourir les vues -- //
                            foreach (var vue in (dynamic_obj[i]["views"] as Newtonsoft.Json.Linq.JArray))
                            {
                                // -- AJouter les vues -- //
                                donnee += $"<option value=\"{(vue as Newtonsoft.Json.Linq.JValue).Value}\" title=\"{(vue as Newtonsoft.Json.Linq.JValue).Value}\">{(vue as Newtonsoft.Json.Linq.JValue).Value}</option>";
                            }
                        }
                    }
                }

                // -- Notificication -- //
                this.ViewBag.notification = new GBNotification(donnee);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                // -- Notificication -- //
                this.ViewBag.notification = new GBNotification(true);
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

            #region Securite-Module
            if (id_page == GB_Enum_Menu.Securite_Module)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Module_Management;
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
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Module_Management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region Securite-Role
            else if (id_page == GB_Enum_Menu.Securite_Role)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Role_and_privilege_management;
                this.ViewBag.Lang.Rules = App_Lang.Lang.Rules;
                this.ViewBag.Lang.Enable = App_Lang.Lang.Enable;
                this.ViewBag.Lang.Disable = App_Lang.Lang.Disable;
                this.ViewBag.Lang.Add = App_Lang.Lang.Add;
                this.ViewBag.Lang.Modify = App_Lang.Lang.Modify;
                this.ViewBag.Lang.Delete = App_Lang.Lang.Delete;
                this.ViewBag.Lang.Print = App_Lang.Lang.Print;
                this.ViewBag.Lang.Listing = App_Lang.Lang.Listing;
                this.ViewBag.Lang.Save = App_Lang.Lang.Save;
                this.ViewBag.Lang.Rule_Management = App_Lang.Lang.Rule_Management;
                this.ViewBag.Lang.Privilege_management = App_Lang.Lang.Privilege_management;
                this.ViewBag.Lang.Search_a_role = App_Lang.Lang.Search_a_role;
                this.ViewBag.Lang.Search = App_Lang.Lang.Search;
                this.ViewBag.Lang.Search_by = App_Lang.Lang.Search_by;
                this.ViewBag.Lang.New_menus = App_Lang.Lang.New_menus;
                this.ViewBag.Lang.Delete_menus = App_Lang.Lang.Delete_menus;
                this.ViewBag.Lang.Select = App_Lang.Lang.Select;
                this.ViewBag.Lang.Menu_group = App_Lang.Lang.Menu_group;
                this.ViewBag.Lang.Add_ = App_Lang.Lang.Add_;
                this.ViewBag.Lang.Mod_ = App_Lang.Lang.Mod_;
                this.ViewBag.Lang.Del_ = App_Lang.Lang.Del_;
                this.ViewBag.Lang.Prt_ = App_Lang.Lang.Prt_;
                this.ViewBag.Lang.Lst_ = App_Lang.Lang.Lst_;
                this.ViewBag.Lang.Display = App_Lang.Lang.Display;

                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_Role
                dynamic donnee = roleDAO.HTML_Select();
                this.ViewBag.donnee.HTML_Select_code_role = donnee.html_code;
                this.ViewBag.donnee.HTML_Select_libelle_role = donnee.html_libelle;
                #endregion
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Role_and_privilege_management
                                                    }
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- id_role -- //
                this.con.donnee.id_role = 0;
                // -- Autorisations -- //
                this.con.donnee.autorisation = new List<Autorisation>();
                // -- autorisation_disponible -- //
                this.con.donnee.autorisation_disponible = new List<Autorisation>();
                #endregion
            }
            #endregion

            #region Securite-Menu
            else if (id_page == GB_Enum_Menu.Securite_Menu)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Menu_Management;
                this.ViewBag.Lang.Menu_group = App_Lang.Lang.Menu_group;
                this.ViewBag.Lang.Views = App_Lang.Lang.Views;
                this.ViewBag.Lang.Select = App_Lang.Lang.Select;
                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_id_controller
                this.ViewBag.donnee.HTML_Select_id_controller = GroupeMenuDAO.HTML_Select("libelle");
                #endregion
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Menu_Management
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