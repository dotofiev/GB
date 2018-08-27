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
    public class ActiviteEconomiqueDAO : IDAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique; } }
        public string context_id { get; set; }
        public string id_utilisateur { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "activite_economique"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public ActiviteEconomiqueDAO(string context_id, string id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public void Ajouter(ActiviteEconomique obj, string id_utilisateur)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.activites_economique.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour de la date de creation -- //
                obj.date_creation = DateTime.Now.Ticks;

                // -- Mise à jour des refenreces -- //
                obj.id_utilisateur = id_utilisateur;
                obj.utilisateur_createur = UtilisateurDAO.ObjectId(id_utilisateur);

                // -- Enregistrement de la valeur -- //
                Program.db.activites_economique.Add(obj);

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

        public void Modifier(ActiviteEconomique obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.activites_economique.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.activites_economique
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
                    Program.db.activites_economique.RemoveAll(l => l.id == id);
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

        public static List<ActiviteEconomique> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.activites_economique;
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

        public static ActiviteEconomique ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.activites_economique.FirstOrDefault(l => l.code == code);
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