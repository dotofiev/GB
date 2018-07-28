using GB.Controllers;
using GB.Models;
using GB.Models.ActionFilter;
using GB.Models.BO;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Variables
        public Connexion con { get { return Session["Connexion"] as Connexion; } set { Session["Connexion"] = value; } }
        public int id_lang { get { if (Session["id_lang"] == null) { return 0; } else { return (int)Session["id_lang"]; } } set { Session["id_lang"] = value; } }
        public string id_navigateur_client_cookies { get { return this.Request?.Cookies?["id_navigateur_client"]?.Value ?? string.Empty; } set { this.Response.Cookies["id_navigateur_client"].Value = value; } }
        public int id_lang_cookies { get { return Convert.ToInt32(this.Request?.Cookies?["id_lang"]?.Value ?? "0"); } set { this.Response.Cookies["id_lang"].Value = value.ToString(); } }
        public string id_session_cookies { get { return this.Request?.Cookies?["id_session"]?.Value ?? string.Empty; } set { this.Response.Cookies["id_session"].Value = value; } }
        #endregion

        #region URLs
        public string url_data { get { return Server.MapPath("~/App_Data/"); } }
        #endregion

        #region Methodes
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // -- Initialisation des hubs de connexion -- //
            Application.Add("Hubs_Connexion", new List<Connexion>());

            // -- Autoriser la configuration de log4net -- //
            log4net.Config.XmlConfigurator.Configure();

            // -- Test -- //
            Program.Initialiser_BD(url_data + "base_de_donnees.json");

            // -- Log du démarage de l'application -- //
            GBClass.Log.Info("Démarrage de l'application");
        }

        // -- Lorsque la session démare -- //
        protected void Session_OnStart()
        {
            // -- Mise à jour de la langue en fonction du dernier utilisateur connecté -- //
            #region Gestion de langue
            if (this.Request.Cookies.Get("id_lang") != null)
            {
                // -- Réccupération de l'identifian de la langue -- //
                this.id_lang = id_lang_cookies;
            }
            else
            {
                // -- Définition de la langue française par défaut -- //
                this.id_lang = 0;
                // -- Mise à jour de l'identification de la langue dans le cookie -- //
                id_lang_cookies = 0;
            }
            #endregion

            // -- Gestion de l'objet connexio nde lutilisateur -- //
            #region Gestion de l'utilisateur

            // -- Traitement de l'identifiant du client -- //
            #region Traitement de l'identifiant du client
            if (id_navigateur_client_cookies == string.Empty)
            {
                // -- Mise à jour de l'identifiant du client -- //
                id_navigateur_client_cookies = DateTime.Now.Ticks.ToString();
            }
            #endregion

            // -- Initialise une nouvelle session -- //
            this.con = new Connexion(this.Session.SessionID, id_navigateur_client_cookies);

            // -- Mise à jour de l'utilisateur dans le hub -- //
            if(applicationMainHub.Hubs_Connexion.Exists(l => l.id_navigateur_client == id_navigateur_client_cookies))
            {
                // -- Mise à jour de la position du client -- //
                applicationMainHub.MiseAJourHubs_Connexion(this.con);
            }
            // -- AJouter le client au hub -- //
            else
            {
                applicationMainHub.Hubs_Connexion.Add(this.con);
            }

            // -- Définition de la nouvelle session_id dans le cookie -- //
            id_session_cookies = this.con.session_id;

            // -- Teste si la session est vide -- //
            #region Commentaire
            /*
            if (this.con == null)
            {
                // -- Initialise une nouvelle session -- //
                this.con = new Connexion(this.Session.SessionID);

                // -- Vérifie que la session existe déjà dans le cookie -- //
                if (this.Request.Cookies["id_session"] != null &&
                    applicationMainHub.Dictionaire_ConnectionId.Count(l => l.Key.session_id == this.Request.Cookies["id_session"].Value) > 0)
                {
                    try
                    {
                        // -- Réccupération de la clé à supprimer -- //
                        Connexion key = applicationMainHub.Dictionaire_ConnectionId.FirstOrDefault(l => l.Key.session_id == this.Request.Cookies["id_session"].Value).Key;

                        // -- Suppression de l'ancien dictionnaire -- //
                        applicationMainHub.Dictionaire_ConnectionId.Remove(key);
                    }
                    catch (Exception ex)
                    {
                        // -- Log -- //
                        GBClass.Log.Error(ex);
                    }
                }

                // -- Ajout du nouvel élement dans le dictionnaire -- //
                applicationMainHub.Dictionaire_ConnectionId.Add(this.con, string.Empty);

                // -- Définition de la nouvelle session_id dans le cookie -- //
                this.Response.Cookies["id_session"].Value = this.con.session_id;
            }
            */
            #endregion

            #endregion

            // -- Log du début d'une session -- //
            GBClass.Log.Info("Début session: {session:" + id_session_cookies + "}");
        }

        // -- Lorsque la session se termine -- //
        protected void Session_OnEnd()
        {
            // -- Appel la méthode de déconnexion de l'utilisateur -- //
            applicationMainHub.DeconnecterClient(this.con.hub_id_context);

            // -- Log du fin d'une session -- //
            GBClass.Log.Info("Fin session: {session:" + this.con.session_id + "}");
        }

        // -- Lorsqu'une erreur survient dans l'application -- //
        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                // -- Réccupération des détails de l'exception -- //
                Exception ex = Server.GetLastError().GetBaseException();
                // -- Variable de tye HTTP -- //
                HttpException ex_http = null;

                try
                {
                    // -- Essai de conversion de l'exception en type HTTP -- //
                    ex_http = ex as HttpException;
                }
                catch { }

                // -- Log -- //
                GBClass.Log.Error(ex);

                // -- Variable paramètre à envoyer à la page -- //
                string dt = GB.Models.Cryptage.Program.EncryptStringAES(
                                GBConvert.To_JavaScript(new
                                {
                                    code = (ex_http != null) ? ex_http.GetHttpCode()
                                                             : 500,
                                    message = ex.Message,
                                    id_lang = id_lang_cookies.ToString(),
                                    reconnecter = true
                                })
                            );

                // -- Mise à jour du filtre de réponse -- //
                Response.Filter = new ResponseErreur(Response.Filter, dt);
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        // -- Lors que l'application s'arrête -- //
        protected void Application_End()
        {
            // -- Log de l'arrêt de l'application -- //
            GBClass.Log.Info("Arrèt de l'application");
        }
        #endregion
    }
}
