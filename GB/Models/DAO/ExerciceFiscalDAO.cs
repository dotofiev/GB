using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class ExerciceFiscalDAO : GBDAO
    {
        public static void Ajouter(ExerciceFiscal obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.exercices_fiscal.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour du statut -- //
                obj.statut = "O";

                // -- Mise à jour des date -- //
                obj.date_debut = GBConvert.To_DateTime(obj.date_debut).Ticks.ToString();
                obj.date_fin = GBConvert.To_DateTime(obj.date_fin).Ticks.ToString();

                // -- Vérification de la date -- //
                if (Convert.ToInt64(obj.date_debut) >= Convert.ToInt64(obj.date_fin))
                {
                    throw new GBException(App_Lang.Lang.Invalid_date + " [date_debut]");
                }

                // -- Enregistrement de la valeur -- //
                Program.db.exercices_fiscal.Add(obj);
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

        public static void Modifier(ExerciceFiscal obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.exercices_fiscal.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Mise à jour des date -- //
                obj.date_debut = GBConvert.To_DateTime(obj.date_debut).Ticks.ToString();
                obj.date_fin = GBConvert.To_DateTime(obj.date_fin).Ticks.ToString();
                
                // -- Vérification de la date -- //
                if (Convert.ToInt64(obj.date_debut) >= Convert.ToInt64(obj.date_fin))
                {
                    throw new GBException(App_Lang.Lang.Invalid_date + " [date_debut]");
                }

                // -- Modification de la valeur -- //
                Program.db.exercices_fiscal
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
                        l.date_debut = obj.date_debut;
                        l.date_fin = obj.date_fin;
                        l.budget_id = obj.budget_id;
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
                    Program.db.exercices_fiscal.RemoveAll(l => l.id == id);
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

        public static List<ExerciceFiscal> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.exercices_fiscal;
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

        public static ExerciceFiscal Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.exercices_fiscal.FirstOrDefault(l => l.code == code);
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