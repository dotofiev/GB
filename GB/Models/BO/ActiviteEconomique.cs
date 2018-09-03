using GB.Models.BO;
using GB.Models.Entites;
using GB.Models.GB;
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
    public class ActiviteEconomique : BOClass, IBO<ActiviteEco>
    {
        public long date_creation { get; set; }
        public string id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }

        public ActiviteEconomique(string id)
        {
            this.id = id;
        }

        public ActiviteEconomique() { }

        public ActiviteEconomique(ActiviteEco entitie)
        {
            try
            {
                this.id = entitie.ActiviteEco1;
                this.code = entitie.ActiviteEco1;
                this.libelle_fr = entitie.Designation;
                this.libelle_en = entitie.DesignAnglais;
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
            this.id = (Program.db.activites_economique.Count + 1).ToString();
        }

        public ActiviteEco ToEntities(Dictionary<string, object> parametres = null)
        {
            return new ActiviteEco
            {
                ActiviteEco1 = this.code,
                DesignAnglais = this.libelle_en,
                Designation = this.libelle_fr,
                DateCreation = parametres["date_creation"] as DateTime?
            };
        }

        public void FromEntities(ActiviteEco entitie)
        {
            this.id = entitie.ActiviteEco1;
            this.code = entitie.ActiviteEco1;
            this.libelle_en = entitie.DesignAnglais;
            this.libelle_fr = entitie.Designation;
            this.date_creation = entitie.DateCreation?.Ticks ?? DateTime.Now.Ticks;
        }

        public void ModifyEntities(ActiviteEco entitie)
        {
            try
            {
                entitie.ActiviteEco1 = this.code;
                entitie.Designation = this.libelle_fr;
                entitie.DesignAnglais = this.libelle_en;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
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

        public override bool Equals(object obj)
        {
            return
                this.id == (obj as ActiviteEconomique).id &&
                this.code == (obj as ActiviteEconomique).id &&
                this.libelle_en == (obj as ActiviteEconomique).libelle_en &&
                this.libelle_fr == (obj as ActiviteEconomique).libelle_fr;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}