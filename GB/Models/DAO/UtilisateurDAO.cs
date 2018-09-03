using GB.Models.BO;
using GB.Models.Entites;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class UtilisateurDAO : IDAO<Utilisateur>
    {
        public string id_page { get { return GB_Enum_Menu.SecuriteUtilisateur_Utilisateur; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_utilisateur"; } }
        public string form_combo_code { get { return "form_code_utilisateur"; } }
        public string form_name { get { return "utilisateur"; } }
        public string form_combo_libelle { get { return "form_libelle_utilisateur"; } }


        public UtilisateurDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public UtilisateurDAO() { }

        public void Ajouter(Utilisateur obj, string id_utilisateur = null)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.utilisateurs.Exists(l => l.compte == obj.compte))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [compte]");
                    }

                    // -- Mise àj our des references -- //
                    obj.agence = new AgenceDAO().ObjectId(obj.id_agence);
                    obj.profession = new ProfessionDAO().ObjectId(obj.id_profession);
                    obj.autorite_signature = new AutoriteSignatureDAO().ObjectId(obj.id_autorite_signature);
                    obj.date_mise_a_jour_mot_de_passe = DateTime.Now.AddMonths(obj.duree_mot_de_passe).Ticks;

                    // -- Définition de l'identifiant -- //
                    obj.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    Program.db.utilisateurs.Add(obj);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Définition des variables -- //
                        Dictionary<string, object> parametres = new Dictionary<string, object>();
                        parametres.Add("date_creation", this.connexion.date_serveur);

                        // -- Enregistrement de la données -- //
                        db.Employes.Add(obj.ToEntities(parametres));

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public void Modifier(Utilisateur obj)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.utilisateurs.Exists(l => l.id_utilisateur != obj.id_utilisateur && l.compte == obj.compte))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [compte]");
                    }

                    // -- Modification de la valeur -- //
                    Program.db.utilisateurs
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id_utilisateur == obj.id_utilisateur)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                        // -- Mise à jour de l'enregistrement -- //
                        l.compte = obj.compte;
                            l.nom_utilisateur = obj.nom_utilisateur;
                            l.id_agence = obj.id_agence;
                            l.agence = new AgenceDAO().ObjectId(obj.id_agence);
                            l.id_profession = obj.id_profession;
                            l.profession = new ProfessionDAO().ObjectId(obj.id_profession);
                            l.id_autorite_signature = obj.id_autorite_signature;
                            l.autorite_signature = new AutoriteSignatureDAO().ObjectId(obj.id_autorite_signature);
                            l.ouverture_back_date = obj.ouverture_back_date;
                            l.ouverture_back_date_travail = obj.ouverture_back_date_travail;
                            l.ouverture_branch = obj.ouverture_branch;
                            l.est_connecte = obj.est_connecte;
                            l.est_suspendu = obj.est_suspendu;
                            l.duree_mot_de_passe = obj.duree_mot_de_passe;
                            l.date_mise_a_jour_mot_de_passe = DateTime.Now.AddMonths(obj.duree_mot_de_passe).Ticks;
                        // -- Mise à jour du mot de passe -- //
                        if (obj.modifier_mot_de_passe)
                            {
                                l.mot_de_passe = obj.mot_de_passe;
                            }
                        });
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Rechercher l'objet à modifier -- //
                        Employe ancien_obj = db.Employes.Find(obj.code);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        obj.ModifyEntities(ancien_obj);

                        // -- Enregistrement de la données -- //
                        db.Entry<Employe>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public void Supprimer(List<string> ids)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste des id -- //
                    ids.ForEach(id =>
                    {
                        // -- Suppression des valeurs -- //
                        Program.db.utilisateurs.RemoveAll(l => l.id_utilisateur == id);
                    });
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Supprimer la liste -- //
                        db.Employes.RemoveRange(
                            // -- Réccupérer les éléments à supprimer -- //
                            db.Employes.Where(l => ids.Count(ll => ll.Equals(l.Matricule)) != 0)
                        );

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public List<Utilisateur> Lister()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                    Program.db.utilisateurs;
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            FromEntities(
                                db.Employes.ToList()
                            ).ToList();
                    }
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

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public static bool Existe(string compte, string mot_de_passe)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Vérifier l'existance -- //
                    return
                        Program.db.utilisateurs.Exists(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            db.Employes.Count(l => l.Matricule == compte && l.MotPasse == mot_de_passe) != 0;
                    }
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

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public static Utilisateur Object(string compte, string mot_de_passe)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Vérifier l'existance -- //
                    return
                        Program.db.utilisateurs.FirstOrDefault(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            new Utilisateur(
                                db.Employes.FirstOrDefault(l => l.Matricule == compte && l.MotPasse == mot_de_passe)
                            );
                    }
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

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }
        public static Utilisateur ObjectCode(string compte, bool ajouter_reference = true)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Vérifier l'existance -- //
                    return
                    Program.db.utilisateurs.FirstOrDefault(l => l.compte == compte);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            new Utilisateur(
                                db.Employes.FirstOrDefault(l => l.Matricule == compte),
                                ajouter_reference
                            );
                    }
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

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }
        public Utilisateur ObjectId(string id_utilisateur, bool ajouter_reference = true)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Vérifier l'existance -- //
                    return
                    Program.db.utilisateurs.FirstOrDefault(l => l.id_utilisateur == id_utilisateur);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            new Utilisateur(
                                db.Employes.FirstOrDefault(l => l.Matricule == id_utilisateur),
                                ajouter_reference
                            );
                    }
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

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public static Utilisateur Authentification(string compte, string mot_de_passe, string id_lang, string nom_ordinateur = "POKA-PC")
        {
            try
            {
                // -- Rechercher l'utilisateur -- /
                Utilisateur utilisateur = Object(compte, mot_de_passe);

                // -- Vérifier la conformité des données -- //
                if (utilisateur == null)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_1);
                }

                // -- Vérifier la suspension de l'utilisateur -- //
                if (utilisateur.est_suspendu)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_2);
                }

                // -- Vérifier la duré de vie du mot de passe -- //
                if (new TimeSpan(DateTime.Now.Ticks - utilisateur.date_mise_a_jour_mot_de_passe).Days > utilisateur.duree_mot_de_passe)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_3);
                }

                // -- Vérifier si l'utilisateur est déjà connecté et si dans ce cas la connexion multiple est activée -- //
                if (applicationMainHub.Hubs_Connexion.Exists(l => (l.utilisateur?.id_utilisateur ?? GBClass.id_par_defaut) == utilisateur.id_utilisateur) && !AppSettings.CONNEXION_UTILISATEUR_MULTI_POSTE)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_5);
                }

                // -- Mise à jour du nom de l'ordinateur -- //
                utilisateur.nom_ordinateur = nom_ordinateur;

                // -- Gestion de l'authentification en base -- //
                #region Gestion de l'authentification en base
                ObjectParameter pc_OutSERVERDATE = null; // +- (Agence
                ObjectParameter pc_OutSERVERBACKDATE = null; // +- (Agence
                ObjectParameter pc_OutSERVEROPEN = null; // +- (Agence
                ObjectParameter pc_OutBACKOPEN = null; // +- (Agence
                ObjectParameter pc_OutBACKDATEWK = null; // +- (Agence
                ObjectParameter pc_OutMSG = null; // -- Message d'erreur
                ObjectParameter pc_OutPWD = null; // -- 
                ObjectParameter pc_OutLECT = null; // -- Code erreur

                ObjectParameter nOM = null; // -- Nom utilisateur (emplo
                ObjectParameter sECURITYLEVEL = null; // -- Code securit (emplo
                ObjectParameter aGENCE = null; // -- Code agence
                ObjectParameter pRIVILEGE = null; // -- Code privie (emplo
                ObjectParameter mAXAMOUNT = null; // -- 
                ObjectParameter cODECAISSE = null; // -- code caisse 
                ObjectParameter eMPACCESS = null; // --

                // -- Définition du context -- //
                using (BankingEntities db = new BankingEntities())
                {
                    // -- Désactivation du Lasy loading -- //
                    db.Configuration.LazyLoadingEnabled = false;

                    // -- Execution de la procédure stocké qu'authentification -- //
                    db.PS_LOGIN_USER(
                        utilisateur.code, utilisateur.nom_ordinateur, (id_lang == "1") ? "fr" 
                                                                                       : "en", 
                        pc_OutSERVERDATE, pc_OutSERVERBACKDATE, pc_OutSERVEROPEN, pc_OutBACKOPEN,
                        pc_OutBACKDATEWK, pc_OutMSG, pc_OutPWD, aGENCE, nOM, sECURITYLEVEL, 
                        pRIVILEGE, mAXAMOUNT, cODECAISSE, eMPACCESS, pc_OutLECT
                    );
                }
                #endregion

                // -- Revoyé l'utilisateur pour l'authentification -- //
                return
                    utilisateur;
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public dynamic HTML_Select()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Utilisateur> FromEntities(List<Employe> listObj)
        {
            foreach (var obj in listObj)
            {
                if (obj == null)
                    continue;

                yield return new Utilisateur(obj);
            }
        }

        public Utilisateur ObjectCode(string code)
        {
            throw new NotImplementedException();
        }

        public Utilisateur ObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}