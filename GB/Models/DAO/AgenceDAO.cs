using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class AgenceDAO : GBDAO
    {
        public static void Ajouter(Agence obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.agences.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour des references -- //
                obj.utilisateur = UtilisateurDAO.Object(obj.id_utilisateur);

                // -- Enregistrement de la valeur -- //
                Program.db.agences.Add(obj);
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

        public static void Modifier(Agence obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.agences.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.agences
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
                        l.id_utilisateur = obj.id_utilisateur;
                        l.utilisateur = UtilisateurDAO.Object(obj.id_utilisateur);
                        l.adresse = obj.adresse;
                        l.ville = obj.ville;
                        l.bp = obj.bp;
                        l.telephone = obj.telephone;
                        l.pays = obj.pays;
                        l.fax = obj.fax;
                        l.cobac_id = obj.cobac_id;
                        l.beac_id = obj.beac_id;
                        l.ip = obj.ip;
                        l.mot_de_passe = obj.mot_de_passe;
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
                    Program.db.agences.RemoveAll(l => l.id == id);
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

        public static List<Agence> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.agences;
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

        public static Agence Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.agences.FirstOrDefault(l => l.code == code);
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

        public static Agence Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.agences.FirstOrDefault(l => l.id == id);
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

        public static string HTML_Select(string champ)
        {
            try
            {
                // -- Valeur vide -- //
                string HTML = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                // -- Ajout des options -- //
                // -- Pour le champ code -- //
                if (champ == "code")
                {
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    }
                }
                else if (champ == "libelle")
                {
                    foreach (var val in Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                    }
                }

                return HTML;
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