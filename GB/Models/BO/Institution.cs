using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Institution : BO, IBO<object>
    {
        public string motto { get; set; }
        public string pub { get; set; }
        public string cobac_id { get; set; }
        public string type { get; set; }
        public GBFichier logo { get; set; }

        public Institution(string id)
        {
            this.id = id;
            this.logo = new GBFichier();
        }

        public Institution()
        {
            this.logo = new GBFichier();
        }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.institutions.Count + 1).ToString();
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