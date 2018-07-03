using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Role : GBBO
    {
        public List<Autorisation> role_menus { get; set; }

        public Role(long id)
        {
            this.id = id;
            this.role_menus = new List<Autorisation>();
        }

        public Role()
        {
            this.role_menus = new List<Autorisation>();
        }

        public override void Crer_Id()
        {
            this.id = Program.db.roles.Count + 1;
        }
    }
}