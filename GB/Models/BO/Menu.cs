﻿using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Menu : GBBO
    {
        // -- Privé -- //
        private GroupeMenu _groupe_menu { get; set; }

        // -- Public -- //
        public GroupeMenu groupe_menu {
            get { return _groupe_menu; }
            set {
                this._groupe_menu = value;
                // -- Mise à jour de l'identifiant du controlleur -- //
                this.id_controller = value?.id ?? 0;
            }
        }
        public List<Autorisation> autorisations { get; set; }
        public string view { get; set; }
        public long id_controller { get; set; }
        public long id_groupe_menu { get; set; }

        public Menu(long id, string view)
        {
            this.id = id;
            this.groupe_menu = new GroupeMenu();
            this.autorisations = new List<Autorisation>();
            this.view = view;
        }

        public Menu()
        {
            this.groupe_menu = new GroupeMenu();
            this.autorisations = new List<Autorisation>();
        }

        public string HTML()
        {
            return
                @"<li>
                    <a href=""javascript:;"" class=""menu-gb"" id=""{id}"" name=""{route}"" title=""{libelle}"">{libelle}</a>
                </li>"
                .Replace("{id}", this.id + "-" + this.groupe_menu.id)
                .Replace("{route}", $"/{this.groupe_menu.controller}/{this.view}")
                .Replace("{libelle}", LangHelper.CurrentCulture == 0 ? this.libelle_en
                                                                     : this.libelle_fr);
        }

        //public static string Source(List<Autorisation> role_menus)
        //{
        //    string menus = "";

        //    for (int i = 1; i <= 3; i++)
        //    {
        //        menus +=
        //        @"<div class=""menu_section"">
                    
        //            <h3>{groupe_menu}</h3>
                    
        //            <ul class=""nav side-menu"">".Replace("{groupe_menu}", "Groupe menu " + i);

        //        for (int ii = 1; ii <= 3; ii++)
        //        {
        //            menus +=
        //            @"<li>
        //                        <a>
        //                            <i class=""fa fa-square""></i> {menu} <span class=""fa fa-chevron-down""></span>
        //                        </a>
        //                        <ul class=""nav child_menu"">".Replace("{menu}", "Menu " + ii);

        //            for (int iii = 1; iii <= 3; iii++)
        //            {
        //                menus += $"<li><a href=\"#\" class=\"menu-gb\" id=\"{i + "-" + ii + "-" + iii}\" name=\"{"/" + i + "/" + ii + "/" + iii}\">{"Sous menu " + iii}</a></li>";
        //            }

        //            menus +=
        //                @"</ul>
        //                    </li>";
        //        }

        //        menus +=
        //    @"</ul>
        //        </div>";
        //    }

        //    return menus;
        //}

        public static string Source(List<Autorisation> role_menus)
        {
            string HTML = string.Empty;
            List<Module> modules = new List<Module>();
            List<GroupeMenu> groupe_menus = new List<GroupeMenu>();
            List<Menu> menus = new List<Menu>();

            // -- Mise à jour des variables -- //
            role_menus
                .OrderBy(l => l.menu.id)
                .ToList()
                .ForEach(role_menu =>
                {
                    // -- Ajout des modules distincs -- //
                    if (!modules.Exists(module => module.id == role_menu.menu.groupe_menu.module.id))
                    {
                        modules.Add(role_menu.menu.groupe_menu.module);
                    }
                    // -- Ajout des groupe de menus distincs -- //
                    if (!groupe_menus.Exists(groupe_menu => groupe_menu.id == role_menu.menu.groupe_menu.id))
                    {
                        groupe_menus.Add(role_menu.menu.groupe_menu);
                    }
                    // -- Ajout des menus distincs -- //
                    menus.Add(role_menu.menu);
                });

            // -- Mise à jour des menus dans les groupes -- //
            groupe_menus
                .ForEach(groupe_menu =>
                {
                    groupe_menu.menus = menus.Where(menu => menu.groupe_menu.id == groupe_menu.id).ToList();
                });

            // -- Mise à jour des modules -- //
            modules
                .ForEach(module =>
                {
                    module.groupe_menus = groupe_menus.Where(groupe_menu => module.id == groupe_menu.module.id).ToList();
                });

            // -- Mise à jour des menus HTML -- //
            modules
                .ForEach(module =>
                {
                    HTML += module.HTML();
                });


            return HTML;
        }

        public override void Crer_Id()
        {
            this.id = Program.db.menus.Count + 1;
        }
    }
}