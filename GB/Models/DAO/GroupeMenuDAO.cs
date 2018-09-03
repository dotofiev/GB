using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class GroupeMenuDAO : IDAO<GroupeMenu>
    {
        public string id_page { get { return string.Empty; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_groupeMenu"; } }
        public string form_combo_code { get { return "form_code_groupeMenu"; } }
        public string form_name { get { return "groupe_menu"; } }
        public string form_combo_libelle { get { return "form_libelle_groupeMenu"; } }


        public GroupeMenuDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public GroupeMenuDAO() { }

        public void Ajouter(GroupeMenu obj, string id_utilisateur = null)
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
                //applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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
                //applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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
                //// -- Parcours de la liste des id -- //
                //ids.ForEach(id =>
                //{
                //    // -- Suppression des valeurs -- //
                //    Program.db.groupe_menu.RemoveAll(l => l.id == id);
                //});

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerCombo(new ExerciceFiscalDAO());

                //// -- Execution des Hubs -- //
                //applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public List<GroupeMenu> Lister()
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

        public GroupeMenu ObjectCode(string code)
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

        public GroupeMenu Object(string id)
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
                    foreach (var val in new GroupeMenuDAO().Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    }
                }
                // -- Ajout en fonction du champ libelle -- //
                else if (champ == "libelle")
                {
                    // -- Ajout des options -- //
                    foreach (var val in new GroupeMenuDAO().Lister())
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

        public GroupeMenu ObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}