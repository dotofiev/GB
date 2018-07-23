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
    public class LocalisationActif : GBBO
    {
        public long date_creation { get; set; }
        
        public LocalisationActif(long id)
        {
            this.id = id;
        }

        public LocalisationActif() { }

        public override void Crer_Id()
        {
            this.id = Program.db.localisations_actif.Count + 1;
        }
    }
}