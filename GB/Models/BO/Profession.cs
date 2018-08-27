using GB.Models.BO;
using GB.Models.Interfaces;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Profession : BO, IBO<object>
    {
        public Profession(string id)
        {
            this.id = id;
        }

        public Profession() { }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.agences.Count + 1).ToString();
        }

        public object ToEntities()
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
    }
}