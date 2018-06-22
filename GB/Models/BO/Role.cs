using GB.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Role : GBBO
    {
        public List<Role_Menu> role_menus { get; set; }

        public Role(long id)
        {
            this._id = id;
            this.role_menus = new List<Role_Menu>();
        }

        public Role()
        {
            this.role_menus = new List<Role_Menu>();
        }
    }
}