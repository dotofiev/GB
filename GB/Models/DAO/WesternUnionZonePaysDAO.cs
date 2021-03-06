﻿using GB.Models.BO;
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
    public class WesternUnionZonePaysDAO : IDAO<WesternUnionZonePays>
    {
        public string id_page { get { return GB_Enum_Menu.ConfigurationOperation_WesternUnionZonePays; } }
        public GBConnexion connexion { get; set; }
        public string form_combo_id { get { return string.Empty; } }
        public string form_combo_code { get { return string.Empty; } }
        public string form_name { get { return "western_union_zone_pays"; } }
        public string form_combo_libelle { get { return string.Empty; } }


        public WesternUnionZonePaysDAO(GBConnexion con)
        {
            this.connexion = con;
        }

        public WesternUnionZonePaysDAO() { }

        public void Ajouter(WesternUnionZonePays obj, string id_utilisateur = null)
        {
            try
            {
                // -- Vérifier que le pays est bien soumis - //
                if (obj.id_pays == "0")
                {
                    throw new GBException(App_Lang.Lang.Data_required + " [" + App_Lang.Lang.Country + "]");
                }

                // -- Unicité du pays -- //
                if (Program.db.western_union_zones_pays.Exists(l => l.id_pays == obj.id_pays))
                {
                    throw new GBException(App_Lang.Lang.Existing_data + " [" + App_Lang.Lang.Country + "]");
                }

                // -- Définition de l'identifiant -- //
                obj.Crer_Id();

                // -- Mise à jour reference pays -- //
                obj.pays = new PAYSDAO().ObjectId(obj.id_pays);

                // -- Enregistrement de la valeur -- //
                Program.db.western_union_zones_pays.Add(obj);

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

        public void Modifier(WesternUnionZonePays obj)
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
                        l.pays = new PAYSDAO().ObjectId(obj.id_pays);
                        l.zone = obj.zone;
                    });

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
                // -- Parcours de la liste des id -- //
                ids.ForEach(id =>
                {
                    // -- Suppression des valeurs -- //
                    Program.db.western_union_zones_pays.RemoveAll(l => l.id == id);
                });

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

        public List<WesternUnionZonePays> Lister()
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

        public WesternUnionZonePays ObjectCode(string code)
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
        
        public WesternUnionZonePays ObjectId(string id)
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

        public dynamic HTML_Select()
        {
            throw new NotImplementedException();
        }
    }
}