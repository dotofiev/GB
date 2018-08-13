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
    public class ResponsableRelationClientDAO : DAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_ResponsableRelationClient; } }
        public string context_id { get; set; }
        public long id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_responsableRelationClient"; } }
        public string form_combo_code { get { return "form_code_responsableRelationClient"; } }
        public string form_name { get { return "responsableRelationClient"; } }
        public string form_combo_libelle { get { return "form_libelle_responsableRelationClient"; } }


        public ResponsableRelationClientDAO(string context_id, long id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public void Ajouter(ResponsableRelationClient obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.responsables_relation_client.Exists(l => l.nom == obj.nom && l.prenom == obj.prenom))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Name},{App_Lang.Lang.Surname}]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Enregistrement de la valeur -- //
                Program.db.responsables_relation_client.Add(obj);

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

        public void Modifier(ResponsableRelationClient obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.responsables_relation_client.Exists(l => l.id != obj.id && l.nom == obj.nom && l.prenom == obj.prenom))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + $" [{App_Lang.Lang.Name},{App_Lang.Lang.Surname}]");
                }

                // -- Modification de la valeur -- //
                Program.db.responsables_relation_client
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.nom = obj.nom;
                        l.prenom = obj.prenom;
                        l.telephone = obj.telephone;
                        l.email = obj.email;
                        l.nid = obj.nid;
                        l.garant = obj.garant;
                        l.garant_telephone = obj.garant_telephone;
                        l.champ_1 = obj.champ_1;
                        l.champ_2 = obj.champ_2;
                    });

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

        public void Supprimer(List<long> ids)
        {
            try
            {
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.responsables_relation_client.RemoveAll(l => l.id == id);
                });

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

        public static List<ResponsableRelationClient> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.responsables_relation_client;
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

        public static ResponsableRelationClient Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.responsables_relation_client.FirstOrDefault(l => l.code == code);
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

        public static ResponsableRelationClient Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.responsables_relation_client.FirstOrDefault(l => l.id == id);
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