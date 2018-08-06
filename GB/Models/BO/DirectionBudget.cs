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
    public class DirectionBudget : BO
    {
        public string chef { get; set; }
        public string telephone { get; set; }
        public string remarque { get; set; }
        public long id_exercice_fiscal { get; set; }
        public ExerciceFiscal exercice_fiscal { get; set; }

        public DirectionBudget(long id)
        {
            this.id = id;
        }

        public DirectionBudget() { }

        public override void Crer_Id()
        {
            this.id = Program.db.direction_dudget.Count + 1;
        }

        public static List<string> Classes_references
        {
            get
            {
                return
                    new List<string>() {
                        typeof(ExerciceFiscal).Name,
                    };
            }
        }
    }
}