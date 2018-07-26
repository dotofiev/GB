using GB.Models.BO;
using GB.Models.Static;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.SignalR.Hubs
{
    public abstract class GBHub : Hub
    {
        // -- Variables -- //
        public IHubContext context_hub { get; set; }
        public static IHubContext context_hub_static { get; set; }
        public static List<Connexion> Hubs_Connexion { get { return System.Web.HttpContext.Current.Application["Hubs_Connexion"] as List<Connexion>; } }
        public string id_session_cookie { get { return Context.RequestCookies["id_session"].Value; } }
        public int id_lang_cookie { get { return Convert.ToInt32(Context.RequestCookies["id_lang"].Value); } }
        public string id_navigateur_client_cookie { get { return Context.RequestCookies["id_navigateur_client"].Value; } }

        // -- Initialiser la connexion -- //
        public abstract void initConnexion();

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
                    // -- Initialisation du context -- //
                    context_hub_static = GlobalHost.ConnectionManager.GetHubContext<applicationMainHub>();

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
        #endregion
    }
}