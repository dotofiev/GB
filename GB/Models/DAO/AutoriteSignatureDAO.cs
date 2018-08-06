using GB.Models.BO;
using GB.Models.GB;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class AutoriteSignatureDAO : DAO
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationBudget_AutoriteSignature; } }
        public string context_id { get; set; }
        public long id_utilisateur { get; set; }
        public string form_combo_id { get { return "form_id_autorite_signature"; } }
        public string form_combo_code { get { return "form_code_autorite_signature"; } }
        public string form_name { get { return "autorite_signature"; } }
        public string form_combo_libelle { get { return "form_libelle_autorite_signature"; } }


        public AutoriteSignatureDAO(string context_id, long id_utilisateur)
        {
            this.context_id = context_id;
            this.id_utilisateur = id_utilisateur;
        }

        public void Ajouter(AutoriteSignature obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.autorites_signature.Exists(l => l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Enregistrement de la valeur -- //
                Program.db.autorites_signature.Add(obj);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.context_id);
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

        public void Modifier(AutoriteSignature obj)
        {
            try
            {
                // -- Unicité du code -- //
                if (Program.db.autorites_signature.Exists(l => l.id != obj.id && l.code == obj.code))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [code]");
                }

                // -- Modification de la valeur -- //
                Program.db.autorites_signature
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
                        l.montant_signature = obj.montant_signature;
                        l.limite_decouvert_client = obj.limite_decouvert_client;
                        l.debit_max_client = obj.debit_max_client;
                        l.credit_max_client = obj.credit_max_client;
                        l.montant_max_ligne_credit = obj.montant_max_ligne_credit;
                        l.montant_limite_pret = obj.montant_limite_pret;
                    });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.context_id);
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

        public void Supprimer(List<long> ids)
        {
            try
            {
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.autorites_signature.RemoveAll(l => l.id == id);
                });

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerTable(this.id_page, this.context_id);

                // -- Execution des Hubs -- //
                applicationMainHub.RechargerComboEasyAutocomplete(this, this.context_id);
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

        public static List<AutoriteSignature> Lister()
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.autorites_signature;
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

        public static AutoriteSignature Object(string code)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.autorites_signature.FirstOrDefault(l => l.code == code);
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

        public static AutoriteSignature Object(long id)
        {
            try
            {
                // -- Parcours de la liste -- //
                return
                    Program.db.autorites_signature.FirstOrDefault(l => l.id == id);
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
    }
}