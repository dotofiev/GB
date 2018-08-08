using GB.Models;
using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.GB;
using GB.Models.Helper;
using GB.Models.SignalR.Hubs;
using GB.Models.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GB.Controllers
{
    public class GBController : Controller
    {
        #region Variables
        public GBConnexion con { get { return Session["Connexion"] as GBConnexion; } set { Session["Connexion"] = value; } }
        public int id_lang { get { if (Session["id_lang"] == null) { return 0; } else { return (int)Session["id_lang"]; } } set { Session["id_lang"] = value; } }
        public long id_menu_actif { get { if (Session["id_menu_actif"] == null) { return 0; } else { return (long)Session["id_menu_actif"]; } } set { Session["id_menu_actif"] = value; } }
        public string id_navigateur_client_cookies { get { return this.Request?.Cookies?["id_navigateur_client"]?.Value ?? string.Empty; } set { this.Response.Cookies["id_navigateur_client"].Value = value; } }
        public int id_lang_cookies { get { return Convert.ToInt32(this.Request?.Cookies?["id_lang"]?.Value ?? "0"); } set { this.Response.Cookies["id_lang"].Value = value.ToString(); } }
        public string id_session_cookies { get { return this.Request?.Cookies?["id_session"]?.Value ?? string.Empty; } set { this.Response.Cookies["id_session"].Value = value; } }
        
        #region DAO
        public PaysDAO paysDAO { get { return new PaysDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public TypePretDAO typePretDAO { get { return new TypePretDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public MotifPretDAO motifPretDAO { get { return new MotifPretDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ClassificationProvisionsPretDAO classificationProvisionsPretDAO { get { return new ClassificationProvisionsPretDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public TypeGarantieDAO typeGarantieDAO { get { return new TypeGarantieDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public JournalDAO journalDAO { get { return new JournalDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public TypeActifDAO typeActifDAO { get { return new TypeActifDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public LocalisationActifDAO localisationActifDAO { get { return new LocalisationActifDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public WesternUnionZonePaysDAO westernUnionZonePaysDAO { get { return new WesternUnionZonePaysDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public CompteDAO compteDAO { get { return new CompteDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public DeviseDAO deviseDAO { get { return new DeviseDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public InstitutionDAO institutionDAO { get { return new InstitutionDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public AgenceDAO agenceDAO { get { return new AgenceDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ParametreBanqueDAO parametreBancaireDAO { get { return new ParametreBanqueDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ProduitPhysiqueDAO produitPhysiqueDAO { get { return new ProduitPhysiqueDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ProduitJudiciaireDAO produitJudiciaireDAO { get { return new ProduitJudiciaireDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public VilleDAO villeDAO { get { return new VilleDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ActiviteEconomiqueDAO activiteEconomiqueDAO { get { return new ActiviteEconomiqueDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public TitreDAO titreDAO { get { return new TitreDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public UniteInstitutionnelleDAO uniteInstitutionnelleDAO { get { return new UniteInstitutionnelleDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public BEACNationaliteDAO bEACNationaliteDAO { get { return new BEACNationaliteDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public CongeBanqueDAO congeBanqueDAO { get { return new CongeBanqueDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ParametreDAO parametreDAO { get { return new ParametreDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ExerciceFiscalDAO exerciceFiscalDAO { get { return new ExerciceFiscalDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public DirectionBudgetDAO directionBudgetDAO { get { return new DirectionBudgetDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public AutoriteSignatureDAO autoriteSignatureDAO { get { return new AutoriteSignatureDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public RoleDAO roleDAO { get { return new RoleDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public MenuDAO menuDAO { get { return new MenuDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ModuleDAO moduleDAO { get { return new ModuleDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public AutorisationDAO autorisationDAO { get { return new AutorisationDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public UtilisateurDAO utilisateurDAO { get { return new UtilisateurDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ProfessionDAO professionDAO { get { return new ProfessionDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public CompteAgenceDAO compteAgenceDAO { get { return new CompteAgenceDAO(this.con.hub_id_context, this.con.id_utilisateur); } }
        public ProfitabiliteDAO profitabiliteDAO { get { return new ProfitabiliteDAO(this.con.hub_id_context, this.con.id_utilisateur); } }        
        #endregion
        #endregion

        #region URLs
        public string url_data { get { return Server.MapPath("~/App_Data/"); } }
        public string url_resources { get { return Server.MapPath("~/Resources/"); } }
        public string url_plugins { get { return Server.MapPath("~/Plugins/"); } }
        #endregion

        // -- Code de gestion de la langue en session -- //
        #region Code de gestion de la langue en session
        protected override void ExecuteCore()
        {
            try
            {
                int Culture = 0;

                if (this.Session == null || Session["id_lang"] == null)
                {
                    int.TryParse(Thread.CurrentThread.CurrentCulture.Name, out Culture);
                    this.id_lang = Culture;
                }
                else
                {
                    Culture = this.id_lang;
                }

                // -- Mise à jour de l'etat de la langue -- //
                LangHelper.CurrentCulture = Culture;

                base.ExecuteCore();
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }

        [HttpGet]
        public ActionResult Set_Langue(int id_lang)
        {
            // Change the current culture for this user.
            LangHelper.CurrentCulture = id_lang;

            // Cache the new current culture into the user HTTP session. 
            this.id_lang = id_lang;

            // -- Mise à jour de la langue dans le cookie utilisateur -- //
            Set_Cookie_Langue(id_lang);

            // -- Effectuer une redirection sur la même page -- // 
            return Redirect(Request.UrlReferrer.ToString());
        }

        // -- Mise à jour du cookie de langue -- //
        private void Set_Cookie_Langue(int id_lang)
        {
            Response.Cookies["id_lang"].Value = id_lang.ToString();
        }
        #endregion

        // -- Méthodes -- //
        #region Méthodes
        public virtual void Charger_Langue_Et_Donnees(string id_page) { }
        
        public virtual object Charger_EasyAutocomplete(string id_page, string id_vue) { return null; }

        public virtual object Recharger_EasyAutocomplete(string id_page, string id_vue) { return null; }

        public void Charger_Parametres()
        {
            // -- Version de l'application -- //
            this.ViewBag.VERSION_BUILD = AppSettings.VERSION_BUILD;

            // -- Nom de l'application -- //
            this.ViewBag.APP_NAME = AppSettings.APP_NAME;

            // -- Paramètres langue -- //
            this.ViewBag.Lang = new System.Dynamic.ExpandoObject();

            // -- Initialisation des données à traiter -- //
            this.ViewBag.donnee = new System.Dynamic.ExpandoObject();

            // -- Paramètres de test -- //
            this.ViewBag.Test = new System.Dynamic.ExpandoObject();

            // -- Langue de l'application -- //
            this.ViewBag.Lang.code = (this.id_lang == 0) ? GB_Enum_Langue.Anglais
                                                         : GB_Enum_Langue.Francais;

            // -- Label cookiee -- //
            this.ViewBag.Lang.Cookie_message    = App_Lang.Lang.Cookie_message;
            this.ViewBag.Lang.Cookie_button     = App_Lang.Lang.Cookie_button;
            this.ViewBag.Lang.Copyright         = App_Lang.Lang.Copyright;
            this.ViewBag.Lang.Process           = App_Lang.Lang.Process;

            // -- Lable bouton -- //
            this.ViewBag.Lang.New       = App_Lang.Lang.New;
            this.ViewBag.Lang.Delete    = App_Lang.Lang.Delete;
            this.ViewBag.Lang.Save      = App_Lang.Lang.Save;
            this.ViewBag.Lang.Print     = App_Lang.Lang.Print;
            this.ViewBag.Lang.Close     = App_Lang.Lang.Close;
            this.ViewBag.Lang.Form      = App_Lang.Lang.Form;
            this.ViewBag.Lang.Yes       = App_Lang.Lang.Yes;
            this.ViewBag.Lang.No        = App_Lang.Lang.No;
            this.ViewBag.Lang.Modify    = App_Lang.Lang.Modify;
            this.ViewBag.Lang.Name = App_Lang.Lang.Name;
            this.ViewBag.Lang.Name_french = App_Lang.Lang.Name + "-" + App_Lang.Lang.French;
            this.ViewBag.Lang.Name_english = App_Lang.Lang.Name + "-" + App_Lang.Lang.English;
            this.ViewBag.Lang.Creation_date = App_Lang.Lang.Creation_date;
            this.ViewBag.Lang.Employee = App_Lang.Lang.Employee;

            // -- Autre -- //
            this.ViewBag.Lang.List_of_records = App_Lang.Lang.List_of_records;

            // -- Rendu html dans les combo box -- //
            this.ViewBag.donnee.HTML_Non_Oui = GBClass.HTML_Non_Oui();
            this.ViewBag.donnee.HTML_Oui_Non = GBClass.HTML_Oui_Non();
        }

        // -- Retourner le fichier de la langue à affecter aux tables de données -- //
        public object Langue_DataTable()
        {
            try
            {
                return
                    JsonConvert.DeserializeObject(
                        System.IO.File.ReadAllText(url_plugins + "datatables/" + ((LangHelper.CurrentCulture == 0) ? "English.json"
                                                                                                                   : "French.json"))
                    );
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);

                return null;
            }
        }

        // -- Vérifier l'autorisation sur une action -- //
        public void Verifier_Autorisation(GB_Enum_Action_Controller action)
        {
            // -- Vérifier l'autorisation de l'action -- //
            AutorisationDAO.Verification(this.id_menu_actif, this.con.id_role, action);
        }

        // -- Gestion des erreur 500 survenu dans l'application -- //
        protected override void OnException(ExceptionContext context)
        {
            // -- Activation de l'etat d'exception -- //
            context.ExceptionHandled = true;

            // -- Réccupération du controller et action de l'erreur -- //
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            // -- Log -- //
            GBClass.Log.Error(context.Exception);

            // -- Redirection vers la page d'erreur approprié -- //
            context.Result = RedirectToAction(
                                // -- Action -- //
                                "Page",
                                // -- Controlleur -- //
                                "Erreur",
                                // -- Paramètres -- //
                                new
                                {
                                    dt = GB.Models.Cryptage.Program.EncryptStringAES(
                                                GBConvert.To_JavaScript(
                                                    new
                                                    {
                                                        code = 500,
                                                        message = context.Exception.Message,
                                                        id_lang = this.id_lang,
                                                        reconnecter = GBClass.Reconnecter_erreur_action(controller, action)
                                                    }
                                                )
                                            )
                                }
                            );
        }
        #endregion

        #region [HttpPost]
        [HttpPost]
        public virtual ActionResult Charger_Table(string id_page, string id_vue) { return null; }

        [HttpPost]
        public ActionResult Charger_ConnectionId_Client(string connectionId)
        {
            try
            {
                // -- Mise à jour du connectionId dans l'objt session -- //
                this.con.Charger_ConnectionId_Hub(connectionId);

                // -- Notification -- //
                this.ViewBag.notification = new GBNotification(false);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(true);
                }
                else
                {
                    // -- Notificication -- //
                    this.ViewBag.notification = new GBNotification(ex.Message, true);
                }
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GBConvert.To_Object(this.ViewBag)
            );
        }
        #endregion
    }
}