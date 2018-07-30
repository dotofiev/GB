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
        public static List<Connexion> Hubs_Connexion { get { return System.Web.HttpContext.Current.Application["Hubs_Connexion"] as List<Connexion>; } }

        // -- Initialiser la connexion -- //
        public abstract void initConnexion();
    }
}