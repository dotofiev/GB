using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class AutorisationDAO : IDAO
    {
        public string id_page { get { return string.Empty; } }
        public string context_id { get; set; }
        public string id_utilisateur { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "autorisation"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public AutorisationDAO(string context_id, string id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public static void Verification(string id_menu, string id_role, GB_Enum_Action_Controller action)
        {
            try
            {
                // -- Réccupérer l'autorisation -- //
                Autorisation autorisation = Program.db.autorisations.FirstOrDefault(l => l.id_menu == id_menu && l.id_role == id_role);

                // -- Verifier la nature de l'autorisation -- //
                if (!((action == GB_Enum_Action_Controller.Ajouter) ? autorisation?.ajouter ?? false
                                                                    : (action == GB_Enum_Action_Controller.Modifier) ? autorisation?.modifier ?? false
                                                                                                                     : (action == GB_Enum_Action_Controller.Supprimer) ? autorisation?.supprimer ?? false
                                                                                                                                                                       : (action == GB_Enum_Action_Controller.Imprimer) ? autorisation?.imprimer ?? false
                                                                                                                                                                                                                        : (action == GB_Enum_Action_Controller.Lister) ? autorisation?.lister ?? false
                                                                                                                                                                                                                                                                       : false))
                {
                    // -- Jeter l'exception -- //
                    throw new GBException(App_Lang.Lang.Permission_denied);
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

        public static void Verification_Autorisation(string id_menu, string id_role, GB_Enum_Action_Controller action, ref Boolean autorisation_refuse)
        {
            try
            {
                // -- Réccupérer l'autorisation -- //
                Autorisation autorisation = Program.db.autorisations.FirstOrDefault(l => l.id_menu == id_menu && l.id_role == id_role);

                // -- Verifier la nature de l'autorisation -- //
                if (!((action == GB_Enum_Action_Controller.Ajouter) ? autorisation?.ajouter ?? false
                        : (action == GB_Enum_Action_Controller.Modifier) ? autorisation?.modifier ?? false
                            : (action == GB_Enum_Action_Controller.Supprimer) ? autorisation?.supprimer ?? false
                                : (action == GB_Enum_Action_Controller.Imprimer) ? autorisation?.imprimer ?? false
                                    : (action == GB_Enum_Action_Controller.Lister) ? autorisation?.lister ?? false
                                        : false))
                {
                    // -- Mise à jour de l'etat de la variable -- //
                    autorisation_refuse = true;

                    // -- Jeter l'exception -- //
                    throw new GBException(App_Lang.Lang.Permission_denied);
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

        public void Ajouter(Autorisation obj)
        {
            try
            {
                //// -- Unicité du code -- //
                //if (Program.db.autorisations.Exists(l => l.code == obj.code))
                //{
                //    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                //}

                //// -- Définition de l'identifiant -- //
                //obj.Crer_Id();

                //// -- Enregistrement de la valeur -- //
                //Program.db.autorisations.Add(obj);

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

        public void Modifier(List<Autorisation> obj, string id_role)
        {
            try
            {
                // -- Vérifier si des modification sont à effectuer -- //
                if (obj.Count == 0)
                {
                    throw new GBException(App_Lang.Lang.No_changes_have_been_made);
                }

                // -- Suppression des anciennes valeurs -- //
                Program.db.autorisations.RemoveAll(l => l.id_role == id_role);

                // -- Mise à jour des identifiant et objets -- //
                long id = 1;
                obj.ForEach(autorisation =>
                {
                    autorisation.id = (id++).ToString();
                });

                // -- Modification de la valeur -- //
                Program.db.autorisations.AddRange(obj);

                // -- Execution des Hubs -- //
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

        public void Supprimer(List<string> ids)
        {
            try
            {
                //// -- Parcours de la liste des id -- //
                //ids.ForEach(id =>
                //{
                //    // -- Suppression des valeurs -- //
                //    Program.db.autorisations.RemoveAll(l => l.id == id);
                //});

                // -- Execution des Hubs -- //
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

        public static List<Autorisation> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.autorisations;
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

        public static List<Autorisation> Lister(string id_role)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.autorisations.Where(l => l.id_role == id_role).ToList();
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

        public static Autorisation ObjectCode(string code)
        {
            try
            {
                //// -- Parcours de la liste -- //
                //return
                //    Program.db.autorisations.FirstOrDefault(l => l.code == code);
                return null;
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

        public static string Crer_Id()
        {
            try
            {
                // -- Créer un identifian pour une nouvelle liste -- //
                return Program.db.autorisations.Max(ll => ll.id) + 1;
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