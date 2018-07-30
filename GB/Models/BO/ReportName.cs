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
    public class ReportName : GBBO
    {
        public string periodicite { get; set; }


        public ReportName(long id)
        {
            this.id = id;
        }

        public ReportName() { }

        public override void Crer_Id()
        {
            this.id = Program.db.ReportName.Count + 1;
        }
    }
}