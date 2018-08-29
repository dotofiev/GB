using GB.Models.BO;
using GB.Models.Entites;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class CAISSE : BO, IBO<Caisse>
    {
        public string id_compte { get; set; }
        public string id_devise { get; set; }
        public string id_utilisateur { get; set; }
        public string id_agence { get; set; }
        public double montant_depart { get; set; }
        public double debit_jour { get; set; }
        public double credit_jour { get; set; }
        public double solde { get; set; }
        public string statut { get; set; }
        public string type { get; set; }
        public long date_derniere_ouverture { get; set; }
        public long date_derniere_fermeture { get; set; }
        public long date_dernier_ajustement { get; set; }
        public long date_jour { get; set; }
        public Compte compte { get; set; }
        public Devise devise { get; set; }
        public Utilisateur utilisateur { get; set; }
        public Agence agence { get; set; }

        public CAISSE(string id)
        {
            this.id = id;
        }

        public CAISSE() { }

        public CAISSE(Caisse entitie)
        {
            try
            {
                this.id = entitie.CodeCaisse;
                this.id_agence = entitie.agence;
                this.code = entitie.CodeCaisse;
                this.id_compte = entitie.Compte;
                this.credit_jour = entitie.CreditJour ?? 0;
                this.date_jour = entitie.DateJour?.Ticks ?? 0;
                this.date_dernier_ajustement = entitie.Datelastadjust?.Ticks ?? 0;
                this.date_derniere_fermeture = entitie.Datelastclose?.Ticks ?? 0;
                this.date_derniere_ouverture = entitie.Datelastopen?.Ticks ?? 0;
                this.debit_jour = entitie.DebitJour ?? 0;
                this.id_devise = entitie.devise;
                this.id_utilisateur = entitie.Employe;
                this.libelle = entitie.Libelle;
                this.montant_depart = entitie.MontantDep ?? 0;
                this.solde = entitie.Solde ?? 0;
                this.statut = entitie.Tellerstatus;
                this.type = entitie.TellerType;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id = (Program.db.caisses.Count + 1).ToString();
        }

        public Caisse ToEntities(Dictionary<string, object> parametres = null)
        {
            return new Caisse
            {
                agence      = this.id_agence,
                CodeCaisse  = this.code,
                Compte      = this.id_compte,
                CreditJour  = this.credit_jour,
                DateJour    = new DateTime(this.date_jour),
                Datelastadjust = new DateTime(this.date_dernier_ajustement),
                Datelastclose = new DateTime(this.date_derniere_fermeture),
                Datelastopen = new DateTime(this.date_derniere_ouverture),
                DebitJour = this.debit_jour,
                devise = this.id_devise,
                Employe = this.id_utilisateur,
                Libelle = this.libelle,
                MontantDep = this.montant_depart,
                Solde = this.solde,
                Tellerstatus = this.statut,
                TellerType = this.type
            };
        }

        public void FromEntities(Caisse entitie)
        {
            this.id                         = entitie.CodeCaisse;
            this.id_agence                  = entitie.agence;
            this.code                       = entitie.CodeCaisse;
            this.id_compte                  = entitie.Compte;
            this.credit_jour                = entitie.CreditJour ?? 0;
            this.date_jour                  = entitie.DateJour?.Ticks ?? 0;
            this.date_dernier_ajustement    = entitie.Datelastadjust?.Ticks ?? 0;
            this.date_derniere_fermeture    = entitie.Datelastclose?.Ticks ?? 0;
            this.date_derniere_ouverture    = entitie.Datelastopen?.Ticks ?? 0;
            this.debit_jour                 = entitie.DebitJour?? 0;
            this.id_devise                  = entitie.devise;
            this.id_utilisateur             = entitie.Employe;
            this.libelle                    = entitie.Libelle;
            this.montant_depart             = entitie.MontantDep ?? 0;
            this.solde                      = entitie.Solde ?? 0;
            this.statut                     = entitie.Tellerstatus;
            this.type                       = entitie.TellerType;
        }

        public void ModifyEntities(Caisse entitie)
        {
            entitie.agence = this.id_agence;
            entitie.CodeCaisse = this.code;
            entitie.Compte = this.id_compte;
            entitie.CreditJour = this.credit_jour;
            entitie.DateJour = new DateTime(this.date_jour);
            entitie.Datelastadjust = new DateTime(this.date_dernier_ajustement);
            entitie.Datelastclose = new DateTime(this.date_derniere_fermeture);
            entitie.Datelastopen = new DateTime(this.date_derniere_ouverture);
            entitie.DebitJour = this.debit_jour;
            entitie.devise = this.id_devise;
            entitie.Employe = this.id_utilisateur;
            entitie.Libelle = this.libelle;
            entitie.MontantDep = this.montant_depart;
            entitie.Solde = this.solde;
            entitie.Tellerstatus = this.statut;
            entitie.TellerType = this.type;
        }
    }
}