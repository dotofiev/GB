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
    public class Profitabilite : BO
    {
        public string type { get; set; }

        public Profitabilite(long id)
        {
            this.id = id;
        }

        public Profitabilite() { }

        public override void Crer_Id()
        {
            this.id = Program.db.profitabilites.Count + 1;
        }
    }
}