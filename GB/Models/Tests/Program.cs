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
            db.utilisateurs.ForEach(l => {
                l.agence = db.agences.FirstOrDefault(ll => ll.id == l.id_agence);
                l.profession = db.professions.FirstOrDefault(ll => ll.id == l.id_profession);
                l.autorite_signature = db.autorites_signature.FirstOrDefault(ll => ll.id == l.id_autorite_signature);
                l.date_mise_a_jour_mot_de_passe = DateTime.Now.AddMonths(1).Ticks;
            });
            // -- Groupe menu -- //
            db.groupe_menus.ForEach(l => {
                l.module = db.modules.FirstOrDefault(ll => ll.id == l.id_module);
            });
            // -- Menu -- //
            db.menus.ForEach(l => {
                l.groupe_menu = db.groupe_menus.FirstOrDefault(ll => ll.id == l.id_groupe_menu);
            });
            // -- Parent -- //
            db.menus.ForEach(l => {
                l.menu_parent = db.menus.FirstOrDefault(ll => ll.id == (l.id_menu_parent ?? 0));
            });
            // -- Enfant -- //
            db.menus.ForEach(l => {
                l.menus_enfant = db.menus.Where(ll => (ll.id_menu_parent?? 0) == l.id).ToList();
            });
            // -- Autorisation -- //
            db.autorisations.ForEach(l => {
                l.role = db.roles.FirstOrDefault(ll => ll.id == l.id_role);
                l.menu = db.menus.FirstOrDefault(ll => ll.id == l.id_menu);
            });
            // -- Parametre_bancaires -- //
            db.parametre_bancaires.ForEach(l => {
                l.devise = db.devises.FirstOrDefault(ll => ll.id == l.id_devise);
            });
            // -- Produit judiciaire -- //
            db.produits_judiciare.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Pays -- //
            db.pays.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Ville -- //
            db.villes.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Activité économique -- //
            db.activites_economique.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Titre -- //
            db.titres.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Unite Institutionnelle -- //
            db.unites_institutionnelle.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- BEAC Nationalités -- //
            db.nationalites_beac.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Direction budget -- //
            db.direction_dudget.ForEach(l =>
            {
                l.exercice_fiscal = db.exercices_fiscal.FirstOrDefault(ll => ll.id == l.id_exercice_fiscal);
            });
            // -- Congés bancaire -- //
            db.conges_banque.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
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