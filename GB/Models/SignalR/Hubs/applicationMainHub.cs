using GB.Models.BO;
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
    public class applicationMainHub : GBHub
    {
        public applicationMainHub() { }

        public override void initConnexion()
        {
            throw new NotImplementedException();
        }

        // - Lorsqu'un utilisateur se connecte sur le hub -- //
        public override Task OnConnected()
        {
            try
            {
                // -- Initialisation du context -- //
                context_hub = GlobalHost.ConnectionManager.GetHubContext<applicationMainHub>();

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
    }
}