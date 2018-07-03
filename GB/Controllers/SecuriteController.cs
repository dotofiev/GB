using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Static;
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
            Charger_Langue_Et_Donnees("Securite-Module");

            return View();
        }

        [HttpGet]
        public ActionResult Role()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Rule_Management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees("Securite-Role");

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
            Charger_Langue_Et_Donnees("Securite-Menu");

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
                    foreach (var val in ModuleDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"module\" value=\"module_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
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

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    foreach (var val in RoleDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"role\" value=\"role_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
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
                            }
                        );
                    }
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    foreach (var val in MenuDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"menu\" value=\"menu_{val.id}\">",
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = (id_lang == 0) ? val.groupe_menu.libelle_en 
                                                       : val.libelle_fr,
                                col_6 = val.view,
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
        public ActionResult Selection_Enregistrement(string code, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ModuleDAO.Object(code);

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
                else if (id_page == "Securite-Role")
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = RoleDAO.Object(code);

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
                else if (id_page == "Securite-Menu")
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = MenuDAO.Object(code);

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
        public ActionResult Ajouter_Enregistrement(string id_page, string obj)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Service d'enregistrement -- //
                    ModuleDAO.Ajouter(GBConvert.JSON_To<Module>(obj));
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Service d'enregistrement -- //
                    RoleDAO.Ajouter(GBConvert.JSON_To<Role>(obj));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Service d'enregistrement -- //
                    MenuDAO.Ajouter(GBConvert.JSON_To<Menu>(obj));
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

        // -- Modifier un enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Modifier_Enregistrement(string obj, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Service de modification -- //
                    ModuleDAO.Modifier(GBConvert.JSON_To<Module>(obj));
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Service de modification -- //
                    RoleDAO.Modifier(GBConvert.JSON_To<Role>(obj));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Service de modification -- //
                    MenuDAO.Modifier(GBConvert.JSON_To<Menu>(obj));
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

        // -- Modifier un enregistrement dans la liste -- //
        [HttpPost]
        public ActionResult Supprimer_Enregistrement(string ids, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Service de suppression -- //
                    ModuleDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Service de suppression -- //
                    RoleDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Service de suppression -- //
                    MenuDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
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


        // -- Retourner le fichier de la langue à affecter aux tables de données -- //
        [HttpPost]
        public ActionResult Arbre_Menu(long? id_controller)
        {
            try
            {
                // -- Resultat -- //
                string donnee = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                if (id_controller.HasValue)
                {
                    // -- réccupération du contenu JSON -- //
                    dynamic dynamic_obj = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(url_data + "arbre_menu.json"));

                    // -- Parcours de la liste -- //
                    for (int i = 0; i < (dynamic_obj as Newtonsoft.Json.Linq.JArray).Count; i++)
                    {
                        // -- Vérifier si c'est le bon controlleur -- //
                        if (id_controller.Value == Convert.ToInt64((dynamic_obj[i]["controller"]["id"] as Newtonsoft.Json.Linq.JValue).Value))
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

            #region Securite-Module
            if (id_page == "Securite-Module")
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Module_Management;
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

            #region Securite-Role
            else if (id_page == "Securite-Role")
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Rule_Management;
                this.ViewBag.Lang.Name_french = App_Lang.Lang.Name + "-" + App_Lang.Lang.French;
                this.ViewBag.Lang.Name_english = App_Lang.Lang.Name + "-" + App_Lang.Lang.English;
                this.ViewBag.Lang.Rules = App_Lang.Lang.Rules;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                }
                                            );
                #endregion
            }
            #endregion

            #region Securite-Menu
            else if (id_page == "Securite-Menu")
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Menu_Management;
                this.ViewBag.Lang.Name_french = App_Lang.Lang.Name + "-" + App_Lang.Lang.French;
                this.ViewBag.Lang.Name_english = App_Lang.Lang.Name + "-" + App_Lang.Lang.English;
                this.ViewBag.Lang.Menu_group = App_Lang.Lang.Menu_group;
                this.ViewBag.Lang.Views = App_Lang.Lang.Views;
                this.ViewBag.Lang.Select = App_Lang.Lang.Select;
                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_id_controller
                this.ViewBag.donnee.HTML_Select_id_controller =
                    $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                foreach (var val in Program.db.groupe_menus)
                {
                    this.ViewBag.donnee.HTML_Select_id_controller += 
                        $"<option value=\"{val.id}\" title=\"{((id_lang == 0) ? val.libelle_en : val.libelle_fr)}\">{((id_lang == 0) ? val.libelle_en : val.libelle_fr)}</option>";
                }
                #endregion
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
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