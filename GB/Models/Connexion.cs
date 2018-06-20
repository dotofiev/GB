﻿using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models
{
    public class Connexion
    {
        // -- Privé -- //
        private DateTime _date_connexion { get; set; }
        private long _id_utilisateur { get; set; }
        private string _compte { get; set; }
        private string _mot_de_passe { get; set; }
        private string _url_photo_profil { get; set; }
        private string _nom_utilisateur { get; set; }
        private dynamic _donnee { get; set; }

        // -- Public -- //
        public string compte { get { return _compte; } }
        public string mot_de_passe { get { return _mot_de_passe; } }
        public string url_photo_profil { get { return _url_photo_profil; } }
        public string nom_utilisateur { get { return _nom_utilisateur; } }
        public string session_id { get; set; }
        public DateTime date_connexion { get { return _date_connexion; } }
        public long id_utilisateur { get { return _id_utilisateur; } }
        public dynamic donnee { get { return _donnee; } }

        // -- Constructeur -- //
        public Connexion(string session_id)
        {
            this._date_connexion = DateTime.Now;
            this.session_id = session_id;
            this._donnee = new System.Dynamic.ExpandoObject();
        }

        #region Méthodes
        public void Authentification(string compte, string mot_de_passe)
        {
            this._compte = compte;
            this._mot_de_passe = mot_de_passe;
            this._date_connexion = DateTime.Now;
            this._id_utilisateur = TestClass.id_utilisateur;
            this._nom_utilisateur = TestClass.nom_utilisateur;
            this._url_photo_profil = "~/Resources/images/png/Utilisateur.png";
        }

        public void Deconnexion()
        {
            this._compte = null;
            this._mot_de_passe = null;
            this._date_connexion = DateTime.Now;
            this._id_utilisateur = TestClass.id_utilisateur;
            this._nom_utilisateur = TestClass.nom_utilisateur;
            this._url_photo_profil = "~/Resources/images/png/Utilisateur.png";
        }
        #endregion
    }
}