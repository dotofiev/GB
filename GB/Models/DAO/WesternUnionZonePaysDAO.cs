using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class WesternUnionZonePaysDAO : GBDAO
    {
        public static void Ajouter(WesternUnionZonePays obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.western_union_zones_pays.Exists(l => l.id_pays == obj.id_pays))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [" + App_Lang.Lang.Country + "]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour reference pays -- //
                obj.pays = PaysDAO.Object(obj.id_pays);

                // -- Enregistrement de la valeur -- //
                Program.db.western_union_zones_pays.Add(obj);
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

        public static void Modifier(WesternUnionZonePays obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.western_union_zones_pays.Exists(l => l.id != obj.id && l.id_pays == obj.id_pays))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [" + App_Lang.Lang.Country + "]");
                }

                // -- Modification de la valeur -- //
                Program.db.western_union_zones_pays
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.id_pays = obj.id_pays;
                        l.pays = PaysDAO.Object(obj.id_pays);
                        l.zone = obj.zone;
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
                    Program.db.western_union_zones_pays.RemoveAll(l => l.id == id);
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

        public static List<WesternUnionZonePays> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.western_union_zones_pays;
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

        public static WesternUnionZonePays Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.western_union_zones_pays.FirstOrDefault(l => l.code == code);
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
        
        public static WesternUnionZonePays Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.western_union_zones_pays.FirstOrDefault(l => l.id == id);
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