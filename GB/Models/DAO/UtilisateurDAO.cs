using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class UtilisateurDAO : IDAO
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

        public void Ajouter(Utilisateur obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.utilisateurs.Exists(l => l.compte == obj.compte))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [compte]");
                }

                // -- Mise àj our des references -- //
                obj.agence = AgenceDAO.ObjectId(obj.id_agence);
                obj.profession = ProfessionDAO.ObjectId(obj.id_profession);
                obj.autorite_signature = AutoriteSignatureDAO.ObjectId(obj.id_autorite_signature);
                obj.date_mise_a_jour_mot_de_passe = DateTime.Now.AddMonths(obj.duree_mot_de_passe).Ticks;

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Enregistrement de la valeur -- //
                Program.db.utilisateurs.Add(obj);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);

                // -- Execution des Hubs -- //
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
                        l.agence = AgenceDAO.ObjectId(obj.id_agence);
                        l.id_profession = obj.id_profession;
                        l.profession = ProfessionDAO.ObjectId(obj.id_profession);
                        l.id_autorite_signature = obj.id_autorite_signature;
                        l.autorite_signature = AutoriteSignatureDAO.ObjectId(obj.id_autorite_signature);
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

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);

                // -- Execution des Hubs -- //
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
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.utilisateurs.RemoveAll(l => l.id_utilisateur == id);
                });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);

                // -- Execution des Hubs -- //
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

        public static List<Utilisateur> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.utilisateurs;
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
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.Exists(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
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
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.FirstOrDefault(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
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
        public static Utilisateur ObjectCode(string compte)
        {
            try
            {
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.FirstOrDefault(l => l.compte == compte);
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
        public static Utilisateur ObjectId(string id_utilisateur)
        {
            try
            {
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.FirstOrDefault(l => l.id_utilisateur == id_utilisateur);
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

        public static Utilisateur Authentification(string compte, string mot_de_passe)
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
                if (utilisateur.date_mise_a_jour_mot_de_passe <= DateTime.Now.Ticks)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_3);
                }

                // -- Vérifier si l'utilisateur est déjà connecté et si dans ce cas la connexion multiple est activée -- //
                if (applicationMainHub.Hubs_Connexion.Exists(l => l.id_utilisateur == utilisateur.id_utilisateur) && !AppSettings.CONNEXION_UTILISATEUR_MULTI_POSTE)
                {
                    // -- Exception -- //
                    throw new GBException(App_Lang.Lang.Authentication_failed_5);
                }

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
    }
}