using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class DirectionBudget : BO, IBO<object>
    {
        public string chef { get; set; }
        public string telephone { get; set; }
        public string remarque { get; set; }
        public string id_exercice_fiscal { get; set; }
        public ExerciceFiscal exercice_fiscal { get; set; }

        public DirectionBudget(string id)
        {
            this.id = id;
        }

        public DirectionBudget() { }

        public void Crer_Id()
        {
            this.id = (Program.db.direction_dudget.Count + 1).ToString();
        }

        public object ToEntities(Dictionary<string, object> parametres = null)
        {
            throw new NotImplementedException();
        }

        public void FromEntities(object entitie)
        {
            throw new NotImplementedException();
        }

        public void ModifyEntities(object entitie)
        {
            throw new NotImplementedException();
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