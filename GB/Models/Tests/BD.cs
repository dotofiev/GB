﻿using GB.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Tests
{
    public class BD
    {
        public List<Module> modules { get; set; }
        public List<Role> roles { get; set; }
        public List<Menu> menus { get; set; }
        public List<Autorisation> autorisations { get; set; }
        public List<Utilisateur> utilisateurs { get; set; }
        public List<GroupeMenu> groupe_menus { get; set; }

        public BD() { }
    }
}