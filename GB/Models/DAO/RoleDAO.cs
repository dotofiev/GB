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
    public class RoleDAO : IDAO
    {
        public string id_page { get { return GB_Enum_Menu.Securite_Role; } }
        public string context_id { get; set; }
        public string id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_role"; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "role"; } }
        public string form_combo_libelle { get { return "form_libelle_role"; } }


        public RoleDAO(string context_id, string id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public RoleDAO() { }

        public void Ajouter(Role obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.roles.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Enregistrement de la valeur -- //
                Program.db.roles.Add(obj);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerCombo(new RoleDAO());

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public void Modifier(Role obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.roles.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.roles
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.code = obj.code;
                        l.libelle_en = obj.libelle_en;
                        l.libelle_fr = obj.libelle_fr;
                    });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerCombo(new RoleDAO());

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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
                    Program.db.roles.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerCombo(new RoleDAO());

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public static List<Role> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.roles;
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

        public static Role ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.roles.FirstOrDefault(l => l.code == code);
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

        public static Role Object(string id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.roles.FirstOrDefault(l => l.id == id);
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
                    donnee.html_libelle += $"<option value=\"{val.id}\" title=\"{((Helper.LangHelper.CurrentCulture == 0) ? val.libelle_en : val.libelle_fr)}\">{((Helper.LangHelper.CurrentCulture == 0) ? val.libelle_en : val.libelle_fr)}</option>";
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