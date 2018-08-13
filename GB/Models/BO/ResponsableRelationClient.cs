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
    public class ResponsableRelationClient : BO
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string nid { get; set; }
        public string garant { get; set; }
        public string garant_telephone { get; set; }
        public string champ_1 { get; set; }
        public string champ_2 { get; set; }

        public ResponsableRelationClient(long id)
        {
            this.id = id;
        }

        public ResponsableRelationClient() { }

        public override void Crer_Id()
        {
            this.id = Program.db.responsables_relation_client.Count + 1;
        }
    }
}