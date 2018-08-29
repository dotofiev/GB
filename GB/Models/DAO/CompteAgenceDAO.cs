using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class CompteAgenceDAO : IDAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_CompteAgence; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_compteAgence"; } }
        public string form_combo_code { get { return "form_code_compteAgence"; } }
        public string form_name { get { return "compteAgence"; } }
        public string form_combo_libelle { get { return "form_libelle_compteAgence"; } }


        public CompteAgenceDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public CompteAgenceDAO() { }

        public void Ajouter(CompteAgence obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.comptes_agence.Exists(l => l.id_agence == obj.id_agence && l.type == obj.type))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Operation_type}]");
                }

                // -- valider la nécessité du champ compte_emetteur -- //
                if (obj.type != "COMPENSATION" && (string.IsNullOrEmpty(obj.id_compte_emetteur) || Convert.ToInt64(obj.id_compte_emetteur) == 0))
                {
                    throw new GBException(App_Lang.Lang.Required_field + $" [{App_Lang.Lang.Issue}]");
                }

                // -- Mise à jour des valeurs -- //
                if (obj.type == "COMPENSATION")
                {
                    obj.id_compte_emetteur = "0";
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour du créateur -- //
                obj.id_utilisateur_createur = this.connexion.utilisateur.id_utilisateur;

                // -- Mise à jour des references -- //
                obj.utilisateur_createur = UtilisateurDAO.ObjectId(this.connexion.utilisateur.id_utilisateur);
                obj.compte = CompteDAO.ObjectId(obj.id_compte);
                obj.compte_emetteur = CompteDAO.ObjectId(obj.id_compte_emetteur);
                obj.agence = AgenceDAO.ObjectId(obj.id_agence);

                // -- Enregistrement de la valeur -- //
                Program.db.comptes_agence.Add(obj);

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteAgenceDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public void Modifier(CompteAgence obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.comptes_agence.Exists(l => l.id_agence == obj.id_agence && l.type == obj.type && l.id != obj.id))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Operation_type}]");
                }

                // -- valider la nécessité du champ compte_emetteur -- //
                if (obj.type != "COMPENSATION" && (string.IsNullOrEmpty(obj.id_compte_emetteur) || Convert.ToInt64(obj.id_compte_emetteur) == 0))
                {
                    throw new GBException(App_Lang.Lang.Required_field + $" [{App_Lang.Lang.Issue}]");
                }

                // -- Mise à jour des valeurs -- //
                if (obj.type == "COMPENSATION")
                {
                    obj.id_compte_emetteur = "0";
                }

                // -- Modification de la valeur -- //
                Program.db.comptes_agence
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.id_compte = obj.id_compte;
                        l.id_compte_emetteur = obj.id_compte_emetteur;
                        l.type = obj.type;
                        l.compte = CompteDAO.ObjectId(obj.id_compte);
                        l.agence = AgenceDAO.ObjectId(obj.id_agence);
                        l.compte_emetteur = CompteDAO.ObjectId(obj.id_compte_emetteur);
                    });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteAgenceDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public void Supprimer(List<string> ids)
        {
            try
            {
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.comptes_agence.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteAgenceDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public static List<CompteAgence> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_agence;
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

        public static CompteAgence ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_agence.FirstOrDefault(l => l.code == code);
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

        public static CompteAgence ObjectId(string id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_agence.FirstOrDefault(l => l.id == id);
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

        public static string HTML_Select(string champ)
        {
            try
            {
                // -- Valeur vide -- //
                string HTML = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                // -- Ajout des options -- //
                // -- Pour le champ code -- //
                if (champ == "code")
                {
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    }
                }
                else if (champ == "libelle")
                {
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                    }
                }

                return HTML;
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
            try
            {
                // -- Objet dynamic -- //
                dynamic donnee = new System.Dynamic.ExpandoObject();

                // -- Valeur vide -- //
                donnee.html_code = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                donnee.html_libelle = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                // -- Ajout des options -- //

                foreach (var val in Lister())
                {
                    donnee.html_code += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    donnee.html_libelle += $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                }

                // -- Retourner l'objet -- //
                return donnee;
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
    }
}