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
    public class TypePret : BO
    {
        public int periode_debut { get; set; }
        public int periode_fin { get; set; }
        public string periodicite { get; set; }

        public TypePret(long id)
        {
            this.id = id;
        }

        public TypePret() { }

        public override void Crer_Id()
        {
            this.id = Program.db.types_pret.Count + 1;
        }
    }
}