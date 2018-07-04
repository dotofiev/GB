using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.BO;
using GB.Models.Tests;
using GB.Models.Static;

namespace GB.Models.Tests
{
    public static class Program
    {
        public static BD db { get; set; }

        public static void Initialiser_BD(string url_base_de_donnees)
        {
            // -- Lire la base de données -- //
            db = GBConvert.JSON_To<BD>(System.IO.File.ReadAllText(url_base_de_donnees));
            // -- Mise à jour des references objet -- //
            // -- Groupe menu -- //
            db.groupe_menus.ForEach(l => { l.module = db.modules[0]; });
            // -- Menu -- //
            db.menus.ForEach(l => { l.groupe_menu = db.groupe_menus[(l.id < 4) ? 0 : 1]; });
            // -- Autorisation -- //
            db.autorisations.ForEach(l => {
                l.role = db.roles[0];
                l.menu = db.menus[Convert.ToInt32(l.id_menu - 1)];
            });
        }

        /*
        public static List<Role> roles = new List<Role>()
        {
            new Role(1)
            {
                code = "1", 
                libelle_en = "Admin",
                libelle_fr = "Administrateur",
                //role_menus = Program.role_menus.Where(l => l.role.id == 1).ToList(),
            },
        };
        */

        /*
        public static List<Module> modules = new List<Module>()
        {
            new Module(1)
            {
                code = "1",
                libelle_en = "Security group",
                libelle_fr = "Groupe sécurité",
                //groupe_menus = Program.db.db_groupe_menus
            },
        };
        */

        /*
        public static List<GroupeMenu> group_menus = new List<GroupeMenu>()
        {
            new GroupeMenu(1, "Securite")
            {
                code = "1",
                libelle_en = "Configure security objets",
                libelle_fr = "Configuration objets sécurité",
                module = Program.modules[0],
                icon = "fa fa-cogs",
                //menus = new List<Menu>(),
            },
            new GroupeMenu(2, "SecuriteUtilisateur")
            {
                code = "2",
                libelle_en = "Manage employee's security",
                libelle_fr = "Gestion de la sécurité des employés",
                module = Program.modules[0],
                icon = "fa fa-cogs",
                //menus = new List<Menu>(),
            },
        };
        */

        /*
        public static List<Menu> menus = new List<Menu>()
        {
            new Menu(1, "Module")
            {
                code = "1",
                libelle_en = "Manage GBK modules",
                libelle_fr = "Gestion des modules GB",
                groupe_menu = Program.db.db_groupe_menus[0],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 1).ToList(),
            },
            new Menu(2, "Menu")
            {
                code = "2",
                libelle_en = "Manage GBK menu",
                libelle_fr = "Gestion des menu GB",
                groupe_menu = Program.db.db_groupe_menus[0],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 2).ToList(),
            },
            new Menu(3, "Role")
            {
                code = "3",
                libelle_en = "Manage GBK roles",
                libelle_fr = "Gestion des roles GB",
                groupe_menu = Program.db.db_groupe_menus[0],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 3).ToList(),
            },
            new Menu(6, "...")
            {
                code = "6",
                libelle_en = "Menu 6",
                libelle_fr = "Menu 6",
                groupe_menu = Program.db.db_groupe_menus[1],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 1).ToList(),
            },
            new Menu(4, "...")
            {
                code = "4",
                libelle_en = "Menu 4",
                libelle_fr = "Menu 4",
                groupe_menu = Program.db.db_groupe_menus[1],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 2).ToList(),
            },
            new Menu(5, "...")
            {
                code = "5",
                libelle_en = "Menu 5",
                libelle_fr = "Menu 5",
                groupe_menu = Program.db.db_groupe_menus[1],
                //role_menus = Program.role_menus.Where(l => l.menu.id == 3).ToList(),
            },
        };
        */

        /*
         public static List<Autorisation> role_menus = new List<Autorisation>()
         {
             new Autorisation(1, 1, "Module")
             {
                 role = Program.roles[0],
                 menu = Program.menus[0],
             },
             new Autorisation(1, 2, "Menu")
             {
                 role = Program.roles[0],
                 menu = Program.menus[1],
             },
             new Autorisation(1, 3, "Role")
             {
                 role = Program.roles[0],
                 menu = Program.menus[2],
             },
             new Autorisation(1, 4, "...")
             {
                 role = Program.roles[0],
                 menu = Program.menus[3],
             },
             new Autorisation(1, 5, "...")
             {
                 role = Program.roles[0],
                 menu = Program.menus[4],
             },
             new Autorisation(1, 6, "...")
             {
                 role = Program.roles[0],
                 menu = Program.menus[5],
             },
         };
         */

        /*
        public static List<Module> db_modules = new List<Module>()
        {
            new Module(1)
            {
                code = "1",
                libelle_en = "Security group",
                libelle_fr = "Groupe sécurité",
            },
        };
        */

        /*
        public static List<Role> db_roles = new List<Role>()
        {
            new Role(1)
            {
                code = "1",
                libelle_en = "Admin",
                libelle_fr = "Administrateur",
            },
        };
        */

        /*
        public static List<Menu> db_menus = new List<Menu>()
        {
            new Menu(1, "Module")
            {
                code = "1",
                libelle_en = "Manage GBK modules",
                libelle_fr = "Gestion des modules GB",
                groupe_menu = Program.db.db_groupe_menus[0],
            },
            new Menu(2, "Menu")
            {
                code = "2",
                libelle_en = "Manage GBK menu",
                libelle_fr = "Gestion des menu GB",
                groupe_menu = Program.db.db_groupe_menus[0],
            },
            new Menu(3, "Role")
            {
                code = "3",
                libelle_en = "Manage GBK roles",
                libelle_fr = "Gestion des roles GB",
                groupe_menu = Program.db.db_groupe_menus[0],
            },
        };
        */
    }
}