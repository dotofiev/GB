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
    public class CompteDAO : IDAO<Compte>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationOperation_Compte; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_compte"; } }
        public string form_combo_code { get { return "form_code_compte"; } }
        public string form_name { get { return "compte"; } }
        public string form_combo_libelle { get { return "form_libelle_compte"; } }


        public CompteDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public CompteDAO() { }

        public void Ajouter(List<Compte> objs)
        {
            try
            {
                // -- Obj utilisateur créateur -- //
                Utilisateur utilisateur_createur = new UtilisateurDAO().ObjectId(this.connexion.utilisateur.id_utilisateur);

                // -- Mise à jour de l'objet devise -- //
                Devise devise = DeviseDAO.Actif();

                // -- Obj date de creation -- //
                long date_creation = DateTime.Now.Ticks;

                // -- Mise à joru des données -- //
                foreach(var obj in objs)
                {
                    obj.type_operation_compte_client_et_compte_gl = false;
                    obj.type_operation_compte_gl_et_compte_gl = false;
                    obj.date_creation = date_creation;
                    obj.id_utilisateur = this.connexion.utilisateur.id_utilisateur;
                    obj.utilisateur_createur = utilisateur_createur;
                    obj.id_devise = devise?.id;
                    obj.devise = devise ?? null;
                }

                // -- Enregistrement de la valeur -- //
                Program.db.comptes.AddRange(objs);

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
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

        public void Modifier(Compte obj, Boolean operation)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.comptes.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.comptes
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Si il s'agit de modifier uniquement les operations -- //
                        if (operation)
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.type_operation_compte_client_et_compte_gl = obj.type_operation_compte_client_et_compte_gl;
                            l.type_operation_compte_gl_et_compte_gl = obj.type_operation_compte_gl_et_compte_gl;
                        }
                        else
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj.code;
                            l.libelle = obj.libelle;
                            // -- Vider les paramètre du compte de taille 10 -- //
                            if (obj.code.Length == 10)
                            {
                                l.statut = obj.statut;
                                l.nature = obj.nature;
                                l.cle = obj.cle;
                            }
                            else
                            {
                                l.statut = string.Empty;
                                l.nature = string.Empty;
                                l.cle = string.Empty;
                            }
                            l.id_devise = obj.id_devise;
                            l.devise = new DeviseDAO().ObjectId(obj.id_devise);
                        }
                    });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
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
                    Program.db.comptes.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.connexion.hub_id_context);
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

        public List<Compte> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes;
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

        public static List<Compte> Lister_Cle()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    new CompteDAO().Lister()
                        .Where(l => l.code.Length == 10)
                        .ToList();
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

        public Compte ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes.FirstOrDefault(l => l.code == code);
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

        public Compte ObjectId(string id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.comptes.FirstOrDefault(l => l.id == id);
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

        public void Ajouter(Compte obj, string id_utilisateur = null)
        {
            throw new NotImplementedException();
        }

        public void Modifier(Compte obj)
        {
            throw new NotImplementedException();
        }
    }
}