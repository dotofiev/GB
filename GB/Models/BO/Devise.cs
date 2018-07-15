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
    public class Devise : GBBO
    {
        public string signe { get; set; }
        public bool devise_actuelle { get; set; }

        public Devise(long id)
        {
            this.id = id;
        }

        public Devise() { }

        public override void Crer_Id()
        {
            this.id = Program.db.devises.Count + 1;
        }
    }
}