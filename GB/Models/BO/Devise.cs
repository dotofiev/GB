using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.Entites;
using GB.Models.Interfaces;
using System.Data.Entity.Core.Objects;

namespace GB.Models.BO
{
    public class Devise : BO, IBO<devise>
    {
        public string signe { get; set; }
        public bool devise_actuelle { get; set; }
        public long date_creation { get; set; }

        public Devise(string id)
        {
            this.id = id;
        }

        public Devise() { }

        public Devise(devise entitie)
        {
            try
            {
                this.id = entitie.devcod;
                this.code = entitie.devcod;
                this.libelle = entitie.devlib;
                this.signe = entitie.devsign;
                this.devise_actuelle = entitie.CurrentCurrency == "Yes";
                this.date_creation = entitie.devdate?.Ticks ?? DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void Crer_Id()
        {
            this.id = (Program.db.devises.Count + 1).ToString();
        }

        public devise ToEntities(Dictionary<string, object> parametres = null)
        {
            return new devise
            {
                CurrentCurrency = (this.devise_actuelle ? GB_Enum_Yes_No.Yes
                                                        : GB_Enum_Yes_No.No).ToString(),
                devcod          = this.code,
                devdate         = parametres["date_creation"] as DateTime?,
                devlib          = this.libelle,
                devsign         = this.signe
            };
        }

        public void FromEntities(devise entitie)
        {
            this.id = entitie.devcod;
            this.code = entitie.devcod;
            this.libelle = entitie.devlib;
            this.signe = entitie.devsign;
            this.devise_actuelle = entitie.CurrentCurrency == "Yes";
            this.date_creation = entitie.devdate?.Ticks ?? DateTime.Now.Ticks;
        }

        public void ModifyEntities(devise entitie)
        {
            entitie.devcod = this.id;
            entitie.devcod = this.code;
            entitie.devlib = this.libelle;
            entitie.devsign = this.signe;
            entitie.CurrentCurrency = this.devise_actuelle ? "Yes" 
                                                           : "No";
            // -- Non autorisé -- //
            //entitie.devdate = new DateTime(this.date_creation);
        }
    }
}