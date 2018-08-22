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
    public class CompteBanqueDAO : IDAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_CompteBanque; } }
        public string context_id { get; set; }
        public string id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_compteBanque"; } }
        public string form_combo_code { get { return "form_code_compteBanque"; } }
        public string form_name { get { return "compteBanque"; } }
        public string form_combo_libelle { get { return "form_libelle_compteBanque"; } }


        public CompteBanqueDAO(string context_id, string id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public CompteBanqueDAO() { }

        public void Ajouter(CompteBanque obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.comptes_banque.Exists(l => l.id_banque == obj.id_banque && l.id_compte == obj.id_compte))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Account} {App_Lang.Lang.Bank}]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour du créateur -- //
                obj.id_utilisateur_createur = this.id_utilisateur;

                // -- Mise à jour des references -- //
                obj.utilisateur_createur = UtilisateurDAO.ObjectId(this.id_utilisateur);
                obj.compte = CompteDAO.ObjectId(obj.id_compte);
                obj.banque = BanqueDAO.ObjectId(obj.id_banque);

                // -- Enregistrement de la valeur -- //
                Program.db.comptes_banque.Add(obj);

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteBanqueDAO());
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public void Modifier(CompteBanque obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.comptes_banque.Exists(l => l.id_banque == obj.id_banque && l.id_compte == obj.id_compte && l.id != obj.id))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Account} {App_Lang.Lang.Bank}]");
                }

                // -- Modification de la valeur -- //
                Program.db.comptes_banque
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.id_compte = obj.id_compte;
                        l.id_banque = obj.id_banque;
                        l.compte = CompteDAO.ObjectId(obj.id_compte);
                        l.banque = BanqueDAO.ObjectId(obj.id_banque);
                    });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteBanqueDAO());
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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
                    Program.db.comptes_banque.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new CompteBanqueDAO());
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public static List<CompteBanque> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_banque;
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

        public static CompteBanque ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_banque.FirstOrDefault(l => l.code == code);
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

        public static CompteBanque ObjectId(string id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes_banque.FirstOrDefault(l => l.id == id);
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