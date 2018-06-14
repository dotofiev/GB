using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class HomeController : GBController
    {
        #region HttpGet
        [HttpGet]
        public ActionResult Authentication()
        {
            // -- Charger les paramètres par défaut de la page -- //
            Charger_Parametres();

            // -- Titre de la page -- //
            this.ViewBag.Title = $"Global Bank - ({App_Lang.Lang.Authentication})";

            // -- Identifiant de la page -- //
            this.ViewBag.Id_page = "Home-Authentication";

            return View();
        }
        #endregion

        #region HttpPost
        
        #endregion
    }
}