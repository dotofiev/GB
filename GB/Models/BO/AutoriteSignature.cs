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
    public class AutoriteSignature : BOClass, IBO<tabSigningAuthority>
    {
        public double montant_signature { get; set; }
        public long limite_decouvert_client { get; set; }
        public long debit_max_client { get; set; }
        public long credit_max_client { get; set; }
        public long montant_max_ligne_credit { get; set; }
        public double montant_limite_pret { get; set; }
        public string statut { get; set; }
        public double CrAcctWithAuthAmnt { get; set; }
        public double DbAcctAuthMaxAmnt { get; set; }
        public double HighestCreditAmnt { get; set; }
        public double OverdraftAcctAuthLimit { get; set; }
        public double LOCMaxAmount { get; set; }
        public double LOCMaxAmnt { get; set; }
        
        public AutoriteSignature(string id)
        {
            this.id = id;
        }

        public AutoriteSignature() { }

        public AutoriteSignature(tabSigningAuthority entitie)
        {
            try
            {
                this.id = entitie.AuthorityID;
                this.code = entitie.AuthorityID;
                this.libelle = entitie.libAuthority;
                this.montant_signature = entitie.SigningAmount ?? 0;
                this.statut = entitie.Status;
                this.CrAcctWithAuthAmnt = entitie.CrAcctWithAuthAmnt ?? 0;
                this.DbAcctAuthMaxAmnt = entitie.DbAcctAuthMaxAmnt ?? 0;
                this.HighestCreditAmnt = entitie.HighestCreditAmnt ?? 0;
                this.OverdraftAcctAuthLimit = entitie.OverdraftAcctAuthLimit ?? 0;
                this.LOCMaxAmount = entitie.LOCMaxAmount ?? 0;
                this.LOCMaxAmnt = entitie.LOCMaxAmnt ?? 0;
                this.montant_limite_pret = entitie.MaxLending ?? 0;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id = (Program.db.autorites_signature.Count + 1).ToString();
        }

        public tabSigningAuthority ToEntities(Dictionary<string, object> parametres = null)
        {
            return new tabSigningAuthority
            {
                AuthorityID = this.id,
                CrAcctWithAuthAmnt = this.CrAcctWithAuthAmnt,
                DbAcctAuthMaxAmnt = this.DbAcctAuthMaxAmnt,
                HighestCreditAmnt = this.HighestCreditAmnt,
                libAuthority = this.libelle,
                LOCMaxAmnt = this.LOCMaxAmnt,
                LOCMaxAmount = this.LOCMaxAmount,
                MaxLending = this.montant_limite_pret,
                OverdraftAcctAuthLimit = this.OverdraftAcctAuthLimit,
                SigningAmount = this.montant_signature,
                Status = this.statut
            };
        }

        public void FromEntities(tabSigningAuthority entitie)
        {
            try
            {
                this.id = entitie.AuthorityID;
                this.code = entitie.AuthorityID;
                this.libelle = entitie.libAuthority;
                this.montant_signature = entitie.SigningAmount ?? 0;
                this.statut = entitie.Status;
                this.CrAcctWithAuthAmnt = entitie.CrAcctWithAuthAmnt ?? 0;
                this.DbAcctAuthMaxAmnt = entitie.DbAcctAuthMaxAmnt ?? 0;
                this.HighestCreditAmnt = entitie.HighestCreditAmnt ?? 0;
                this.OverdraftAcctAuthLimit = entitie.OverdraftAcctAuthLimit ?? 0;
                this.LOCMaxAmount = entitie.LOCMaxAmount ?? 0;
                this.LOCMaxAmnt = entitie.LOCMaxAmnt ?? 0;
                this.montant_limite_pret = entitie.MaxLending ?? 0;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void ModifyEntities(tabSigningAuthority entitie)
        {
            entitie.AuthorityID = this.id;
            entitie.CrAcctWithAuthAmnt = this.CrAcctWithAuthAmnt;
            entitie.DbAcctAuthMaxAmnt = this.DbAcctAuthMaxAmnt;
            entitie.HighestCreditAmnt = this.HighestCreditAmnt;
            entitie.libAuthority = this.libelle;
            entitie.LOCMaxAmnt = this.LOCMaxAmnt;
            entitie.LOCMaxAmount = this.LOCMaxAmount;
            entitie.MaxLending = this.montant_limite_pret;
            entitie.OverdraftAcctAuthLimit = this.OverdraftAcctAuthLimit;
            entitie.SigningAmount = this.montant_signature;
            entitie.Status = this.statut;
        }
    }
}