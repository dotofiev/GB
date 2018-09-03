using GB.Models.BO;
using GB.Models.Interfaces;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Role : BOClass, IBO<object>
    {
        public List<Autorisation> role_menus { get; set; }

        public Role(string id)
        {
            this.id = id;
            this.role_menus = new List<Autorisation>();
        }

        public Role()
        {
            this.role_menus = new List<Autorisation>();
        }

        public void Crer_Id()
        {
            this.id = (Tests.Program.db.roles.Count + 1).ToString();
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
    }
}