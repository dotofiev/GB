using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class CongeBanqueDAO : GBDAO
    {
        public static void Ajouter(CongeBanque obj)
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
                obj.utilisateur_createur = UtilisateurDAO.Object(obj.id_utilisateur);

                // -- Définition de la date de création -- //
                obj.date_creation = DateTime.Now.Ticks;

                // -- Enregistrement de la valeur -- //
                Program.db.conges_banque.Add(obj);
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

        public static void Modifier(CongeBanque obj)
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

        public static void Supprimer(List<long> ids)
        {
            try
            {
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.conges_banque.RemoveAll(l => l.id == id);
                });
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

        public static List<CongeBanque> Lister()
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

        public static CongeBanque Object(string code)
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

    }
}