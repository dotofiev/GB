using GB.Models.BO;
using GB.Models.GB;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.Entites;
using GB.Models.Interfaces;
using System.Data.Entity.Core.Objects;

namespace GB.Models.DAO
{
    public class DeviseDAO : IDAO<Devise>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBanque_Devise; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_devise"; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "devise"; } }
        public string form_combo_libelle { get { return "form_libelle_devise"; } }


        public DeviseDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public DeviseDAO() { }

        public void Ajouter(Devise obj, string id_utilisateur = null)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.devises.Exists(l => l.code == obj.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Définition de l'identifiant -- //
                    obj.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    Program.db.devises.Add(obj);

                    // -- Mise à jour de la devise atuelle -- //
                    if (obj.devise_actuelle)
                    {
                        Mise_a_jour_devise_actuelle(obj.id);
                    }
                }
                #endregion

                #region Processus fonctionnel
                else
                {
                    // -- Définition du context -- //
                    using(BankingEntities db = new BankingEntities())
                    {
                        // -- Désactivation du Lasy loading -- //
                        db.Configuration.LazyLoadingEnabled = false;

                        // -- Définition des variables -- //
                        Dictionary<string, object> parametres = new Dictionary<string, object>();
                        parametres.Add("date_creation", this.connexion.date_serveur);

                        // -- Enregistrement de la données -- //
                        db.devises.Add(obj.ToEntities(parametres));

                        // -- Mise à jour de la devise atuelle -- //
                        if (obj.devise_actuelle)
                        {
                            Mise_a_jour_devise_actuelle(obj.id, db);
                        }

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new DeviseDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public void Modifier(Devise obj)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.devises.Exists(l => l.id != obj.id && l.code == obj.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Modification de la valeur -- //
                    Program.db.devises
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
                            l.signe = obj.signe;
                            l.devise_actuelle = obj.devise_actuelle;
                        });

                    // -- Mise à jour de la devise atuelle -- //
                    if (obj.devise_actuelle)
                    {
                        Mise_a_jour_devise_actuelle(obj.id);
                    }
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
                        devise ancien_obj = db.devises.Find(obj.code);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        obj.ModifyEntities(ancien_obj);

                        // -- Enregistrement de la données -- //
                        db.Entry<devise>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

                        // -- Mise à jour de la devise atuelle -- //
                        if (obj.devise_actuelle)
                        {
                            Mise_a_jour_devise_actuelle(obj.id, db);
                        }

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new DeviseDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public void Supprimer(List<string> ids)
        {
            try
            {
                // -- Si l'application est branché à la base de données -- //
                #region Processus de teste
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste des id -- //
                    ids.ForEach(id =>
                    {
                        // -- Suppression des valeurs -- //
                        Program.db.devises.RemoveAll(l => l.id == id);
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
                        db.devises.RemoveRange(
                            // -- Réccupérer les éléments à supprimer -- //
                            db.devises.Where(l => ids.Count(ll => ll.Equals(l.devcod)) != 0)
                        );

                        // -- Mise à jour de la devise atuelle -- //
                        Mise_a_jour_devise_actuelle(null, db, ids);

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new DeviseDAO());
                applicationMainHub.RechargerTable(this.id_page, this.connexion.hub_id_context);
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

        public List<Devise> Lister()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.devises;
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
                                db.devises.ToList()
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

        public static Devise Actif()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.devises.FirstOrDefault(l => l.devise_actuelle);
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
                            new Devise(
                                db.devises.FirstOrDefault(l => l.CurrentCurrency == "Yes")
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

        public Devise ObjectCode(string code)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.devises.FirstOrDefault(l => l.code == code);
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
                            new Devise(
                                db.devises.Find(code)
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
        public Devise ObjectId(string id)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.devises.FirstOrDefault(l => l.id == id);
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
                            new Devise(
                                db.devises.Find(id)
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

        private static void Mise_a_jour_devise_actuelle(string id)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Vérification de la nature de l'identifiant -- //
                    if (long.Parse(id) <= 0)
                    {
                        throw new GBException(App_Lang.Lang.The_object_must_have_a_unique_id);
                    }

                    Program.db.devises
                        .Where(l => l.id != id)
                        .ToList()
                        .ForEach(l =>
                        {
                            l.devise_actuelle = false;
                        }
                    );
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
                        devise ancien_obj = db.devises.Find(id);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        ancien_obj.CurrentCurrency = "No";

                        // -- Enregistrement de la données -- //
                        db.Entry<devise>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
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

        private static void Mise_a_jour_devise_actuelle(string id, BankingEntities db, List<string> ids_supprimer = null)
        {
            try
            {
                // -- Si l'identifiant est retournée - //
                if (id != null)
                {
                    // -- Rechercher l'objet à modifier -- //
                    db.devises.Where(l => l.devcod != id && l.CurrentCurrency == "Yes")
                        .ToList()
                        .ForEach(ancien_obj =>
                        {
                            // -- Vérifier que l'objet est retournée -- //
                            if (ancien_obj != null)
                            {
                                // -- Mise à jour de l'ancienne valeur -- //
                                ancien_obj.CurrentCurrency = "No";

                                // -- Enregistrement de la données -- //
                                db.Entry<devise>(ancien_obj).State = System.Data.Entity.EntityState.Modified;
                            }
                        });
                }
                else
                {
                    // -- Vérifier si il n'existe plus de devise active -- //
                    if(db.devises.Where(l => ids_supprimer.Count(ll => ll == l.devcod) == 0).Count(l => l.CurrentCurrency == "Yes") == 0)
                    {
                        // -- Réccupérer une devise à définir comme active -- //
                        devise ancien_obj = db.devises.FirstOrDefault(l => ids_supprimer.Count(ll => ll == l.devcod) == 0);

                        // -- Si la devise n'est pas trouvée -- //
                        if(ancien_obj == null)
                        {
                            return;
                        }
                        
                        // -- Mise à jour de l'ancienne valeur -- //
                        ancien_obj.CurrentCurrency = "Yes";

                        // -- Enregistrement de la données -- //
                        db.Entry<devise>(ancien_obj).State = System.Data.Entity.EntityState.Modified;
                    }
                }
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
                    foreach (var val in new DeviseDAO().Lister())
                    {
                        HTML += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    }
                }
                else if (champ == "libelle")
                {
                    foreach (var val in new DeviseDAO().Lister())
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

        public dynamic HTML_Select()
        {
            try
            {
                // -- Objet dynamic -- //
                dynamic donnee = new System.Dynamic.ExpandoObject();

                // -- Valeur vide -- //
                donnee.html_code = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";
                donnee.html_libelle = $"<option value=\"\" title=\"{App_Lang.Lang.Select}...\">{App_Lang.Lang.Select}...</option>";

                // -- Ajout des options -- //

                foreach (var val in Lister())
                {
                    donnee.html_code += $"<option value=\"{val.id}\" title=\"{val.code}\">{val.code}</option>";
                    donnee.html_libelle += $"<option value=\"{val.id}\" title=\"{val.libelle}\">{val.libelle}</option>";
                }

                // -- Retourner l'objet -- //
                return donnee;
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

        public static IEnumerable<Devise> FromEntities(List<devise> listObj)
        {
            foreach (var obj in listObj)
            {
                if (obj == null)
                    continue;

                yield return new Devise(obj);
            }
        }
    }
}