using GB.Models.BO;
using GB.Models.Entites;
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
    public class ParametreDAO : IDAO<BO.Parametre>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_Parametre; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "parametre"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public ParametreDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public ParametreDAO() { }

        public void Modifier(BO.Parametre obj, string id_utilisateur = null)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
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
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Rechercher l'objet à modifier -- //
                        GeneralPara ancien_obj = db.GeneralParas.Find(obj.code);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        obj.ModifyEntities(ancien_obj);

                        // -- Enregistrement de la données -- //
                        db.Entry<GeneralPara>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

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

        public List<BO.Parametre> Lister()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.parametres;
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        return
                            FromEntities(
                                db.GeneralParas.ToList()
                            ).ToList();
                    }
                }
                #endregion
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

        public BO.Parametre ObjectCode(string code)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.parametres.FirstOrDefault(l => l.code == code);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Réccupération de la valeur à retourner -- //
                        var value = db.GeneralParas.FirstOrDefault(l => l.SerieNum == int.Parse(code));

                        return
                            value != null ? new BO.Parametre(value)
                                          : null;
                    }
                }
                #endregion
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

        public BO.Parametre ObjectId(string id)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.parametres.FirstOrDefault(l => l.id == id);
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Réccupération de la valeur à retourner -- //
                        var value = db.GeneralParas.FirstOrDefault(l => l.SerieNum == int.Parse(id));

                        return
                            value != null ? new BO.Parametre(value)
                                          : null;
                    }
                }
                #endregion
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

        public BO.Parametre Object()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.parametres.FirstOrDefault();
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using (BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Réccupération de la valeur à retourner -- //
                        var value = db.GeneralParas.FirstOrDefault();

                        return
                            value != null ? new BO.Parametre(value)
                                          : null;
                    }
                }
                #endregion
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

        public void Ajouter(BO.Parametre obj, string id_utilisateur = null)
        {
            throw new NotImplementedException();
        }

        public void Modifier(BO.Parametre obj)
        {
            throw new NotImplementedException();
        }

        public void Supprimer(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<BO.Parametre> FromEntities(List<GeneralPara> listObj)
        {
            foreach (var obj in listObj)
            {
                if (obj == null)
                    continue;

                yield return new BO.Parametre(obj);
            }
        }
    }
}