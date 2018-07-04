﻿using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class AutorisationDAO : GBDAO
    {
        public static void Ajouter(Autorisation obj)
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

        public static void Modifier(Autorisation obj)
        {
            try
            {
                //// -- Unicité du code -- //
                //if (Program.db.autorisations.Exists(l => l.id != obj.id && l.code == obj.code))
                //{
                //    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                //}

                //// -- Modification de la valeur -- //
                //Program.db.autorisations
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
                //// -- Parcours de la liste des id -- //
                //ids.ForEach(id =>
                //{
                //    // -- Suppression des valeurs -- //
                //    Program.db.autorisations.RemoveAll(l => l.id == id);
                //});
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

        public static List<Autorisation> Lister(long id_role)
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

        public static Autorisation Object(string code)
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

        public static long Crer_Id()
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

    }
}