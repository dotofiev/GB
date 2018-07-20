using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class ClassificationProvisionsPret : GBBO
    {
        public int nombre_jour_debut { get; set; }
        public int nombre_jour_fin { get; set; }
        public int pourcentage { get; set; }
        public string formule { get; set; }
        public string type { get; set; }

        public ClassificationProvisionsPret(long id)
        {
            this.id = id;
        }

        public ClassificationProvisionsPret() { }

        public override void Crer_Id()
        {
            this.id = Program.db.classification_provisions_pret.Count + 1;
        }
    }
}