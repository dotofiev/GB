using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class GroupeMenuDAO : GBDAO
    {
        public string id_page { get { return string.Empty; } }
        public string context_id { get; set; }
        public long id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_groupeMenu"; } }
        public string form_combo_code { get { return "form_code_groupeMenu"; } }
        public string form_name { get { return "groupe_menu"; } }
        public string form_combo_libelle { get { return "form_libelle_groupeMenu"; } }


        public GroupeMenuDAO(string context_id, long id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public void Ajouter(GroupeMenu obj)
        {
            try
            {
                //// -- Unicité du code -- //
                //if (Program.db.groupe_menu.Exists(l => l.code == obj.code))
                //{
                //    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                //}

                //// -- Définition de l'identifiant -- //
                //obj.Crer_Id();

                //// -- Enregistrement de la valeur -- //
                //Program.db.groupe_menu.Add(obj);

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerCombo(new ExerciceFiscalDAO());

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public void Modifier(GroupeMenu obj)
        {
            try
            {
                //// -- Unicité du code -- //
                //if (Program.db.groupe_menu.Exists(l => l.id != obj.id && l.code == obj.code))
                //{
                //    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                //}

                //// -- Modification de la valeur -- //
                //Program.db.groupe_menu
                //    // -- Spécifier la recherche -- //
                //    .Where(l => l.id == obj.id)
                //    // -- Lister le résultat -- //
                //    .ToList()
                //    // -- Parcourir les elements résultats -- //
                //    .ForEach(l =>
                //    {
                //        // -- Mise à jour de l'enregistrement -- //
                //        l.code = obj.code;
                //        l.libelle_en = obj.libelle_en;
                //        l.libelle_fr = obj.libelle_fr;
                //    });

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerCombo(new ExerciceFiscalDAO());

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerTable(this.id_page, this.context_id);
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
                //// -- Parcours de la liste des id -- //
                //ids.ForEach(id =>
                //{
                //    // -- Suppression des valeurs -- //
                //    Program.db.groupe_menu.RemoveAll(l => l.id == id);
                //});

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerCombo(new ExerciceFiscalDAO());

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerTable(this.id_page, this.context_id);
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

        public static List<GroupeMenu> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.groupe_menus;
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

        public static GroupeMenu Object(string code)
        {
            try
            {
                //// -- Parcours de la liste -- //
                return
                    Program.db.groupe_menus.FirstOrDefault(l => l.code == code);
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

        public static GroupeMenu Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.groupe_menus.FirstOrDefault(l => l.id == id);
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

                // -- Ajout en fonction du champ code -- //
                if (champ == "code")
                {
                    // -- Ajout des options -- //
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    }
                }
                // -- Ajout en fonction du champ libelle -- //
                else if (champ == "libelle")
                {
                    // -- Ajout des options -- //
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{((LangHelper.CurrentCulture == 0) ? val.libelle_en : val.libelle_fr)}\">{((LangHelper.CurrentCulture == 0) ? val.libelle_en : val.libelle_fr)}</option>";
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