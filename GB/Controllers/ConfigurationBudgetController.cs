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
    public class ConfigurationBudgetController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult ParametreBudgetRevenu()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Budget_profit_center_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu);

            return View();
        }

        [HttpGet]
        public ActionResult ParametreBudgetFrais()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Configuring_Budget_lines_for_cost_centers})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais);

            return View();
        }

        [HttpGet]
        public ActionResult ExerciceFiscal()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Fiscals_exercice_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal);

            return View();
        }

        [HttpGet]
        public ActionResult DirectionBudget()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Budget_directionate_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBudget_DirectionBudget);

            return View();
        }

        [HttpGet]
        public ActionResult AutoriteSignature()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Signing_authority_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBudget_AutoriteSignature);

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
                #region ConfigurationBudget-ExerciceFiscal
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
                {
                    foreach (var val in ExerciceFiscalDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "exerciceFiscal"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(Convert.ToInt64(val.date_debut)).ToString(AppSettings.FORMAT_DATE),
                                col_5 = new DateTime(Convert.ToInt64(val.date_fin)).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.statut,
                                col_7 = val.budget_id,
                                col_8 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBudget-DirectionBudget
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
                {
                    foreach (var val in DirectionBudgetDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "directionBudget"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.chef,
                                col_5 = val.telephone,
                                col_6 = val.remarque,
                                col_7 = val.exercice_fiscal?.code ?? App_Lang.Lang.Empty,
                                col_8 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBudget-AutoriteSignature
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
                {
                    foreach (var val in AutoriteSignatureDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "autoriteSignature"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = GBToString.MontantToString(val.montant_signature),
                                col_5 = GBToString.MontantToString(val.limite_decouvert_client),
                                col_6 = GBToString.MontantToString(val.debit_max_client),
                                col_7 = GBToString.MontantToString(val.credit_max_client),
                                col_8 = GBToString.MontantToString(val.montant_max_ligne_credit),
                                col_9 = GBToString.MontantToString(val.montant_limite_pret),
                                col_10 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetRevenu
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    foreach (var val in ParametreBudgetRevenuDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "parametreBudgetRevenu"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.compte?.code ?? App_Lang.Lang.Empty,
                                col_5 = GBToString.Oui_Non(val.autoriser_control_budget),
                                col_6 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    foreach (var val in ParametreBudgetFraisDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "parametreBudgetFrais"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.compte?.code ?? App_Lang.Lang.Empty,
                                col_5 = GBToString.Oui_Non(val.autoriser_control_budget),
                                col_6 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ExerciceFiscal introuvable
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
                #region ConfigurationBudget-ParametreBudgetRevenu
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Si la vue n'est pas retourné -- //
                    #region comptes
                    if (string.IsNullOrEmpty(id_vue))
                    {
                        // -- Si la liste des comptes en session est vide, la mettre à jour -- //
                        if ((this.con.donnee.comptes as List<Compte>).Count == 0)
                        {
                            this.con.donnee.comptes = CompteDAO.Lister_Cle();
                        }

                        // -- Charger la liste des résultats -- //
                        foreach (var val in (this.con.donnee.comptes as List<Compte>))
                        {
                            donnee.Add(
                                new
                                {
                                    id = val.id,
                                    code = val.code,
                                    libelle = val.libelle
                                }
                            );
                        }
                    }
                    #endregion
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Si la vue n'est pas retourné -- //
                    #region comptes
                    if (string.IsNullOrEmpty(id_vue))
                    {
                        // -- Si la liste des comptes en session est vide, la mettre à jour -- //
                        if ((this.con.donnee.comptes as List<Compte>).Count == 0)
                        {
                            this.con.donnee.comptes = CompteDAO.Lister_Cle();
                        }

                        // -- Charger la liste des résultats -- //
                        foreach (var val in (this.con.donnee.comptes as List<Compte>))
                        {
                            donnee.Add(
                                new
                                {
                                    id = val.id,
                                    code = val.code,
                                    libelle = val.libelle
                                }
                            );
                        }
                    }
                    #endregion
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

        // -- Recharger les données dans le auto complete -- //
        public override object Recharger_EasyAutocomplete(string id_page, string id_vue)
        {
            List<object> donnee = new List<object>();

            try
            {
                #region ConfigurationBudget-ParametreBudgetRevenu
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Si la vue est pour le compte -- //
                    #region comptes
                    if (id_vue == "compte")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.comptes = CompteDAO.Lister_Cle();
                    }
                    #endregion
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Si la vue est pour le compte -- //
                    #region comptes
                    if (id_vue == "compte")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.comptes = CompteDAO.Lister_Cle();
                    }
                    #endregion
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
                #region ConfigurationBudget-ExerciceFiscal
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ExerciceFiscalDAO.ObjectCode(code);

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
                                                        date_debut = new DateTime(
                                                                        Convert.ToInt64(obj.date_debut)
                                                                     )
                                                                     .ToString(AppSettings.FORMAT_DATE),
                                                        date_fin = new DateTime(
                                                                        Convert.ToInt64(obj.date_fin)
                                                                    )
                                                                    .ToString(AppSettings.FORMAT_DATE),
                                                        budget_id = obj.budget_id,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBudget-DirectionBudget
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = DirectionBudgetDAO.ObjectCode(code);

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
                                                        chef = obj.chef,
                                                        libelle = obj.libelle,
                                                        telephone = obj.telephone,
                                                        id_exercice_fiscal = obj.id_exercice_fiscal,
                                                        remarque = obj.remarque,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBudget-AutoriteSignature
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = AutoriteSignatureDAO.ObjectCode(code);

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
                                                        credit_max_client = obj.credit_max_client,
                                                        debit_max_client = obj.debit_max_client,
                                                        limite_decouvert_client = obj.limite_decouvert_client,
                                                        montant_limite_pret = obj.montant_limite_pret,
                                                        montant_max_ligne_credit = obj.montant_max_ligne_credit,
                                                        montant_signature = obj.montant_signature,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetRevenu
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ParametreBudgetRevenuDAO.ObjectCode(code);

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
                                                        autoriser_control_budget = obj.autoriser_control_budget.ToString(),
                                                        id_compte = obj.id_compte,
                                                        code_compte = obj.compte?.code ?? null,
                                                        libelle_compte = obj.compte?.libelle ?? null,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ParametreBudgetFraisDAO.ObjectCode(code);

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
                                                        autoriser_control_budget = obj.autoriser_control_budget.ToString(),
                                                        id_compte = obj.id_compte,
                                                        code_compte = obj.compte?.code ?? null,
                                                        libelle_compte = obj.compte?.libelle ?? null,
                                                    }
                                               );
                }
                #endregion

                #region ExerciceFiscal introuvable
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
                #region ConfigurationBudget-ExerciceFiscal
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
                {
                    // -- Service d'enregistrement -- //
                    exerciceFiscalDAO.Ajouter(GBConvert.JSON_To<ExerciceFiscal>(obj));
                }
                #endregion

                #region ConfigurationBudget-DirectionBudget
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
                {
                    // -- Service d'enregistrement -- //
                    directionBudgetDAO.Ajouter(GBConvert.JSON_To<DirectionBudget>(obj));
                }
                #endregion

                #region ConfigurationBudget-AutoriteSignature
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
                {
                    // -- Service d'enregistrement -- //
                    autoriteSignatureDAO.Ajouter(GBConvert.JSON_To<AutoriteSignature>(obj));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetRevenu
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Service d'enregistrement -- //
                    parametreBudgetRevenuDAO.Ajouter(GBConvert.JSON_To<ParametreBudgetRevenu>(obj));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Service d'enregistrement -- //
                    parametreBudgetFraisDAO.Ajouter(GBConvert.JSON_To<ParametreBudgetFrais>(obj));
                }
                #endregion

                #region ExerciceFiscal introuvable
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
                #region ConfigurationBudget-ExerciceFiscal
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
                {
                    // -- Service de modification -- //
                    exerciceFiscalDAO.Modifier(GBConvert.JSON_To<ExerciceFiscal>(obj));
                }
                #endregion

                #region ConfigurationBudget-DirectionBudget
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
                {
                    // -- Service de modification -- //
                    directionBudgetDAO.Modifier(GBConvert.JSON_To<DirectionBudget>(obj));
                }
                #endregion

                #region ConfigurationBudget-AutoriteSignature
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
                {
                    // -- Service de modification -- //
                    autoriteSignatureDAO.Modifier(GBConvert.JSON_To<AutoriteSignature>(obj));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetRevenu
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Service de modification -- //
                    parametreBudgetRevenuDAO.Modifier(GBConvert.JSON_To<ParametreBudgetRevenu>(obj));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Service de modification -- //
                    parametreBudgetFraisDAO.Modifier(GBConvert.JSON_To<ParametreBudgetFrais>(obj));
                }
                #endregion

                #region ExerciceFiscal introuvable
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
                #region ConfigurationBudget-ExerciceFiscal
                if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
                {
                    // -- Service de suppression -- //
                    exerciceFiscalDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationBudget-DirectionBudget
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
                {
                    // -- Service de suppression -- //
                    directionBudgetDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationBudget-AutoriteSignature
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
                {
                    // -- Service de suppression -- //
                    autoriteSignatureDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetRevenu
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
                {
                    // -- Service de suppression -- //
                    parametreBudgetRevenuDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationBudget-ParametreBudgetFrais
                else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
                {
                    // -- Service de suppression -- //
                    parametreBudgetFraisDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ExerciceFiscal introuvable
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

            #region ConfigurationBudget-ExerciceFiscal
            if (id_page == GB_Enum_Menu.ConfigurationBudget_ExerciceFiscal)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page  = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Fiscals_exercice_management;
                this.ViewBag.Lang.Starting_date = App_Lang.Lang.Starting_date;
                this.ViewBag.Lang.Ending_date = App_Lang.Lang.Ending_date;
                this.ViewBag.Lang.Status = App_Lang.Lang.Status;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.FORMAT_DATE = AppSettings.FORMAT_DATE;
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Fiscals_exercice_management
                                                    },
                                                    format_date = AppSettings.FORMAT_DATE
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBudget-DirectionBudget
            else if (id_page == GB_Enum_Menu.ConfigurationBudget_DirectionBudget)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Budget_directionate_management;
                this.ViewBag.Lang.Directionate_head = App_Lang.Lang.Directionate_head;
                this.ViewBag.Lang.Phone = App_Lang.Lang.Phone;
                this.ViewBag.Lang.Remark = App_Lang.Lang.Remark;
                this.ViewBag.Lang.Fiscals_exercice = App_Lang.Lang.Fiscals_exercice;
                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_exercice_fiscal
                dynamic donnee = exerciceFiscalDAO.HTML_Select();
                this.ViewBag.donnee.HTML_Select_code_exercice_fiscal = donnee.html_code;
                this.ViewBag.donnee.HTML_Select_libelle_exercice_fiscal = donnee.html_libelle;
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
                                                        message = App_Lang.Lang.Budget_directionate_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBudget-AutoriteSignature
            else if (id_page == GB_Enum_Menu.ConfigurationBudget_AutoriteSignature)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Signing_authority_management;
                this.ViewBag.Lang.Signing_amount = App_Lang.Lang.Signing_amount;
                this.ViewBag.Lang.Customer_overdraft_limit = App_Lang.Lang.Customer_overdraft_limit;
                this.ViewBag.Lang.Customer_max_debit = App_Lang.Lang.Customer_max_debit;
                this.ViewBag.Lang.Customer_max_credit = App_Lang.Lang.Customer_max_credit;
                this.ViewBag.Lang.Line_of_credit_max_amount = App_Lang.Lang.Line_of_credit_max_amount;
                this.ViewBag.Lang.Loan_limit_amount = App_Lang.Lang.Loan_limit_amount;
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
                                                        message = App_Lang.Lang.Signing_authority_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBudget-ParametreBudgetRevenu
            else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Budget_profit_center_management;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Control_budget = App_Lang.Lang.Control_budget;
                this.ViewBag.Lang.Cost_center = App_Lang.Lang.Cost_center;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Search_by = App_Lang.Lang.Search_by;                
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
                                                        message = App_Lang.Lang.Budget_profit_center_management
                                                    }
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- Compte -- //
                this.con.donnee.comptes = new List<Compte>();
                #endregion
            }
            #endregion

            #region ConfigurationBudget-ParametreBudgetFrais
            else if (id_page == GB_Enum_Menu.ConfigurationBudget_ParametreBudgetFrais)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Configuring_Budget_lines_for_cost_centers;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Control_budget = App_Lang.Lang.Control_budget;
                this.ViewBag.Lang.Cost_center = App_Lang.Lang.Cost_center;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Search_by = App_Lang.Lang.Search_by;
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
                                                        message = App_Lang.Lang.Configuring_Budget_lines_for_cost_centers
                                                    }
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- Compte -- //
                this.con.donnee.comptes = new List<Compte>();
                #endregion
            }
            #endregion

        }
        #endregion
    }
}