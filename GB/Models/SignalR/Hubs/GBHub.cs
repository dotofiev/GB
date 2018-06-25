using GB.Models.BO;
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
        public static Dictionary<Connexion, string> Dictionaire_ConnectionId = new Dictionary<Connexion, string>();

        // -- Initialiser la connexion -- //
        public abstract void initConnexion();
    }
}