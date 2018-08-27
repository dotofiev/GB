using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Models.ActionFilter
{
    public class AuthentificationRequis : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                // -- Réccupération de la variable session -- //
                GBConnexion con = context.HttpContext.Session["Connexion"] as GBConnexion;

                // -- Teste si l'utilisateur est authentifié -- //
                if ((con?.id_utilisateur ?? "0") == "0")
                {
                    // -- Mise à jour de la route -- //
                    context.Result = new RedirectResult("/Home/Authentication");
                }
            }
            catch(Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                // -- Mise à jour de la route -- //
                context.Result = new RedirectResult("/Home/Authentication");
            }
        }
    }
}