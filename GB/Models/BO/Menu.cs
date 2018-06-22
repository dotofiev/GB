using GB.Models.BO;
using GB.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Menu : GBBO
    {
        public GroupeMenu groupe_menu { get; set; }
        public List<Role_Menu> role_menus { get; set; }
        public string route { get; set; }

        public Menu(long id, string route)
        {
            this._id = id;
            this.groupe_menu = new GroupeMenu(0);
            this.role_menus = new List<Role_Menu>();
            this.route = route;
        }

        public Menu()
        {
            this.groupe_menu = new GroupeMenu();
            this.role_menus = new List<Role_Menu>();
        }

        public string HTML()
        {
            return
                @"<li>
                    <a href=""javascript:;"" class=""menu-gb"" id=""{id}"" name=""{route}"" title=""{libelle}"">{libelle}</a>
                </li>"
                .Replace("{id}", this.id + "-" + this.groupe_menu.id)
                .Replace("{route}", this.route)
                .Replace("{libelle}", LangHelper.CurrentCulture == 0 ? this.libelle_en
                                                                     : this.libelle_fr);
        }

        //public static string Source(List<Role_Menu> role_menus)
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

        public static string Source(List<Role_Menu> role_menus)
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
    }
}