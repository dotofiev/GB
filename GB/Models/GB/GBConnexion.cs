using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.GB
{
    public class GBConnexion
    {
        // -- Privé -- //
        private Devise _devise { get; set; }
        private DateTime _date_connexion { get; set; }
        private DateTime _date_serveur { get; set; }
        private Utilisateur _utilisateur { get; set; }
        private string _url_photo_profil { get; set; }
        private string _nom_ordinateur { get; set; }
        private dynamic _donnee { get; set; }
        private string _session_id { get; set; }
        private string _id_navigateur_client { get; set; }
        private string _hub_id_context { get; set; }
        private GB_Enum_Code_Langue _langue { get; set; }

        // -- Public -- //
        public string url_photo_profil { get { return _url_photo_profil; } }
        public string nom_ordinateur { get { return _nom_ordinateur; } }
        public string session_id { get { return _session_id; } }
        public string id_navigateur_client { get { return _id_navigateur_client; } }
        public DateTime date_connexion { get { return _date_connexion; } }
        public DateTime date_serveur { get { return _date_serveur; } }
        public Devise devise { get { return _devise; } }
        public Utilisateur utilisateur { get { return _utilisateur; } }
        public string hub_id_context { get { return _hub_id_context; } }
        public dynamic donnee { get { return _donnee; } }
        public GB_Enum_Code_Langue langue { get { return _langue; } }

        // -- Constructeur -- //
        public GBConnexion(string session_id, string id_navigateur_client)
        {
            this._utilisateur = new Utilisateur();
            this._date_connexion = DateTime.Now;
            this._date_serveur = DateTime.Now;
            this._session_id = session_id;
            this._id_navigateur_client = id_navigateur_client;
            this._donnee = new System.Dynamic.ExpandoObject();
        }

        #region Méthodes
        public void Authentification(Utilisateur utilisateur, string id_lang)
        {
            #region Réccupération de l'utilisateur
            this._utilisateur = utilisateur;
            #endregion

            #region Réccupération de la date de connexion
            this._date_connexion = DateTime.Now;
            #endregion

            #region Réccupération de l'url du serveur
            this._url_photo_profil = "~/Resources/images/png/Utilisateur.png";
            #endregion

            #region Récupération de la dévise courante
            this._devise = new DeviseDAO().Actif();
            #endregion

            #region Réccupération de la langue en session
            _langue = (id_lang == "0") ? GB_Enum_Code_Langue.en
                                       : GB_Enum_Code_Langue.fr;
            #endregion

            #region Réccupération de la date serveur
            this._date_serveur = DateTime.Now;
            #endregion
        }

        public void Deconnexion()
        {
            this._utilisateur = new Utilisateur();
        }

        public void Vider_Donnee()
        {
            this._donnee = new System.Dynamic.ExpandoObject();
        }

        public void Charger_ConnectionId_Hub(string context_id)
        {
            this._hub_id_context = context_id;
        }
        #endregion
    }
}