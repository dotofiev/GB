using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Static;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GB.Models.SignalR.Hubs
{
    [HubName("applicationMainHub")]
    public class applicationMainHub : Hub
    {
        // -- Variables -- //
        public IHubContext context_hub { get { return GlobalHost.ConnectionManager.GetHubContext<applicationMainHub>(); } }
        public static IHubContext context_hub_static { get { return GlobalHost.ConnectionManager.GetHubContext<applicationMainHub>(); } }
        public static List<Connexion> Hubs_Connexion { get { return System.Web.HttpContext.Current.Application["Hubs_Connexion"] as List<Connexion>; } }
        public string id_session_cookie { get { return Context.RequestCookies["id_session"].Value; } }
        public int id_lang_cookie { get { return Convert.ToInt32(Context.RequestCookies["id_lang"].Value); } }
        public string id_navigateur_client_cookie { get { return Context.RequestCookies["id_navigateur_client"].Value; } }

        public applicationMainHub() { }

        // - Lorsqu'un utilisateur se connecte sur le hub -- //
        public override Task OnConnected()
        {
            try
            {
                // -- Appel de la méthode client pour mettre à jour mon context_hub -- //
                context_hub
                    // -- Les clients -- //
                    .Clients
                    // -- Spécification du client à appeler -- //
                    .Client(Context.ConnectionId)
                    // -- Méthode à éexecuter chez le client -- //
                    .chargerConnectionIdClient(
                        // -- Paramètres -- //
                        new GBNotification(
                            Context.ConnectionId
                        )
                    );
            }
            catch(Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }

            return base.OnConnected();
        }

        // -- Lorsqu'un utilisateur se déconnecte du hub -- //
        /*
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        */

        // -- Lorsqu'un utilisateur actualise le hub, se reconnecte -- //
        /*
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        */

        #region Methodes
        // -- Mise à jour du client dans la liste -- //
        public static void MiseAJourHubs_Connexion(Connexion con)
        {
            // -- Réccupération de la position -- //
            int position = Hubs_Connexion.FindIndex(l => l.id_navigateur_client == con.id_navigateur_client);

            // -- Mise à jour de la position -- //
            Hubs_Connexion[position] = con;
        }

        // -- Notifie à l'utilisateur actuel que sa session vient de se terminer -- //
        public static void DeconnecterClient(string context_id)
        {
            try
            {
                // -- Vérifie que le context est bien soumis -- //
                if (!string.IsNullOrEmpty(context_id))
                {
                    // -- Appel de la méthode client pour déconnecter l'utilisateur -- //
                    context_hub_static
                        // -- Les clients -- //
                        .Clients
                        // -- Spécification du client à appeler -- //
                        .Client(context_id)
                        // -- Méthode à éexecuter chez le client -- //
                        .deconnecterClient(
                            new GBNotification(
                                $"<b>{App_Lang.Lang.The_session_has_just_ended}!</b><br/>{App_Lang.Lang.You_will_be_disconnected}.",
                                false
                            )
                        );
                }
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        // -- Mise à jour des combo box sur les pages des clients -- //
        #region Mise à jour des combo box sur les pages des clients
        public static void RechargerCombo(GBDAO ObjetDAO)
        {
            try
            {
                // -- Construction de l'objet à envoyer en paramètre -- //
                string select_code = string.Empty, select_libelle = string.Empty;
                ObjetDAO.HTML_Select(ref select_code, ref select_libelle);

                // -- Appel de la méthode client pour déconnecter l'utilisateur -- //
                context_hub_static
                    // -- Les clients -- //
                    .Clients
                    // -- Spécification à tous les clients sauf moi -- //
                    //.AllExcept(new string[] { context_id })
                    // -- Spécifier à tous les clients -- //
                    .All
                    // -- Méthode à éexecuter chez le client -- //
                    .rechargerCombo(
                        new GBNotification(
                            new
                            {
                                select_code = select_code,
                                select_libelle = select_libelle,
                                form_id = $"#{ObjetDAO.form_combo_id}",
                                form_libelle = $"#{ObjetDAO.form_combo_libelle}"
                            }
                        )
                    );
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }
        #endregion

        // -- Mise à jour de la table chez tous les clients présent sur la page -- //
        #region Mise à jour de la table chez tous les clients présent sur la page
        public static void RechargerTable(string id_page, string context_id)
        {
            try
            {
                // -- Communiquer aux autres clients si la présentation des données en temps réel est activé -- //
                if (AppSettings.DONNEE_EN_TEMPS_REEL)
                {
                    // -- Appel de la méthode client pour déconnecter l'utilisateur -- //
                    context_hub_static
                        // -- Les clients -- //
                        .Clients
                        // -- Spécification à tous les clients sauf moi -- //
                        .AllExcept(new string[] { context_id })
                        // -- Spécifier à tous les clients -- //
                        //.All
                        // -- Méthode à éexecuter chez le client -- //
                        .rechargerTable(
                            new GBNotification(
                                new
                                {
                                    id_page = id_page
                                }
                            )
                        );
                }
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }
        #endregion

        #endregion
    }
}