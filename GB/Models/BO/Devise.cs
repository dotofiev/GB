using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.Entites;

namespace GB.Models.BO
{
    public class Devise : BO
    {
        public string signe { get; set; }
        public bool devise_actuelle { get; set; }

        public Devise(long id)
        {
            this.id = id;
        }

        public Devise() { }

        public override void Crer_Id()
        {
            this.id = Program.db.devises.Count + 1;
        }

        public devise ToEntities()
        {
            return new devise
            {
                CurrentCurrency = (this.devise_actuelle ? GB_Enum_Yes_No.Yes
                                                        : GB_Enum_Yes_No.No).ToString(),
                devcod = this.code,
                devdate = DateTime.Now,
                devlib = this.libelle,
                devsign = this.signe
            };
        }

        public void CopierInEntities(ref devise obj)
        {
            obj.CurrentCurrency = (this.devise_actuelle ? GB_Enum_Yes_No.Yes
                                                        : GB_Enum_Yes_No.No).ToString();
            obj.devcod = this.code;
            obj.devdate = DateTime.Now;
            obj.devlib = this.libelle;
            obj.devsign = this.signe;
        }
    }
}