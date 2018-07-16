using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.Tests;

namespace GB.Models.BO
{
    public class ExerciceFiscal : GBBO
    {
        public string statut { get; set; }
        public string budget_id { get; set; }
        public string date_debut { get; set; }
        public string date_fin { get; set; }

        public override void Crer_Id()
        {
            this.id = Program.db.exercices_fiscal.Count + 1;
        }
    }
}