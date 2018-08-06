﻿using GB.Models;
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

        [HttpGet]
        public ActionResult Devise()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Devise_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Devise);

            return View();
        }

        [HttpGet]
        public ActionResult Parametre()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.General_banking_parameters})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Parametre);

            return View();
        }

        [HttpGet]
        public ActionResult ParametreBanque()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Management_of_banking_parameters})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_ParametreBanque);

            return View();
        }

        [HttpGet]
        public ActionResult ProduitClientPhysique()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Physical_products_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique);

            return View();
        }

        [HttpGet]
        public ActionResult ProduitClientJudiciaire()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Judicial_products_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire);

            return View();
        }

        [HttpGet]
        public ActionResult Pays()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Pays_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Pays);

            return View();
        }

        [HttpGet]
        public ActionResult Ville()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Town_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Ville);

            return View();
        }

        [HttpGet]
        public ActionResult ActiviteEconomique()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Economic_activities_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique);

            return View();
        }

        [HttpGet]
        public ActionResult Titre()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Title_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_Titre);

            return View();
        }

        [HttpGet]
        public ActionResult UniteInstitutionnelle()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Institutional_unit_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle);

            return View();
        }

        [HttpGet]
        public ActionResult BEACNationalite()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.BEAC_nationality_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_BEACNationalite);

            return View();
        }

        [HttpGet]
        public ActionResult CongeBanque()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Bank_holiday_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationBanque_CongeBanque);

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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "institution"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.type,
                                col_5 = val.cobac_id,
                                col_6 = val.pub,
                                col_7 = val.motto,
                                col_8 = val.logo?.libelle ?? App_Lang.Lang.Empty,
                                col_9 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "agence"),
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
                                col_15 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-Devise
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
                {
                    foreach (var val in DeviseDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "devise"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.signe,
                                col_5 = GBToString.Oui_Non(val.devise_actuelle),
                                col_6 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-ParametreBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
                {
                    foreach (var val in ParametreBanqueDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "parametreBanque"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.taux,
                                col_5 = val.montant,
                                col_6 = val.montant_minimal,
                                col_7 = val.montant_maximal,
                                col_8 = val.devise.libelle,
                                col_9 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-ProduitClientPhysique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
                {
                    foreach (var val in ProduitPhysiqueDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "produitPhysique"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.type,
                                col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-ProduitClientJudiciaire
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
                {
                    foreach (var val in ProduitJudiciaireDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "produitJudiciaire"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-Pays
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
                {
                    foreach (var val in PaysDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "pays"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.code_telephone,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-Ville
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
                {
                    foreach (var val in VilleDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "ville"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_6 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-ActiviteEconomique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
                {
                    foreach (var val in ActiviteEconomiqueDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "activiteEconomique"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-Titre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
                {
                    foreach (var val in TitreDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "titre"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-UniteInstitutionnelle
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
                {
                    foreach (var val in UniteInstitutionnelleDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "uniteInstitutionnelle"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-BEACNationalite
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
                {
                    foreach (var val in BEACNationaliteDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "beacNationalite"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_6 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationBanque-CongeBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
                {
                    foreach (var val in CongeBanqueDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "congeBanque"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_6 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                    // -- Si la vue n'est pas retourné -- //
                    #region utilisateurs
                    if (string.IsNullOrEmpty(id_vue))
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

                    #region pays
                    // -- Si la vue est pour le pays -- //
                    else if (id_vue == "pays")
                    {
                        // -- Si la liste des pays en session est vide, la mettre à jour -- //
                        if ((this.con.donnee.pays as List<Pays>).Count == 0)
                        {
                            this.con.donnee.pays = PaysDAO.Lister();
                        }

                        // -- Charger la liste des résultats -- //
                        foreach (var val in (this.con.donnee.pays as List<Pays>))
                        {
                            donnee.Add(
                                new
                                {
                                    libelle = val.libelle,
                                }
                            );
                        }
                    }
                    #endregion

                    #region ville
                    // -- Si la vue est pour le pays -- //
                    else if (id_vue == "ville")
                    {
                        // -- Si la liste des villes en session est vide, la mettre à jour -- //
                        if ((this.con.donnee.villes as List<Ville>).Count == 0)
                        {
                            this.con.donnee.villes = VilleDAO.Lister();
                        }

                        // -- Charger la liste des résultats -- //
                        foreach (var val in (this.con.donnee.villes as List<Ville>))
                        {
                            donnee.Add(
                                new
                                {
                                    libelle = val.libelle,
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
                #region ConfigurationBanque-Agence
                if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Si la vue est pour le utilisateur -- //
                    #region utilisateurs
                    if (id_vue == "utilisateur")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.utilisateurs = UtilisateurDAO.Lister();
                    }
                    #endregion

                    #region pays
                    // -- Si la vue est pour le pays -- //
                    else if (id_vue == "pays")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.pays = PaysDAO.Lister();
                    }
                    #endregion

                    #region ville
                    // -- Si la vue est pour le pays -- //
                    else if (id_vue == "ville")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.villes = VilleDAO.Lister();
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
                                                        image = ((obj?.logo?.fichier?.Count() ?? 0) != 0) ? GBConvert.To_Base64Image(obj.logo.fichier, ".jpg") 
                                                                                                          : null,
                                                        image_statut = (obj.logo?.fichier?.Count() ?? 0) != 0 ? 2 
                                                                                                              : 0, 
                                                        image_libelle = obj?.logo?.libelle ?? App_Lang.Lang.Empty + " ...",
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

                #region ConfigurationBanque-Devise
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = DeviseDAO.Object(code);

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
                                                        signe = obj.signe,
                                                        devise_actuelle = obj.devise_actuelle.ToString(),
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBanque-ParametreBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ParametreBanqueDAO.Object(code);

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
                                                        taux = obj.taux,
                                                        montant = obj.montant,
                                                        montant_maximal = obj.montant_maximal,
                                                        montant_minimal = obj.montant_minimal,
                                                        id_devise = obj.id_devise,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBanque-ProduitClientPhysique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ProduitPhysiqueDAO.Object(code);

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

                #region ConfigurationBanque-ProduitClientJudiciaire
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ProduitJudiciaireDAO.Object(code);

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

                #region ConfigurationBanque-Pays
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = PaysDAO.Object(code);

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
                                                        code_telephone = obj.code_telephone,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationBanque-Ville
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = VilleDAO.Object(code);

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

                #region ConfigurationBanque-ActiviteEconomique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = ActiviteEconomiqueDAO.Object(code);

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

                #region ConfigurationBanque-Titre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TitreDAO.Object(code);

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

                #region ConfigurationBanque-UniteInstitutionnelle
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = UniteInstitutionnelleDAO.Object(code);

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

                #region ConfigurationBanque-BEACNationalite
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = BEACNationaliteDAO.Object(code);

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

                #region ConfigurationBanque-CongeBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = CongeBanqueDAO.Object(code);

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
                                                        jour = obj.jour,
                                                        mois = obj.mois,
                                                        libelle = obj.libelle,
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
                    institutionDAO.Ajouter(obj_type);
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service d'enregistrement -- //
                    agenceDAO.Ajouter(GBConvert.JSON_To<Agence>(obj));
                }
                #endregion

                #region ConfigurationBanque-Devise
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
                {
                    // -- Service d'enregistrement -- //
                    deviseDAO.Ajouter(GBConvert.JSON_To<Devise>(obj));
                }
                #endregion

                #region ConfigurationBanque-ParametreBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
                {
                    // -- Service d'enregistrement -- //
                    parametreBancaireDAO.Ajouter(GBConvert.JSON_To<ParametreBanque>(obj));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientPhysique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
                {
                    // -- Service d'enregistrement -- //
                    produitPhysiqueDAO.Ajouter(GBConvert.JSON_To<ProduitPhysique>(obj));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientJudiciaire
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
                {
                    // -- Service d'enregistrement -- //
                    produitJudiciaireDAO.Ajouter(GBConvert.JSON_To<ProduitJudiciaire>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-Pays
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
                {
                    // -- Service d'enregistrement -- //
                    paysDAO.Ajouter(GBConvert.JSON_To<Pays>(obj));
                }
                #endregion

                #region ConfigurationBanque-Ville
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
                {
                    // -- Service d'enregistrement -- //
                    villeDAO.Ajouter(GBConvert.JSON_To<Ville>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-ActiviteEconomique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
                {
                    // -- Service d'enregistrement -- //
                    activiteEconomiqueDAO.Ajouter(GBConvert.JSON_To<ActiviteEconomique>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-Titre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
                {
                    // -- Service d'enregistrement -- //
                    titreDAO.Ajouter(GBConvert.JSON_To<Titre>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-UniteInstitutionnelle
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
                {
                    // -- Service d'enregistrement -- //
                    uniteInstitutionnelleDAO.Ajouter(GBConvert.JSON_To<UniteInstitutionnelle>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-BEACNationalite
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
                {
                    // -- Service d'enregistrement -- //
                    bEACNationaliteDAO.Ajouter(GBConvert.JSON_To<BEACNationalite>(obj), this.con.id_utilisateur);
                }
                #endregion

                #region ConfigurationBanque-CongeBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
                {
                    // -- Service d'enregistrement -- //
                    congeBanqueDAO.Ajouter(GBConvert.JSON_To<CongeBanque>(obj));
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
                    institutionDAO.Modifier(obj_type);
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service de modification -- //
                    agenceDAO.Modifier(GBConvert.JSON_To<Agence>(obj));
                }
                #endregion

                #region ConfigurationBanque-Devise
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
                {
                    // -- Service de modification -- //
                    deviseDAO.Modifier(GBConvert.JSON_To<Devise>(obj));
                }
                #endregion

                #region ConfigurationBanque-Parametre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Parametre)
                {
                    // -- Service de modification -- //
                    parametreDAO.Modifier(GBConvert.JSON_To<Parametre>(obj));
                }
                #endregion

                #region ConfigurationBanque-ParametreBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
                {
                    // -- Service de modification -- //
                    parametreBancaireDAO.Modifier(GBConvert.JSON_To<ParametreBanque>(obj));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientPhysique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
                {
                    // -- Service de modification -- //
                    produitPhysiqueDAO.Modifier(GBConvert.JSON_To<ProduitPhysique>(obj));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientJudiciaire
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
                {
                    // -- Service de modification -- //
                    produitJudiciaireDAO.Modifier(GBConvert.JSON_To<ProduitJudiciaire>(obj));
                }
                #endregion

                #region ConfigurationBanque-Pays
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
                {
                    // -- Service de modification -- //
                    paysDAO.Modifier(GBConvert.JSON_To<Pays>(obj));
                }
                #endregion

                #region ConfigurationBanque-Ville
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
                {
                    // -- Service de modification -- //
                    villeDAO.Modifier(GBConvert.JSON_To<Ville>(obj));
                }
                #endregion

                #region ConfigurationBanque-ActiviteEconomique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
                {
                    // -- Service de modification -- //
                    activiteEconomiqueDAO.Modifier(GBConvert.JSON_To<ActiviteEconomique>(obj));
                }
                #endregion

                #region ConfigurationBanque-Titre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
                {
                    // -- Service de modification -- //
                    titreDAO.Modifier(GBConvert.JSON_To<Titre>(obj));
                }
                #endregion

                #region ConfigurationBanque-UniteInstitutionnelle
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
                {
                    // -- Service de modification -- //
                    uniteInstitutionnelleDAO.Modifier(GBConvert.JSON_To<UniteInstitutionnelle>(obj));
                }
                #endregion

                #region ConfigurationBanque-BEACNationalite
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
                {
                    // -- Service de modification -- //
                    bEACNationaliteDAO.Modifier(GBConvert.JSON_To<BEACNationalite>(obj));
                }
                #endregion

                #region ConfigurationBanque-CongeBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
                {
                    // -- Service de modification -- //
                    congeBanqueDAO.Modifier(GBConvert.JSON_To<CongeBanque>(obj));
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
                    institutionDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Agence
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Agence)
                {
                    // -- Service de suppression -- //
                    agenceDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Devise
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
                {
                    // -- Service de suppression -- //
                    deviseDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-ParametreBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
                {
                    // -- Service de suppression -- //
                    parametreBancaireDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientPhysique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
                {
                    // -- Service de suppression -- //
                    produitPhysiqueDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-ProduitClientJudiciaire
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
                {
                    // -- Service de suppression -- //
                    produitJudiciaireDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Pays
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
                {
                    // -- Service de suppression -- //
                    paysDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Ville
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
                {
                    // -- Service de suppression -- //
                    villeDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-ActiviteEconomique
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
                {
                    // -- Service de suppression -- //
                    activiteEconomiqueDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-Titre
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
                {
                    // -- Service de suppression -- //
                    titreDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-UniteInstitutionnelle
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
                {
                    // -- Service de suppression -- //
                    uniteInstitutionnelleDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-BEACNationalite
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
                {
                    // -- Service de suppression -- //
                    bEACNationaliteDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
                }
                #endregion

                #region ConfigurationBanque-CongeBanque
                else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
                {
                    // -- Service de suppression -- //
                    congeBanqueDAO.Supprimer(GBConvert.JSON_To<List<long>>(ids));
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
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Institution_management
                                                    }
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
                this.ViewBag.Lang.Country = App_Lang.Lang.Country;
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- Utilisateur -- //
                this.con.donnee.utilisateurs = new List<Utilisateur>();
                // -- Pays -- //
                this.con.donnee.pays = new List<Pays>();
                // -- Ville -- //
                this.con.donnee.villes = new List<Ville>();
                #endregion
            }
            #endregion

            #region ConfigurationBanque-Devise
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Devise)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Devise_management;
                this.ViewBag.Lang.Sign = App_Lang.Lang.Sign;
                this.ViewBag.Lang.Current_currency = App_Lang.Lang.Current_currency;
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
                                                        message = App_Lang.Lang.Devise_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-Parametre
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Parametre)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.General_banking_parameters;
                this.ViewBag.Lang.General_parameters = App_Lang.Lang.General_parameters;
                this.ViewBag.Lang.Statement_page_count = App_Lang.Lang.Statement_page_count;
                this.ViewBag.Lang.Use_check_booklet = App_Lang.Lang.Use_check_booklet;
                this.ViewBag.Lang.Number_day_before_write_off = App_Lang.Lang.Number_day_before_write_off;
                this.ViewBag.Lang.Dormant_period = App_Lang.Lang.Dormant_period;
                this.ViewBag.Lang.Litigation_period = App_Lang.Lang.Litigation_period;
                this.ViewBag.Lang.Use_central_version = App_Lang.Lang.Use_central_version;
                this.ViewBag.Lang.No_payment_period = App_Lang.Lang.No_payment_period;
                this.ViewBag.Lang.Control_number_of_loans = App_Lang.Lang.Control_number_of_loans;
                this.ViewBag.Lang.Count_account = App_Lang.Lang.Count_account;
                this.ViewBag.Lang.VAT = App_Lang.Lang.VAT;
                this.ViewBag.Lang.Control_session = App_Lang.Lang.Control_session;
                this.ViewBag.Lang.Session_duration = App_Lang.Lang.Session_duration;
                this.ViewBag.Lang.SMS_banking = App_Lang.Lang.SMS_banking;
                this.ViewBag.Lang.Open_back_date = App_Lang.Lang.Open_back_date;
                this.ViewBag.Lang.Days = App_Lang.Lang.Days;
                this.ViewBag.Lang.Reserve_interest_post_method = App_Lang.Lang.Reserve_interest_post_method;
                this.ViewBag.Lang.Use_cobac_litigation_method = App_Lang.Lang.Use_cobac_litigation_method;
                this.ViewBag.Lang.Modify_custom_attributes_in_branch = App_Lang.Lang.Modify_custom_attributes_in_branch;
                this.ViewBag.Lang.Count_page_number_statement = App_Lang.Lang.Count_page_number_statement;
                this.ViewBag.Lang.Night_run_posting_options = App_Lang.Lang.Night_run_posting_options;
                this.ViewBag.Lang.Update_customer_position = App_Lang.Lang.Update_customer_position;
                this.ViewBag.Lang.Post_loan_litigation = App_Lang.Lang.Post_loan_litigation;
                this.ViewBag.Lang.Post_local_collection = App_Lang.Lang.Post_local_collection;
                this.ViewBag.Lang.Post_term_and_time_deposits = App_Lang.Lang.Post_term_and_time_deposits;
                this.ViewBag.Lang.Backup = App_Lang.Lang.Backup;
                this.ViewBag.Lang.Backup_method = App_Lang.Lang.Backup_method;
                this.ViewBag.Lang.Browse = App_Lang.Lang.Browse;
                this.ViewBag.Lang.Empty = App_Lang.Lang.Empty;
                this.ViewBag.Lang.Path_first_backup = App_Lang.Lang.Path_first_backup;
                this.ViewBag.Lang.Path_last_backup = App_Lang.Lang.Path_last_backup;
                
                #endregion

                // -- Données -- //
                #region Données
                // -- Rendu html dans les combo box -- //
                this.ViewBag.donnee.HTML_methode_de_sauvegarde = GBClass.HTML_Methode_de_sauvegarde();
                this.ViewBag.donnee.HTML_methode_de_post_interet_reserver = GBClass.HTML_methode_de_post_interet_reserver();
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.General_banking_parameters
                                                    },
                                                    parametre = ParametreDAO.Object()
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-ParametreBanque
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_ParametreBanque)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Management_of_banking_parameters;
                this.ViewBag.Lang.Rate = App_Lang.Lang.Rate;
                this.ViewBag.Lang.Amount = App_Lang.Lang.Amount;
                this.ViewBag.Lang.Amount_min = App_Lang.Lang.Amount_min;
                this.ViewBag.Lang.Amount_max = App_Lang.Lang.Amount_max;
                this.ViewBag.Lang.Currency = App_Lang.Lang.Currency;
                #endregion

                // -- Données -- //
                #region Données
                #region HTML_Select_devise
                dynamic donnee = deviseDAO.HTML_Select();
                this.ViewBag.donnee.HTML_Select_code_devise = donnee.html_code;
                this.ViewBag.donnee.HTML_Select_libelle_devise = donnee.html_libelle;
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
                                                        message = App_Lang.Lang.Management_of_banking_parameters
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-ProduitClientPhysique
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientPhysique)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Physical_products_management;
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
                                                        message = App_Lang.Lang.Physical_products_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-ProduitClientJudiciaire
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_ProduitClientJudiciaire)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Judicial_products_management;
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
                                                        message = App_Lang.Lang.Judicial_products_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-Pays
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Pays)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Pays_management;
                this.ViewBag.Lang.Phone_id = App_Lang.Lang.Phone_id;
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
                                                        message = App_Lang.Lang.Pays_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-Ville
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Ville)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Town_management;
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
                                                        message = App_Lang.Lang.Town_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-ActiviteEconomique
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Economic_activities_management;
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
                                                        message = App_Lang.Lang.Economic_activities_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-Titre
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_Titre)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Title_management;
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
                                                        message = App_Lang.Lang.Title_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-UniteInstitutionnelle
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_UniteInstitutionnelle)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Institutional_unit_management;
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
                                                        message = App_Lang.Lang.Institutional_unit_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-BEACNationalite
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_BEACNationalite)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.BEAC_nationality_management;
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
                                                        message = App_Lang.Lang.BEAC_nationality_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationBanque-CongeBanque
            else if (id_page == GB_Enum_Menu.ConfigurationBanque_CongeBanque)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Bank_holiday_management;
                this.ViewBag.Lang.Day = App_Lang.Lang.Day;
                this.ViewBag.Lang.Month = App_Lang.Lang.Month;
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
                                                        message = App_Lang.Lang.Bank_holiday_management
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