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
    public class TypeGarantie : BO
    {
        public string nature { get; set; }
        public long date_creation { get; set; }
        public long id_utilisateur { get; set; }
        public Utilisateur utilisateur_createur { get; set; }
        
        public TypeGarantie(long id)
        {
            this.id = id;
        }

        public TypeGarantie() { }

        public override void Crer_Id()
        {
            this.id = Program.db.types_garantie.Count + 1;
        }
    }
}