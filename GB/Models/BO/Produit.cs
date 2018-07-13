﻿using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Produit : GBBO
    {
        public string type { get; set; }

        public Produit(long id)
        {
            this.id = id;
        }

        public Produit() { }

        public override void Crer_Id()
        {
            this.id = Program.db.produits.Count + 1;
        }
    }
}