using GB.Models.BO;
using GB.Models.GB;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class ParametreBudgetRevenuDAO : DAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBudget_ParametreBudgetRevenu; } }
        public string context_id { get; set; }
        public long id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_parametreBudgetRevenu"; } }
        public string form_combo_code { get { return "form_code_parametreBudgetRevenu"; } }
        public string form_name { get { return "parametreBudgetRevenu"; } }
        public string form_combo_libelle { get { return "form_libelle_parametreBudgetRevenu"; } }


        public ParametreBudgetRevenuDAO(string context_id, long id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public ParametreBudgetRevenuDAO() { }

        public void Ajouter(ParametreBudgetRevenu obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.parametres_budget_revenus.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [Code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour des references -- //
                obj.compte = CompteDAO.Object(obj.id_compte);

                // -- Enregistrement de la valeur -- //
                Program.db.parametres_budget_revenus.Add(obj);

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new ParametreBudgetRevenuDAO());
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

        public void Modifier(ParametreBudgetRevenu obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.parametres_budget_revenus.Exists(l => l.code == obj.code && l.id != obj.id))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [Code]");
                }

                // -- Modification de la valeur -- //
                Program.db.parametres_budget_revenus
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.id_compte = obj.id_compte;
                        l.compte = CompteDAO.Object(obj.id_compte);
                        l.autoriser_control_budget = obj.autoriser_control_budget;
                        l.code = obj.code;
                        l.libelle = obj.libelle;
                    });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new ParametreBudgetRevenuDAO());
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

        public void Supprimer(List<long> ids)
        {
            try
            {
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.parametres_budget_revenus.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new ParametreBudgetRevenuDAO());
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

        public static List<ParametreBudgetRevenu> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres_budget_revenus;
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

        public static ParametreBudgetRevenu Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres_budget_revenus.FirstOrDefault(l => l.code == code);
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

        public static ParametreBudgetRevenu Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres_budget_revenus.FirstOrDefault(l => l.id == id);
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