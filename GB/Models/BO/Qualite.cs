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
    public class QUALITE : BO, IBO<Qualite>
    {
        public int series { get; set; }

        public QUALITE(string id)
        {
            this.id = id;
        }

        public QUALITE(Qualite entitie)
        {
            try
            {
                this.id = entitie.Qualite1;
                this.code = entitie.Qualite1;
                this.libelle_fr = entitie.LibQualite;
                this.libelle_en = entitie.LibQualiteEn;
                this.series = entitie.Series;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public QUALITE() { }

        public void Crer_Id()
        {
            this.id = (Program.db.qualites.Count + 1).ToString();
        }

        public Qualite ToEntities(Dictionary<string, object> parametres = null)
        {
            return new Qualite
            {
                LibQualite = this.libelle_fr,
                LibQualiteEn = this.libelle_en,
                Qualite1 = this.code,
                Series = this.series
            };
        }

        public void FromEntities(Qualite entitie)
        {
            this.id = entitie.Qualite1;
            this.code = entitie.Qualite1;
            this.libelle_fr = entitie.LibQualite;
            this.libelle_en = entitie.LibQualiteEn;
            this.series = entitie.Series;
        }

        public void ModifyEntities(Qualite entitie)
        {
            entitie.Qualite1 = this.code;
            entitie.LibQualite = this.libelle_fr;
            entitie.LibQualiteEn = this.libelle_en;
            entitie.Series = this.series;
        }
    }
}