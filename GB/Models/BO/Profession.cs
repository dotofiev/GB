using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Profession : BO
    {
        public Profession(long id)
        {
            this.id = id;
        }

        public Profession() { }

        public override void Crer_Id()
        {
            this.id = Tests.Program.db.agences.Count + 1;
        }
    }
}