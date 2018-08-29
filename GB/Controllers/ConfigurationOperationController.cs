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
    public class ConfigurationOperationController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult CompteConfiguration()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Exempt_general_leger_account})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_CompteConfiguration);

            return View();
        }

        [HttpGet]
        public ActionResult Compte()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Account_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_Compte);

            return View();
        }

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

        [HttpGet]
        public ActionResult LocalisationActif()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Asset_location_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_LocalisationActif);

            return View();
        }

        [HttpGet]
        public ActionResult WesternUnionZonePays()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"GBK - ({App_Lang.Lang.Western_Union_country_zone_management})";

            // -- Charger les paramètres de langue de la page -- //
            Charger_Langue_Et_Donnees(GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays);

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
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    foreach (var val in TypePretDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "typePret"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = GBToString.PeriodiciteDePret(val.periodicite),
                                col_5 = val.periode_debut,
                                col_6 = val.periode_fin,
                                col_7 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "motifPret"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "classificationProvisionsPret"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.nombre_jour_debut,
                                col_5 = val.nombre_jour_fin,
                                col_6 = $"{val.pourcentage} %",
                                col_7 = GBToString.FormuleClassificationProvisionsPret(val.formule),
                                col_8 = GBToString.TypeClassificationProvisionsPret(val.type),
                                col_9 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "typeGarantie"),
                                col_2 = val.code,
                                col_3 = val.libelle_fr,
                                col_4 = val.libelle_en,
                                col_5 = GBToString.NatureTypeGarantie(val.nature),
                                col_6 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_7 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_8 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "journal"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
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
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "typeActif"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-LocalisationActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
                {
                    foreach (var val in LocalisationActifDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "localisationActif"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_5 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-WesternUnionZonePays
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    foreach (var val in WesternUnionZonePaysDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                col_0 = val.id,
                                col_1 = GBClass.HTML_Checkbox_Table(val.id, "westernUnionZonePays"),
                                col_2 = val.pays.libelle,
                                col_3 = val.zone,
                                col_4 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                            }
                        );
                    }
                }
                #endregion

                #region ConfigurationOperation-Compte
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    // -- Si la vue n'est pas soumise -- //
                    if (string.IsNullOrEmpty(id_vue))
                    {
                        foreach (var val in CompteDAO.Lister())
                        {
                            donnee.Add(
                                new
                                {
                                    col_1 = GBClass.HTML_Checkbox_Table(val.id, "compte"),
                                    col_2 = val.code,
                                    col_3 = val.libelle,
                                    col_4 = val.cle,
                                    col_5 = GBToString.NatureCompte(val.nature),
                                    col_6 = GBToString.StatutCompte(val.statut),
                                    col_7 = val.devise?.libelle ?? string.Empty,
                                    col_8 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                    col_9 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                    col_10 = GBClass.HTML_Bouton_Modifier_Suppression_Table(val.id, val.code)
                                }
                            );
                        }
                    }
                    // -- Si c'est la vue nouveau_compte -- //
                    else if (id_vue == "nouveau_compte")
                    {
                        foreach (var val in (this.con.donnee.nouveau_compte as List<Compte>))
                        {
                            donnee.Add(
                                new
                                {
                                    col_0 = val.id,
                                    col_2 = val.code,
                                    col_3 = val.libelle,
                                    col_4 = val.cle,
                                    col_5 = val.nature,
                                    col_6 = val.statut,
                                    col_7 = GBClass.HTML_Bouton_Suppression_Table(val.id, $"table_nouveau_compte_donnee_supprimer({val.id})")
                                }
                            );
                        }
                    }
                }
                #endregion

                #region ConfigurationOperation-CompteConfiguration
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_CompteConfiguration)
                {
                    foreach (var val in CompteDAO.Lister())
                    {
                        donnee.Add(
                            new
                            {
                                //col_1 = GBClass.HTML_Checkbox_Table(val.id, "compteConfiguration"),
                                col_2 = val.code,
                                col_3 = val.libelle,
                                col_4 = val.cle,
                                col_5 = GBToString.Activer_Desactiver(val.type_operation_compte_client_et_compte_gl),
                                col_6 = GBToString.Activer_Desactiver(val.type_operation_compte_gl_et_compte_gl),
                                col_7 = GBToString.NatureCompte(val.nature),
                                col_8 = GBToString.StatutCompte(val.statut),
                                col_9 = val.devise?.libelle ?? string.Empty,
                                col_10 = new DateTime(val.date_creation).ToString(AppSettings.FORMAT_DATE),
                                col_11 = val.utilisateur_createur?.nom_utilisateur ?? App_Lang.Lang.Empty,
                                col_12 = GBClass.HTML_Bouton_Modifier_Table(val.id, val.code)
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
        public ActionResult Selection_Enregistrement(string code, string id, string id_page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region ConfigurationOperation-TypePret
                if (id_page == GB_Enum_Menu.ConfigurationOperation_TypePret)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = TypePretDAO.ObjectCode(code);

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
                    var obj = MotifPretDAO.ObjectCode(code);

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
                    var obj = ClassificationProvisionsPretDAO.ObjectCode(code);

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
                    var obj = TypeGarantieDAO.ObjectCode(code);

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
                    var obj = JournalDAO.ObjectCode(code);

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
                    var obj = TypeActifDAO.ObjectCode(code);

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

                #region ConfigurationOperation-LocalisationActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = LocalisationActifDAO.ObjectCode(code);

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

                #region ConfigurationOperation-WesternUnionZonePays
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = WesternUnionZonePaysDAO.ObjectId(id);

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
                                                        id_pays = obj.pays.id,
                                                        code_pays = obj.pays.code,
                                                        libelle_pays = obj.pays.libelle,
                                                        zone = obj.zone,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-Compte
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = CompteDAO.ObjectCode(code);

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
                                                        cle = obj.cle,
                                                        nature = obj.nature,
                                                        statut = obj.statut,
                                                        id_devise = obj.id_devise,
                                                    }
                                               );
                }
                #endregion

                #region ConfigurationOperation-CompteConfiguration
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_CompteConfiguration)
                {
                    // -- Mise à jour de l'role dans la session -- //
                    var obj = CompteDAO.ObjectCode(code);

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
                                                        type_operation_compte_client_et_compte_gl = obj.type_operation_compte_client_et_compte_gl.ToString(),
                                                        type_operation_compte_gl_et_compte_gl = obj.type_operation_compte_gl_et_compte_gl.ToString(),
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
                    typePretDAO.Ajouter(GBConvert.JSON_To<TypePret>(obj));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service d'enregistrement -- //
                    motifPretDAO.Ajouter(GBConvert.JSON_To<MotifPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service d'enregistrement -- //
                    classificationProvisionsPretDAO.Ajouter(GBConvert.JSON_To<ClassificationProvisionsPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service d'enregistrement -- //
                    typeGarantieDAO.Ajouter(GBConvert.JSON_To<TypeGarantie>(obj), this.con.utilisateur.id_utilisateur);
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service d'enregistrement -- //
                    journalDAO.Ajouter(GBConvert.JSON_To<Journal>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service d'enregistrement -- //
                    typeActifDAO.Ajouter(GBConvert.JSON_To<TypeActif>(obj));
                }
                #endregion

                #region ConfigurationOperation-LocalisationActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
                {
                    // -- Service d'enregistrement -- //
                    localisationActifDAO.Ajouter(GBConvert.JSON_To<LocalisationActif>(obj));
                }
                #endregion

                #region ConfigurationOperation-WesternUnionZonePays
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Service d'enregistrement -- //
                    westernUnionZonePaysDAO.Ajouter(GBConvert.JSON_To<WesternUnionZonePays>(obj));
                }
                #endregion

                #region ConfigurationOperation-Compte
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    // -- Liste des comptes à créer -- //
                    #region Variables
                    this.con.donnee.nouveau_compte = new List<Compte>();

                    // -- Object BO envoyé -- //
                    Compte objet = GBConvert.JSON_To<Compte>(obj);

                    // -- Définition des cas multiple -- //
                    Boolean multi_cas = objet.numero_compte.Length > 3;

                    // -- Initialiser l'id -- //
                    long id = Program.db.comptes.Max(l => Convert.ToInt64(l.id)) + 1;
                    #endregion

                    // -- Traitement des cas -- //
                    #region Traitement
                    // -- 2, 3 -- //
                    for (int i = 2; i <= 3; i++)
                    {
                        if ((multi_cas || objet.numero_compte.Length == i) && CompteDAO.ObjectCode(objet.numero_compte.Substring(0, i)) == null)
                        {
                            (this.con.donnee.nouveau_compte as List<Compte>).Add(
                                new Compte
                                {
                                    code = objet.numero_compte.Substring(0, i),
                                    libelle = string.Empty,
                                    id = (id++).ToString(),
                                }
                            );
                        }
                    }
                    // -- 4, 5 et 6 -- //
                    for (int i = 4; i <= 6; i++)
                    {
                        if (objet.numero_compte.Length >= i)
                        {
                            if (multi_cas && CompteDAO.ObjectCode(objet.numero_compte.Substring(0, i)) == null)
                            {
                                (this.con.donnee.nouveau_compte as List<Compte>).Add(
                                    new Compte
                                    {
                                        code = objet.numero_compte.Substring(0, i),
                                        libelle = string.Empty,
                                        id = (id++).ToString(),
                                    }
                                );
                            }
                        }
                    }
                    // -- 10 -- //
                    if (multi_cas && objet.numero_compte.Length == 10 && CompteDAO.ObjectCode(objet.numero_compte) == null)
                    {
                        (this.con.donnee.nouveau_compte as List<Compte>).Add(
                            new Compte
                            {
                                code = objet.numero_compte,
                                libelle = string.Empty,
                                id = (id++).ToString(),
                                cle = GBClass.Alea_Cle_Compte()
                            }
                        );
                    }
                    #endregion

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(this.con.donnee.nouveau_compte);
                }
                #endregion

                #region TypePret introuvable
                else
                {
                    throw new Exception("Le id_page n'a pas été retourné!");
                }
                #endregion

                // -- Notificication -- //
                // -- Ne pas envoyer pour les comptes -- //
                if (id_page != GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    this.ViewBag.notification = new GBNotification(false);
                }
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
                    typePretDAO.Modifier(GBConvert.JSON_To<TypePret>(obj));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service de modification -- //
                    motifPretDAO.Modifier(GBConvert.JSON_To<MotifPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service de modification -- //
                    classificationProvisionsPretDAO.Modifier(GBConvert.JSON_To<ClassificationProvisionsPret>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service de modification -- //
                    typeGarantieDAO.Modifier(GBConvert.JSON_To<TypeGarantie>(obj));
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service de modification -- //
                    journalDAO.Modifier(GBConvert.JSON_To<Journal>(obj));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service de modification -- //
                    typeActifDAO.Modifier(GBConvert.JSON_To<TypeActif>(obj));
                }
                #endregion

                #region ConfigurationOperation-LocalisationActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
                {
                    // -- Service de modification -- //
                    localisationActifDAO.Modifier(GBConvert.JSON_To<LocalisationActif>(obj));
                }
                #endregion

                #region ConfigurationOperation-WesternUnionZonePays
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Service de modification -- //
                    westernUnionZonePaysDAO.Modifier(GBConvert.JSON_To<WesternUnionZonePays>(obj));
                }
                #endregion

                #region ConfigurationOperation-Compte
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    // -- Service de modification -- //
                    compteDAO.Modifier(GBConvert.JSON_To<Compte>(obj), false);
                }
                #endregion

                #region ConfigurationOperation-CompteConfiguration
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_CompteConfiguration)
                {
                    // -- Service de modification -- //
                    compteDAO.Modifier(GBConvert.JSON_To<Compte>(obj), true);
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
        public ActionResult Compte_Enregistrer_Nouveau_Compte(string obj)
        {
            try
            {
                // -- Mise à jour des comptes en session -- //
                List<Compte> comptes = GBConvert.JSON_To<List<Compte>>(obj);

                // -- Vérifier qu'au moins un elemente est soumis au traitement -- //
                if (comptes.Count == 0)
                {
                    throw new GBException(App_Lang.Lang.No_items_have_been_previously_created);
                }

                // -- Supprimer les comptes annulé -- //
                (this.con.donnee.nouveau_compte as List<Compte>).RemoveAll(l => comptes.Count(ll => ll.id == l.id) == 0);

                // -- Mise à jours des comptes -- //
                foreach (var val in comptes)
                {
                    (this.con.donnee.nouveau_compte as List<Compte>)
                        .Where(l => l.id == val.id)
                        .ToList()
                        .ForEach(l =>
                        {
                            l.libelle = val.libelle;
                            l.nature = val.nature;
                            l.statut = val.statut;
                            l.cle = val.cle;
                        });
                }

                // -- Enregistrer les elements -- //
                compteDAO.Ajouter(this.con.donnee.nouveau_compte as List<Compte>);

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
                    typePretDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-MotifPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_MotifPret)
                {
                    // -- Service de suppression -- //
                    motifPretDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-ClassificationProvisionsPret
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_ClassificationProvisionsPret)
                {
                    // -- Service de suppression -- //
                    classificationProvisionsPretDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-TypeGarantie
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeGarantie)
                {
                    // -- Service de suppression -- //
                    typeGarantieDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-Journal
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Journal)
                {
                    // -- Service de suppression -- //
                    journalDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-TypeActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_TypeActif)
                {
                    // -- Service de suppression -- //
                    typeActifDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-LocalisationActif
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
                {
                    // -- Service de suppression -- //
                    localisationActifDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-WesternUnionZonePays
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Service de suppression -- //
                    westernUnionZonePaysDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
                }
                #endregion

                #region ConfigurationOperation-Compte
                else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
                {
                    // -- Service de suppression -- //
                    compteDAO.Supprimer(GBConvert.JSON_To<List<string>>(ids));
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

        // -- Charger les données dans le auto complete -- //
        public override object Charger_EasyAutocomplete(string id_page, string id_vue)
        {
            List<object> donnee = new List<object>();

            try
            {
                #region ConfigurationOperation-WesternUnionZonePays
                if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Si la vue n'est pas retourné -- //
                    #region pays
                    if (string.IsNullOrEmpty(id_vue))
                    {
                        // -- Si la liste des pays en session est vide, la mettre à jour -- //
                        if ((this.con.donnee.pays as List<PAYS>).Count == 0)
                        {
                            this.con.donnee.pays = PAYSDAO.Lister();
                        }

                        // -- Charger la liste des résultats -- //
                        foreach (var val in (this.con.donnee.pays as List<PAYS>))
                        {
                            donnee.Add(
                                new
                                {
                                    id = val.id,
                                    code = val.code,
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
                #region ConfigurationOperation-WesternUnionZonePays
                if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
                {
                    // -- Si la vue n'est pas retourné -- //
                    #region pays
                    if (id_vue == "pays")
                    {
                        // -- Mise à jour de la liste en session -- //
                        this.con.donnee.pays = PAYSDAO.Lister();
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
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
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
                                                    Urls = new GBControllerUrlJS(this, id_page),
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

            #region ConfigurationOperation-LocalisationActif
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_LocalisationActif)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Asset_location_management;
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
                                                        message = App_Lang.Lang.Asset_location_management
                                                    }
                                                }
                                            );
                #endregion
            }
            #endregion

            #region ConfigurationOperation-WesternUnionZonePays
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Western_Union_country_zone_management;
                this.ViewBag.Lang.Country = App_Lang.Lang.Country;
                this.ViewBag.Lang.Search_by = App_Lang.Lang.Search_by;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.HTML_Select_zone = GBClass.HTML_zone_western_union();
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Western_Union_country_zone_management
                                                    }
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- Pays -- //
                this.con.donnee.pays = new List<PAYS>();
                #endregion
            }
            #endregion

            #region ConfigurationOperation-Compte
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_Compte)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Account_management;
                this.ViewBag.Lang.Key = App_Lang.Lang.Key;
                this.ViewBag.Lang.Status = App_Lang.Lang.Status;
                this.ViewBag.Lang.Currency = App_Lang.Lang.Currency;
                this.ViewBag.Lang.Parameters = App_Lang.Lang.Parameters;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Account_number = App_Lang.Lang.Account_number;
                this.ViewBag.Lang.Generate = App_Lang.Lang.Generate;
                this.ViewBag.Lang.Length_string_min_2 = App_Lang.Lang.Length_string_min_2;
                #endregion

                // -- Données -- //
                #region Données
                this.ViewBag.donnee.HTML_Nature = GBClass.HTML_nature_compte();
                this.ViewBag.donnee.HTML_Statut = GBClass.HTML_statut_compte();
                dynamic donnee = deviseDAO.HTML_Select();
                this.ViewBag.donnee.HTML_Select_code_devise = donnee.html_code;
                this.ViewBag.donnee.HTML_Select_libelle_devise = donnee.html_libelle;
                this.ViewBag.GB_DONNEE = GBConvert.To_JSONString(
                                                new
                                                {
                                                    Urls = new GBControllerUrlJS(this, id_page),
                                                    id_page = id_page,
                                                    titre = this.ViewBag.Title,
                                                    description = new
                                                    {
                                                        icon = "fa fa-cogs",
                                                        message = App_Lang.Lang.Account_management
                                                    },
                                                    Lang = new
                                                    {
                                                        Not_required = App_Lang.Lang.Not_required,
                                                        Credit = App_Lang.Lang.Credit,
                                                        Debit = App_Lang.Lang.Debit,
                                                        Both = App_Lang.Lang.Both,
                                                        Close = App_Lang.Lang.Close,
                                                        Open = App_Lang.Lang.Open,
                                                        Required_field = App_Lang.Lang.Required_field,
                                                        Account = App_Lang.Lang.Account,
                                                        Name = App_Lang.Lang.Name.ToLower(),
                                                        Key = App_Lang.Lang.Key,
                                                        Status = App_Lang.Lang.Status,
                                                    }
                                                }
                                            );
                // -- Vider les données temporaire -- //
                this.con.Vider_Donnee();
                // - Mise à jour des données de vue -- //
                // -- autorisation_disponible -- //
                this.con.donnee.nouveau_compte = new List<Compte>();
                #endregion
            }
            #endregion

            #region ConfigurationOperation-CompteConfiguration
            else if (id_page == GB_Enum_Menu.ConfigurationOperation_CompteConfiguration)
            {
                // -- Langue -- //
                #region Langue
                this.ViewBag.Lang.Description_page = $"<i class=\"fa fa-cogs\"></i> " + App_Lang.Lang.Account_management;
                this.ViewBag.Lang.Key = App_Lang.Lang.Key;
                this.ViewBag.Lang.Status = App_Lang.Lang.Status;
                this.ViewBag.Lang.Currency = App_Lang.Lang.Currency;
                this.ViewBag.Lang.Parameters = App_Lang.Lang.Parameters;
                this.ViewBag.Lang.Account = App_Lang.Lang.Account;
                this.ViewBag.Lang.Account_number = App_Lang.Lang.Account_number;
                this.ViewBag.Lang.Generate = App_Lang.Lang.Generate;
                this.ViewBag.Lang.Length_string_min_2 = App_Lang.Lang.Length_string_min_2;
                this.ViewBag.Lang.Customer_account_to_GL_account = App_Lang.Lang.Customer_account_to_GL_account;
                this.ViewBag.Lang.GL_account_to_GL_account = App_Lang.Lang.GL_account_to_GL_account;
                this.ViewBag.Lang.Operation_type = App_Lang.Lang.Operation_type;
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
                                                        message = App_Lang.Lang.Exempt_general_leger_account
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