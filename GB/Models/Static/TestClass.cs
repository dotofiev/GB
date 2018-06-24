using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.BO;

namespace GB.Models.Static
{
    public static class TestClass
    {
        public static long id_utilisateur = 99999;
        public static string compte = "admin";
        public static string mot_de_passe = "admin";
        public static string nom_utilisateur = "Administrateur";
        public static List<Role> roles = new List<Role>()
        {
            new Role(1)
            {
                code = "1",
                libelle_en = "Admin",
                libelle_fr = "Administrateur",
                //role_menus = TestClass.role_menus.Where(l => l.role.id == 1).ToList(),
            },
        };
        public static List<Module> modules = new List<Module>()
        {
            new Module(1)
            {
                code = "1",
                libelle_en = "Security group",
                libelle_fr = "Groupe sécurité",
                //groupe_menus = TestClass.group_menus
            },
        };
        public static List<GroupeMenu> group_menus = new List<GroupeMenu>()
        {
            new GroupeMenu(1)
            {
                code = "1",
                libelle_en = "Configure security objets",
                libelle_fr = "Configuration objets sécurité",
                module = TestClass.modules[0],
                icon = "fa fa-cogs",
                //menus = new List<Menu>(),
            },
        };
        public static List<Menu> menus = new List<Menu>()
        {
            new Menu(1, "/Securite/Module")
            {
                code = "1",
                libelle_en = "Manage GBK modules",
                libelle_fr = "Gestion des modules GB",
                groupe_menu = TestClass.group_menus[0],
                //role_menus = TestClass.role_menus.Where(l => l.menu.id == 1).ToList(),
            },
            new Menu(2, "/Securite/Menu")
            {
                code = "2",
                libelle_en = "Manage GBK menu",
                libelle_fr = "Gestion des menu GB",
                groupe_menu = TestClass.group_menus[0],
                //role_menus = TestClass.role_menus.Where(l => l.menu.id == 2).ToList(),
            },
            new Menu(3, "/Securite/Role")
            {
                code = "3",
                libelle_en = "Manage GBK roles",
                libelle_fr = "Gestion des roles GB",
                groupe_menu = TestClass.group_menus[0],
                //role_menus = TestClass.role_menus.Where(l => l.menu.id == 3).ToList(),
            },
        };
        public static List<Role_Menu> role_menus = new List<Role_Menu>()
        {
            new Role_Menu(1, 1, "/Securite/Module")
            {
                role = TestClass.roles[0],
                menu = TestClass.menus[0],
            },
            new Role_Menu(1, 2, "/Securite/Menu")
            {
                role = TestClass.roles[0],
                menu = TestClass.menus[1],
            },
            new Role_Menu(1, 3, "/Securite/Role")
            {
                role = TestClass.roles[0],
                menu = TestClass.menus[2],
            },
        };
        public static List<Module> db_modules = new List<Module>()
        {
            new Module(1)
            {
                code = "1",
                libelle_en = "Security group",
                libelle_fr = "Groupe sécurité",
            },
        };
    }
}