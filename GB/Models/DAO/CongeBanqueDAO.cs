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
    public class CongeBanqueDAO : IDAO<CongeBanque>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_CongeBanque; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "conge_banque"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public CongeBanqueDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public CongeBanqueDAO() { }

        public void Ajouter(CongeBanque obj, string id_utilisateur = null)
        {
            try
            {
                // -- Unicité du jour -- //
                if (Program.db.conges_banque.Exists(l => l.jour == obj.jour && l.mois == obj.mois))
                {
                    throw new GBException(App_Lang.Lang.Existing_day);
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Définition du code -- //
                try {
                    obj.code = new DateTime(DateTime.Now.Year, obj.mois, obj.jour).ToString("dd/MM");
                }
                catch {
                    throw new GBException(App_Lang.Lang.This_day_not_exist);
                }

                // -- Mise à jour reference -- //
                obj.utilisateur_createur = new UtilisateurDAO().ObjectId(obj.id_utilisateur);

                // -- Définition de la date de création -- //
                obj.date_creation = DateTime.Now.Ticks;

                // -- Enregistrement de la valeur -- //
                Program.db.conges_banque.Add(obj);

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

        public void Modifier(CongeBanque obj)
        {
            try
            {
                // -- Unicité du jour -- //
                if (Program.db.conges_banque.Exists(l => (l.id != obj.id) && l.jour == obj.jour && l.mois == obj.mois))
                {
                    throw new GBException(App_Lang.Lang.Existing_day);
                }

                // -- Définition du code -- //
                try
                {
                    obj.code = new DateTime(DateTime.Now.Year, obj.mois, obj.jour).ToString("dd/MM");
                }
                catch
                {
                    throw new GBException(App_Lang.Lang.This_day_not_exist);
                }

                // -- Modification de la valeur -- //
                Program.db.conges_banque
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
                        l.jour = obj.jour;
                        l.mois = obj.mois;
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
                    Program.db.conges_banque.RemoveAll(l => l.id == id);
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

        public List<CongeBanque> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.conges_banque;
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

        public CongeBanque ObjectCode(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.conges_banque.FirstOrDefault(l => l.code == code);
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

        public CongeBanque ObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}