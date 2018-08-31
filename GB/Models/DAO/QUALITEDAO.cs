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
    public class QUALITEDAO : IDAO
    {
        public string id_page { get { return string.Empty; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return "form_id_qualite"; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "qualite"; } }
        public string form_combo_libelle { get { return "form_libelle_qualite"; } }


        public QUALITEDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public QUALITEDAO() { }

        public void Ajouter(QUALITE obj)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.qualites.Exists(l => l.code == obj.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Définition de l'identifiant -- //
                    obj.Crer_Id();

                    // -- Enregistrement de la valeur -- //
                    Program.db.qualites.Add(obj);
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

                        // -- Enregistrement de la données -- //
                        db.Qualites.Add(obj.ToEntities());

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new QUALITEDAO());
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

        public void Modifier(QUALITE obj)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Unicité du code -- //
                    if (Program.db.qualites.Exists(l => l.id != obj.id && l.code == obj.code))
                    {
                        throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                    }

                    // -- Modification de la valeur -- //
                    Program.db.qualites
                        // -- Spécifier la recherche -- //
                        .Where(l => l.id == obj.id)
                        // -- Lister le résultat -- //
                        .ToList()
                        // -- Parcourir les elements résultats -- //
                        .ForEach(l =>
                        {
                            // -- Mise à jour de l'enregistrement -- //
                            l.code = obj.code;
                            l.libelle_fr = obj.libelle_fr;
                            l.libelle_en = obj.libelle_en;
                            l.id = obj.id;
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
                        Qualite ancien_obj = db.Qualites.Find(obj.code);

                        // -- Vérifier que l'objet est retournée -- //
                        if (ancien_obj == null)
                        {
                            throw new GBException(App_Lang.Lang.Object_not_found);
                        }

                        // -- Mise à jour de l'ancienne valeur -- //
                        obj.ModifyEntities(ancien_obj);

                        // -- Enregistrement de la données -- //
                        db.Entry<Qualite>(ancien_obj).State = System.Data.Entity.EntityState.Modified;

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new QUALITEDAO());
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
                        Program.db.qualites.RemoveAll(l => l.id == id);
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
                        db.Qualites.RemoveRange(
                            // -- Réccupérer les éléments à supprimer -- //
                            db.Qualites.Where(l => ids.Count(ll => ll.Equals(l.Qualite1)) != 0)
                        );

                        // -- Sauvegarder les changements -- //
                        db.SaveChanges();
                    }
                }
                #endregion

                // -- Execution des Hubs -- //
                #region Execution des Hubs
                applicationMainHub.RechargerCombo(new QUALITEDAO());
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

        public static List<QUALITE> Lister()
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.qualites;
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
                                db.Qualites.ToList()
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

        public static QUALITE ObjectCode(string code)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.qualites.FirstOrDefault(l => l.code == code);
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
                            new QUALITE(
                                db.Qualites.FirstOrDefault(l => l.Qualite1 == code)
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
        public static QUALITE ObjectId(string id)
        {
            try
            {
                #region Processus de teste
                // -- Si l'application est branché à la base de données -- //
                if (!AppSettings.CONNEXION_DB_BANKINGENTITIES)
                {
                    // -- Parcours de la liste -- //
                    return
                        Program.db.qualites.FirstOrDefault(l => l.id == id);
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
                            new QUALITE(
                                db.Qualites.Find(id)
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

        public static IEnumerable<QUALITE> FromEntities(List<Qualite> listObj)
        {
            foreach (var obj in listObj)
            {
                if (obj == null)
                    continue;

                yield return new QUALITE(obj);
            }
        }
    }
}