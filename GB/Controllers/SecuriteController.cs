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

        [HttpGet]
        public ActionResult Role()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Rule_Management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue("Securite-Role");

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
            Charger_Langue("Securite-Menu");

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
                    foreach (var val in TestClass.db_roles)
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
                    foreach (var val in TestClass.db_menus)
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = $"<input type=\"checkbox\" class=\"flat\" name=\"menu\" value=\"menu_{val.id}\">",
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
                    var obj = TestClass.db_modules.FirstOrDefault(l => l.code == code);

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
                    var obj = TestClass.db_roles.FirstOrDefault(l => l.code == code);

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
                    var obj = TestClass.db_menus.FirstOrDefault(l => l.code == code);

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
        public ActionResult Ajouter_Enregistrement(string id_page, string obj)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Securite-Module
                if (id_page == "Securite-Module")
                {
                    // -- Cast en objet type -- //
                    Module obj_type = GBConvert.JSON_To<Module>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_modules.Exists(l => l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Définition de l'identifiant -- //
                    obj_type.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    TestClass.db_modules.Add(obj_type);
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Cast en objet type -- //
                    Role obj_type = GBConvert.JSON_To<Role>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_roles.Exists(l => l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Définition de l'identifiant -- //
                    obj_type.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    TestClass.db_roles.Add(obj_type);
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Cast en objet type -- //
                    Menu obj_type = GBConvert.JSON_To<Menu>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_menus.Exists(l => l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Définition de l'identifiant -- //
                    obj_type.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    TestClass.db_menus.Add(obj_type);
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
                    // -- Cast en objet type -- //
                    Module obj_type = GBConvert.JSON_To<Module>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_modules.Exists(l => l.id != obj_type.id && l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Modification de la valeur -- //
                    TestClass.db_modules
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id == obj_type.id)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj_type.code;
                            l.libelle_en = obj_type.libelle_en;
                            l.libelle_fr = obj_type.libelle_fr;
                        });
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Cast en objet type -- //
                    Role obj_type = GBConvert.JSON_To<Role>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_roles.Exists(l => l.id != obj_type.id && l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Modification de la valeur -- //
                    TestClass.db_roles
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id == obj_type.id)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj_type.code;
                            l.libelle_en = obj_type.libelle_en;
                            l.libelle_fr = obj_type.libelle_fr;
                        });
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Cast en objet type -- //
                    Menu obj_type = GBConvert.JSON_To<Menu>(obj);

                    // -- Unicité du code -- //
                    if (TestClass.db_menus.Exists(l => l.id != obj_type.id && l.code == obj_type.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Modification de la valeur -- //
                    TestClass.db_menus
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id == obj_type.id)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj_type.code;
                            l.libelle_en = obj_type.libelle_en;
                            l.libelle_fr = obj_type.libelle_fr;
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
                    // -- Convertion des identifiants -- //
                    GBConvert.JSON_To<List<long>>(ids)
                        // -- Parcours de la liste des id -- //
                        .ForEach(id =>
                        {
                            // -- Suppression des valeurs -- //
                            TestClass.db_modules.RemoveAll(l => l.id == id);
                        });
                }
                #endregion

                #region Securite-Role
                else if (id_page == "Securite-Role")
                {
                    // -- Convertion des identifiants -- //
                    GBConvert.JSON_To<List<long>>(ids)
                        // -- Parcours de la liste des id -- //
                        .ForEach(id =>
                        {
                            // -- Suppression des valeurs -- //
                            TestClass.db_roles.RemoveAll(l => l.id == id);
                        });
                }
                #endregion

                #region Securite-Menu
                else if (id_page == "Securite-Menu")
                {
                    // -- Convertion des identifiants -- //
                    GBConvert.JSON_To<List<long>>(ids)
                        // -- Parcours de la liste des id -- //
                        .ForEach(id =>
                        {
                            // -- Suppression des valeurs -- //
                            TestClass.db_menus.RemoveAll(l => l.id == id);
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

        }
        #endregion
    }
}