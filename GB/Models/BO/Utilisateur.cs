using GB.Models.DAO;
using GB.Models.Entites;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Utilisateur : BO, IBO<Employe>
    {
        public string id_utilisateur { get; set; }
        public string id_role { get; set; }
        public string id_agence { get; set; }
        public string id_profession { get; set; }
        public string id_pouvoir { get; set; }
        public string id_qualite { get; set; }
        public string id_autorite_signature { get; set; }
        /// <summary>
        /// Equivalent du matricule en base
        /// </summary>
        public string compte { get; set; }
        public string mot_de_passe { get; set; }
        public string nom_utilisateur { get; set; }
        public bool ouverture_back_date { get; set; }
        public bool ouverture_branch { get; set; }
        public bool ouverture_back_date_travail { get; set; }
        public int duree_mot_de_passe { get; set; }
        public bool est_connecte { get; set; }
        public bool acces_historique_compte { get; set; }
        public bool est_suspendu { get; set; }
        public bool modifier_mot_de_passe { get; set; }
        public long date_mise_a_jour_mot_de_passe { get; set; }
        public Agence agence { get; set; }
        public Profession profession { get; set; }
        public AutoriteSignature autorite_signature { get; set; }
        public QUALITE qualite { get; set; }
        public int niveau_securite { get; set; }
        public long date_creation { get; set; }
        public long date_suspension { get; set; }
        public long date_serveur { get; set; }
        public long date_transfert { get; set; }
        public long date_compta { get; set; }
        public string employe { get; set; }
        public string nom_employe { get; set; }
        public string nom_ordinateur { get; set; }
        public double limit_maximum { get; set; }
        public string ordinateur_allouer { get; set; }
        public string type_session { get; set; }
        public bool est_accessible_employe { get; set; }

        public Utilisateur() { }

        public Utilisateur(Employe entitie, bool ajouter_reference = true)
        {
            try
            {
                this.id_utilisateur = entitie.Matricule;
                this.code = entitie.Matricule;
                this.id_agence = entitie.Agence;
                this.agence = (ajouter_reference) ? new AgenceDAO().ObjectCode(entitie.Agence)
                                                  : null;
                this.nom_utilisateur = entitie.NomEmploye;
                this.id_qualite = entitie.Qualite;
                this.qualite = (ajouter_reference) ? new QUALITEDAO().ObjectCode(this.id_qualite)
                                                   : null;
                this.niveau_securite = entitie.SecurityLevel ?? 0;
                this.mot_de_passe = entitie.MotPasse;
                this.date_creation = entitie.DateCreation?.Ticks ?? 0;
                this.date_mise_a_jour_mot_de_passe = entitie.DateAttMP?.Ticks ?? 0;
                this.est_suspendu = entitie.Suspension;
                this.duree_mot_de_passe = entitie.DureeMP?? 0;
                this.employe = entitie.Employe1;
                this.nom_employe = entitie.NomEmploye;
                this.limit_maximum = entitie.MaximumLimit?? 0;
                this.est_connecte = entitie.Status == "On";
                this.date_suspension = entitie.DateSuspension?.Ticks ?? 0;
                this.date_serveur = entitie.ServerDate?.Ticks ?? 0;
                this.nom_ordinateur = entitie.ComputerName;
                this.date_transfert = entitie.Datetransfert?.Ticks ?? 0;
                this.date_compta = entitie.DATECOMPTA?.Ticks ?? 0;
                this.ordinateur_allouer = entitie.AllocateComputer;
                this.est_accessible_employe = entitie.EmpAccess == "Yes";
                this.type_session = entitie.sessiontype;
                this.ouverture_branch = entitie.OpenBranch == "Yes";
                this.ouverture_back_date = entitie.BackDAte == "Yes";
                this.ouverture_back_date_travail = entitie.BackDAteWk == "Yes";
                this.id_autorite_signature = entitie.Auth;
                this.autorite_signature = (ajouter_reference) ? new AutoriteSignatureDAO().ObjectCode(this.id_autorite_signature)
                                                              : null;
                this.id_role = "1";
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id_utilisateur = (Program.db.utilisateurs.Count + 1).ToString();
        }

        public Employe ToEntities(Dictionary<string, object> parametres = null)
        {
            return new Employe
            {
                Agence = this.id_agence,
                AllocateComputer = this.ordinateur_allouer,
                Auth = this.id_autorite_signature,
                BackDAte = this.ouverture_back_date ? "Yes" 
                                                    : "No",
                BackDAteWk = this.ouverture_back_date_travail ? "Yes"
                                                              : "No",
                ComputerName = this.nom_ordinateur,
                DateAttMP = GBConvert.To_DateTime(this.date_mise_a_jour_mot_de_passe),
                DATECOMPTA = GBConvert.To_DateTime(this.date_compta),
                DateCreation = GBConvert.To_DateTime(this.date_creation),
                DateSuspension = GBConvert.To_DateTime(this.date_suspension),
                Datetransfert = GBConvert.To_DateTime(this.date_transfert),
                DureeMP = (short)this.duree_mot_de_passe,
                EmpAccess = this.est_accessible_employe ? "Yes"
                                                        : "No",
                Employe1 = this.employe,
                LibQualite = this.qualite.libelle,
                Matricule = this.code,
                MaximumLimit = this.limit_maximum,
                MotPasse = this.mot_de_passe,
                NomEmploye = this.nom_employe,
                NomPrenom = this.nom_utilisateur,
                OpenBranch = this.ouverture_branch ? "Yes"
                                                   : "No",
                Qualite = this.id_qualite,
                SecurityLevel = (short)this.niveau_securite,
                ServerDate = GBConvert.To_DateTime(this.date_serveur),
                sessiontype = this.type_session,
                Status = this.est_connecte ? "On"
                                           : "Off",
            };
        }

        public void FromEntities(Employe entitie)
        {
            try
            {
                this.id_utilisateur = entitie.Matricule;
                this.code = entitie.Matricule;
                this.id_agence = entitie.Agence;
                this.agence = new AgenceDAO().ObjectCode(entitie.Agence);
                this.nom_utilisateur = entitie.NomEmploye;
                this.id_qualite = entitie.Qualite;
                this.qualite = new QUALITEDAO().ObjectCode(this.id_qualite);
                this.niveau_securite = entitie.SecurityLevel ?? 0;
                this.mot_de_passe = entitie.MotPasse;
                this.date_creation = entitie.DateCreation?.Ticks ?? 0;
                this.date_mise_a_jour_mot_de_passe = entitie.DateAttMP?.Ticks ?? 0;
                this.est_suspendu = entitie.Suspension;
                this.duree_mot_de_passe = entitie.DureeMP ?? 0;
                this.employe = entitie.Employe1;
                this.nom_employe = entitie.NomEmploye;
                this.limit_maximum = entitie.MaximumLimit ?? 0;
                this.est_connecte = entitie.Status == "On";
                this.date_suspension = entitie.DateSuspension?.Ticks ?? 0;
                this.date_serveur = entitie.ServerDate?.Ticks ?? 0;
                this.nom_ordinateur = entitie.ComputerName;
                this.date_transfert = entitie.Datetransfert?.Ticks ?? 0;
                this.date_compta = entitie.DATECOMPTA?.Ticks ?? 0;
                this.ordinateur_allouer = entitie.AllocateComputer;
                this.est_accessible_employe = entitie.EmpAccess == "Yes";
                this.type_session = entitie.sessiontype;
                this.ouverture_branch = entitie.OpenBranch == "Yes";
                this.ouverture_back_date = entitie.BackDAte == "Yes";
                this.ouverture_back_date_travail = entitie.BackDAteWk == "Yes";
                this.id_autorite_signature = entitie.Auth;
                this.autorite_signature = new AutoriteSignatureDAO().ObjectCode(this.id_autorite_signature);
                this.id_role = "1";
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void ModifyEntities(Employe entitie)
        {
            entitie.Agence = this.id_agence;
            entitie.AllocateComputer = this.ordinateur_allouer;
            entitie.Auth = this.id_autorite_signature;
            entitie.BackDAte = this.ouverture_back_date ? "Yes"
                                                : "No";
            entitie.BackDAteWk = this.ouverture_back_date_travail ? "Yes"
                                                          : "No";
            entitie.ComputerName = this.nom_ordinateur;
            entitie.DateAttMP = GBConvert.To_DateTime(this.date_mise_a_jour_mot_de_passe);
            entitie.DATECOMPTA = GBConvert.To_DateTime(this.date_compta);
            entitie.DateCreation = GBConvert.To_DateTime(this.date_creation);
            entitie.DateSuspension = GBConvert.To_DateTime(this.date_suspension);
            entitie.Datetransfert = GBConvert.To_DateTime(this.date_transfert);
            entitie.DureeMP = (short)this.duree_mot_de_passe;
            entitie.EmpAccess = this.est_accessible_employe ? "Yes"
                                                    : "No";
            entitie.Employe1 = this.employe;
            entitie.LibQualite = this.qualite.libelle;
            entitie.Matricule = this.code;
            entitie.MaximumLimit = this.limit_maximum;
            entitie.MotPasse = this.mot_de_passe;
            entitie.NomEmploye = this.nom_employe;
            entitie.NomPrenom = this.nom_utilisateur;
            entitie.OpenBranch = this.ouverture_branch ? "Yes"
                                               : "No";
            entitie.Qualite = this.id_qualite;
            entitie.SecurityLevel = (short)this.niveau_securite;
            entitie.ServerDate = GBConvert.To_DateTime(this.date_serveur);
            entitie.sessiontype = this.type_session;
            entitie.Status = this.est_connecte ? "On"
                                       : "Off";
        }
    }
}