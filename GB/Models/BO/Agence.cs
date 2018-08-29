using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Entites;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Agence : BO, IBO<agence>
    {
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string bp { get; set; }
        public string telephone { get; set; }
        public string pays { get; set; }
        public string fax { get; set; }
        public string cobac_id { get; set; }
        public string beac_id { get; set; }
        public string ip { get; set; }
        public string mot_de_passe { get; set; }
        public string serveur_est_ouvert { get; set; }
        public string back_date_est_ouvert { get; set; }
        public long date_creation { get; set; }
        public long date_ats { get; set; }
        public long date_serveur { get; set; }
        public long back_date_serveur { get; set; }

        public Agence(string id)
        {
            this.id = id;
        }

        public Agence() { }

        public Agence(agence entitie)
        {
            try
            { 
                this.id = entitie.agcod;
                this.code = entitie.agcod;
                this.libelle = entitie.aglib;
                this.adresse = entitie.agadr;
                this.bp = entitie.agbp;
                this.ville = entitie.agville;
                this.pays = entitie.agpays;
                this.telephone = entitie.agtelp;
                this.fax = entitie.agfax;
                this.date_creation = entitie.agdcr?.Ticks ?? 0;
                this.date_ats = entitie.agdats?.Ticks ?? 0;
                this.cobac_id = entitie.CobacID;
                this.beac_id = entitie.BeacId;
                // -- ? cptecltres -- //
                //this. = entitie.cptecltres;
                this.id_utilisateur = entitie.Employe;
                //this.utilisateur = UtilisateurDAO.ObjectId(this.id_utilisateur);
                // -- ? BranchSituation -- //
                //this. = entitie.BranchSituation;
                // -- ? DateDerFerm -- //
                //this. = entitie.DateDerFerm;
                // -- ? DateJourEnCours -- //
                //this. = entitie.DateJourEnCours;
                // -- ? Sauvegarde -- //
                //this. = entitie.Sauvegarde;
                // -- ? ControlBranchAcct -- //
                //this. = entitie.ControlBranchAcct;
                // -- ? cptecltresint -- //
                //this. = entitie.cptecltresint;
                // -- ? TransfPhone -- //
                //this. = entitie.TransfPhone;
                this.date_serveur = entitie.ServerDate?.Ticks ?? 0;
                this.serveur_est_ouvert = entitie.ServerOpen;
                this.back_date_serveur = entitie.ServerBackDate?.Ticks ?? 0;
                this.back_date_est_ouvert = entitie.BackOpen;
                this.ip = entitie.Ipserver;
                this.mot_de_passe = entitie.Mdpserver;
            }
            catch(Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.agences.Count + 1).ToString();
        }

        public agence ToEntities(Dictionary<string, object> parametres = null)
        {
            return new agence
            {
                agcod = this.code,
                aglib = this.libelle,
                agadr = this.adresse,
                agbp = this.bp,
                agville = this.ville,
                agpays = this.pays,
                agtelp = this.telephone,
                agfax = this.fax,
                agdcr = new DateTime(this.date_creation),
                agdats = new DateTime(this.date_ats),
                CobacID = this.cobac_id,
                BeacId = this.beac_id,
                // -- ? cptecltres -- //
                //cptecltres,
                @Employe = this.id_utilisateur,
                // -- ? BranchSituation -- //
                //BranchSituation,
                // -- ? DateDerFerm -- //
                //DateDerFerm,
                // -- ? DateJourEnCours -- //
                //DateJourEnCours,
                // -- ? Sauvegarde -- //
                //Sauvegarde,
                // -- ? ControlBranchAcct -- //
                //ControlBranchAcct,
                // -- ? cptecltresint -- //
                //cptecltresint,
                // -- ? TransfPhone -- //
                //TransfPhone,
                ServerDate = new DateTime(this.date_serveur),
                ServerOpen = this.serveur_est_ouvert,
                ServerBackDate = new DateTime(this.back_date_serveur),
                BackOpen = this.back_date_est_ouvert,
                Ipserver = this.ip,
                Mdpserver = this.mot_de_passe
            };
        }

        public void FromEntities(agence entitie)
        {
            try
            {
                this.id = entitie.agcod;
                this.code = entitie.agcod;
                this.libelle = entitie.aglib;
                this.adresse = entitie.agadr;
                this.bp = entitie.agbp;
                this.ville = entitie.agville;
                this.pays = entitie.agpays;
                this.telephone = entitie.agtelp;
                this.fax = entitie.agfax;
                this.date_creation = entitie.agdcr?.Ticks ?? 0;
                this.date_ats = entitie.agdats?.Ticks ?? 0;
                this.cobac_id = entitie.CobacID;
                this.beac_id = entitie.BeacId;
                // -- ? cptecltres -- //
                //this. = entitie.cptecltres;
                this.id_utilisateur = entitie.Employe;
                this.utilisateur = UtilisateurDAO.ObjectId(this.id_utilisateur);
                // -- ? BranchSituation -- //
                //this. = entitie.BranchSituation;
                // -- ? DateDerFerm -- //
                //this. = entitie.DateDerFerm;
                // -- ? DateJourEnCours -- //
                //this. = entitie.DateJourEnCours;
                // -- ? Sauvegarde -- //
                //this. = entitie.Sauvegarde;
                // -- ? ControlBranchAcct -- //
                //this. = entitie.ControlBranchAcct;
                // -- ? cptecltresint -- //
                //this. = entitie.cptecltresint;
                // -- ? TransfPhone -- //
                //this. = entitie.TransfPhone;
                this.date_serveur = entitie.ServerDate?.Ticks ?? 0;
                this.serveur_est_ouvert = entitie.ServerOpen;
                this.back_date_serveur = entitie.ServerBackDate?.Ticks ?? 0;
                this.back_date_est_ouvert = entitie.BackOpen;
                this.ip = entitie.Ipserver;
                this.mot_de_passe = entitie.Mdpserver;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void ModifyEntities(agence entitie)
        {
            entitie.agcod = this.code;
            entitie.aglib = this.libelle;
            entitie.agadr = this.adresse;
            entitie.agbp = this.bp;
            entitie.agville = this.ville;
            entitie.agpays = this.pays;
            entitie.agtelp = this.telephone;
            entitie.agfax = this.fax;
            entitie.agdcr = new DateTime(this.date_creation);
            entitie.agdats = new DateTime(this.date_ats);
            entitie.CobacID = this.cobac_id;
            entitie.BeacId = this.beac_id;
            // -- ? cptecltres -- //
            //entitie.cptecltres;
            entitie.Employe = this.id_utilisateur;
            // -- ? BranchSituation -- //
            //entitie.BranchSituation;
            // -- ? DateDerFerm -- //
            //entitie.DateDerFerm;
            // -- ? DateJourEnCours -- //
            //entitie.DateJourEnCours;
            // -- ? Sauvegarde -- //
            //Sauvegarde;
            // -- ? ControlBranchAcct -- //
            //entitie.ControlBranchAcct;
            // -- ? cptecltresint -- //
            //entitie.cptecltresint;
            // -- ? TransfPhone -- //
            //entitie.TransfPhone;
            entitie.ServerDate = new DateTime(this.date_serveur);
            entitie.ServerOpen = this.serveur_est_ouvert;
            entitie.ServerBackDate = new DateTime(this.back_date_serveur);
            entitie.BackOpen = this.back_date_est_ouvert;
            entitie.Ipserver = this.ip;
            entitie.Mdpserver = this.mot_de_passe;
        }

        public static List<string> Classes_references
        {
            get
            {
                return
                    new List<string>() {
                        typeof(Utilisateur).Name
                    };
            }
        }
    }
}