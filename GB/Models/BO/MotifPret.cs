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
    public class MotifPret : BO
    {
        public MotifPret(long id)
        {
            this.id = id;
        }

        public MotifPret() { }

        public override void Crer_Id()
        {
            this.id = Program.db.motifs_pret.Count + 1;
        }
    }
}