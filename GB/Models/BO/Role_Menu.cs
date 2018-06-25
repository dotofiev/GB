using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Role_Menu
    {
        public Role role { get; set; }
        public Menu menu { get; set; }

        public Role_Menu(long id_role, long id_menu, string route)
        {
            this.role = new Role(id_role);
            this.menu = new Menu(id_menu, route);
        }

        public Role_Menu()
        {
            this.role = new Role();
            this.menu = new Menu();
        }
    }
}