using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Agence : GBBO
    {
        public Agence(long id)
        {
            this.id = id;
        }

        public Agence() { }

        public override void Crer_Id()
        {
            this.id = Tests.Program.db.agences.Count + 1;
        }
    }
}