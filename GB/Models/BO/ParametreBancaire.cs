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
    public class ParametreBancaire : GBBO
    {
        public long id_devise { get; set; }
        public Devise devise { get; set; }
        public double taux { get; set; }
        public int montant { get; set; }
        public int montant_minimal { get; set; }
        public int montant_maximal { get; set; }

        public ParametreBancaire(long id)
        {
            this.id = id;
        }

        public ParametreBancaire() { }

        public override void Crer_Id()
        {
            this.id = Program.db.parametre_bancaires.Count + 1;
        }
    }
}