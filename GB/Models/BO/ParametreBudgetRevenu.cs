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
    public class ParametreBudgetRevenu : BO
    {
        public long id_compte { get; set; }
        public Compte compte { get; set; }
        public bool autoriser_control_budget { get; set; }

        public ParametreBudgetRevenu(long id)
        {
            this.id = id;
        }

        public ParametreBudgetRevenu() { }

        public override void Crer_Id()
        {
            this.id = Program.db.parametres_budget_revenus.Count + 1;
        }
    }
}