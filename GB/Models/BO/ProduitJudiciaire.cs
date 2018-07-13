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
    public class ProduitJudiciaire : GBBO
    {
        public long date_creation { get; set; }

        public ProduitJudiciaire(long id)
        {
            this.id = id;
        }

        public ProduitJudiciaire() { }

        public override void Crer_Id()
        {
            this.id = Program.db.produits_judiciare.Count + 1;
        }
    }
}