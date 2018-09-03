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
    public class PAYS : BOClass, IBO<Pay>
    {
        public string code_telephone { get; set; }
        public long date_creation { get; set; }
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        
        public PAYS(string id)
        {
            this.id = id;
        }

        public PAYS() { }

        public PAYS(Pay entitie)
        {
            try
            {
                this.id = entitie.Pays;
                this.code = entitie.Pays;
                this.libelle = entitie.Designation;
                this.code_telephone = entitie.PhoneId;
                this.date_creation = entitie.DateCreation?.Ticks ?? DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id = (Program.db.pays.Count + 1).ToString();
        }

        public Pay ToEntities(Dictionary<string, object> parametres = null)
        {
            return new Pay
            {
                Pays = this.code,
                DateCreation = parametres["date_creation"] as DateTime?,
                Designation = this.libelle,
                PhoneId = this.code_telephone
            };
        }

        public void FromEntities(Pay entitie)
        {
            this.id = entitie.Pays;
            this.code = entitie.Pays;
            this.libelle = entitie.Designation;
            this.code_telephone = entitie.PhoneId;
            this.date_creation = entitie.DateCreation?.Ticks ?? DateTime.Now.Ticks;
        }

        public void ModifyEntities(Pay entitie)
        {
            entitie.Pays = this.code;
            entitie.Designation = this.libelle;
            entitie.PhoneId = this.code_telephone;

            // -- Non autorisé -- //
            //entitie.DateCreation = new DateTime(this.date_creation);
        }
    }
}