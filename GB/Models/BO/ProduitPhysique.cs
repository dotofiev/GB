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
    public class ProduitPhysique : GBBO
    {
        public string type { get; set; }

        public ProduitPhysique(long id)
        {
            this.id = id;
        }

        public ProduitPhysique() { }

        public override void Crer_Id()
        {
            this.id = Program.db.produits_physique.Count + 1;
        }
    }
}