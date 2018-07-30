using GB.Models.BO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public abstract class ParametreDAO : GBDAO
    {
        public static void Modifier(Parametre obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.parametres.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.parametres
                    // -- Spécifier la recherche -- //
                    .Where(l => l.id == obj.id)
                    // -- Lister le résultat -- //
                    .ToList()
                    // -- Parcourir les elements résultats -- //
                    .ForEach(l =>
                    {
                        // -- Mise à jour de l'enregistrement -- //
                        l.code = obj.code;
                        l.nombre_ligne_historique_compte = obj.nombre_ligne_historique_compte;
                        l.utilisation_chequier = obj.utilisation_chequier;
                        l.nombre_jour_avant_apuration_credit = obj.nombre_jour_avant_apuration_credit;
                        l.periode_dormante = obj.periode_dormante;
                        l.periode_litige = obj.periode_litige;
                        l.utilisation_version_centrale = obj.utilisation_version_centrale;
                        l.periode_de_non_paiement = obj.periode_de_non_paiement;
                        l.controler_le_nombre_de_pret = obj.controler_le_nombre_de_pret;
                        l.controler_le_nombre_de_comptes = obj.controler_le_nombre_de_comptes;
                        l.tva = obj.tva;
                        l.controler_session = obj.controler_session;
                        l.duree_session = obj.duree_session;
                        l.sms_banking = obj.sms_banking;
                        l.nombre_de_jour_ouverture_back_date = obj.nombre_de_jour_ouverture_back_date;
                        l.methode_de_post_interet_reserver = obj.methode_de_post_interet_reserver;
                        l.utilisation_litige_methode_cobac = obj.utilisation_litige_methode_cobac;
                        l.modifier_les_attributs_client_dans_la_branch = obj.modifier_les_attributs_client_dans_la_branch;
                        l.conter_le_nombre_de_page_dans_historique = obj.conter_le_nombre_de_page_dans_historique;
                        l.mise_a_jour_position_client = obj.mise_a_jour_position_client;
                        l.poster_credit = obj.poster_credit;
                        l.poster_litige_pret = obj.poster_litige_pret;
                        l.poster_collection_locale = obj.poster_collection_locale;
                        l.western_union = obj.western_union;
                        l.poster_bon_de_caisse_et_depot_a_terme = obj.poster_bon_de_caisse_et_depot_a_terme;
                        l.methode_de_sauvegarde = obj.methode_de_sauvegarde;
                        l.lien_sauvegarde_numero_1 = obj.lien_sauvegarde_numero_1;
                        l.lien_sauvegarde_numero_2 = obj.lien_sauvegarde_numero_2;
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

        public static List<Parametre> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres;
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

        public static Parametre Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres.FirstOrDefault(l => l.code == code);
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

        public static Parametre Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres.FirstOrDefault(l => l.id == id);
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

        public static Parametre Object()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.parametres.FirstOrDefault();
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