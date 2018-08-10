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
    public class Banque : BO
    {
        public string adresse_1 { get; set; }
        public string adresse_2 { get; set; }
        public string ville { get; set; }
        public long id_pays { get; set; }
        public Pays pays { get; set; }

        public Banque(long id)
        {
            this.id = id;
        }

        public Banque() { }

        public override void Crer_Id()
        {
            this.id = Program.db.banques.Count + 1;
        }
    }
}