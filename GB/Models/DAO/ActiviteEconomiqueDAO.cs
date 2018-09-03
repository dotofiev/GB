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
    public class ActiviteEconomiqueDAO : IDAO<ActiviteEconomique>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_ActiviteEconomique; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "activite_economique"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public ActiviteEconomiqueDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public ActiviteEconomiqueDAO() { }

        public void Ajouter(ActiviteEconomique obj, string id_utilisateur = null)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
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
                    obj.utilisateur_createur = new UtilisateurDAO().ObjectId(id_utilisateur);

                    // -- Enregistrement de la valeur -- //
                    Program.db.activites_economique.Add(obj);
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

                        // -- Définition des variables -- //
                        Dictionary<string, object> parametres = new Dictionary<string, object>();
                        parametres.Add("date_creation", this.connexion.date_serveur);

                        // -- Enregistrement de la données -- //
                        db.ActiviteEcoes.Add(obj.ToEntities(parametres));

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

        public void Modifier(ActiviteEconomique obj)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
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
                        ActiviteEco ancien_obj = db.ActiviteEcoes.Find(obj.code);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        obj.ModifyEntities(ancien_obj);

                        // -- Enregistrement de la données -- //
                        db.Entry<ActiviteEco>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

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

        public void Supprimer(List<string> ids)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste des id -- //
                    ids.ForEach(id =>
                    {
                        // -- Suppression des valeurs -- //
                        Program.db.activites_economique.RemoveAll(l => l.id == id);
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

                        // -- Supprimer la liste -- //
                        db.ActiviteEcoes.RemoveRange(
                            // -- Réccupérer les éléments à supprimer -- //
                            db.ActiviteEcoes.Where(l => ids.Count(ll => ll.Equals(l.ActiviteEco1)) != 0)
                        );

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

        public List<ActiviteEconomique> Lister()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.activites_economique;
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
                                db.ActiviteEcoes.ToList()
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

        public ActiviteEconomique ObjectCode(string code)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.activites_economique.FirstOrDefault(l => l.code == code);
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
                            new ActiviteEconomique(
                                db.ActiviteEcoes.Find(code)
                            );
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

        public static IEnumerable<ActiviteEconomique> FromEntities(List<ActiviteEco> listObj)
        {
            foreach (var obj in listObj)
            {
                if (obj == null)
                    continue;

                yield return new ActiviteEconomique(obj);
            }
        }

        public ActiviteEconomique ObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}