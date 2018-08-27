using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class ClassificationProvisionsPret : BO, IBO<object>
    {
        public int nombre_jour_debut { get; set; }
        public int nombre_jour_fin { get; set; }
        public int pourcentage { get; set; }
        public string formule { get; set; }
        public string type { get; set; }

        public ClassificationProvisionsPret(string id)
        {
            this.id = id;
        }

        public ClassificationProvisionsPret() { }

        public void Crer_Id()
        {
            this.id = (Program.db.classification_provisions_pret.Count + 1).ToString();
        }

        public object ToEntities()
        {
            throw new NotImplementedException();
        }

        public void FromEntities(object entitie)
        {
            throw new NotImplementedException();
        }

        public void ModifyEntities(object entitie)
        {
            throw new NotImplementedException();
        }
    }
}