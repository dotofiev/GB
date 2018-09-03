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
    public class InstitutionDAO : IDAO<Institution>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_Institution; } }
        public GBConnexion connexion { get; set; }
        public Utilisateur utilisateur { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "institution"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public InstitutionDAO(GBConnexion con)
        {
            this.connexion = con;
            this.utilisateur = utilisateur;
        }

        public InstitutionDAO() { }

        public void Ajouter(Institution obj, string id_utilisateur = null)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.institutions.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Enregistrement de la valeur -- //
                Program.db.institutions.Add(obj);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public void Modifier(Institution obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.institutions.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.institutions
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.code = obj.code;
                        l.libelle = obj.libelle;
                        l.cobac_id = obj.cobac_id;
                        // -- Mise à jour de l'image -- //
                        l.logo = (obj.logo == null) ? null 
                                                    : (obj.logo.fichier.Count() == 0) ? l.logo 
                                                                                      : obj.logo;
                        l.motto = obj.motto;
                        l.pub = obj.pub;
                        l.type = obj.type;
                    });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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
                    Program.db.institutions.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public List<Institution> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.institutions;
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

        public Institution ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.institutions.FirstOrDefault(l => l.code == code);
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

        public Institution ObjectId(string id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.institutions.FirstOrDefault(l => l.id == id);
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