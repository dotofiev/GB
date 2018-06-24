using GB.Models.BO;
using GB.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class GroupeMenu : GBBO
    {
        public Module module { get; set; }
        public List<Menu> menus { get; set; }

        public GroupeMenu(long id)
        {
            this.id = id;
            this.menus = new List<Menu>();
            this.module = new Module(0);
        }

        public GroupeMenu()
        {
            this.menus = new List<Menu>();
            this.module = new Module();
        }

        public string HTML()
        {
            // -- Variables -- //
            string HTML_menu = string.Empty;
            // -- Réccupération du HTML des menu -- //
            this.menus.ForEach(menu =>
            {
                HTML_menu += menu.HTML();
            });

            // -- Retourner les menus -- //
            return
                HTML_menu != string.Empty ?
                    @"<ul class=""nav side-menu"">
                        <li>
                            <a title=""{libelle}"">
                                <i class=""fa fa-square""></i> {libelle} <span class=""fa fa-chevron-down""></span>
                            </a>
                            <ul class=""nav child_menu"">
                                {menus}
                            </ul>
                        </li>
                    </ul>"
                    .Replace("{menus}", HTML_menu)
                    .Replace("{libelle}", LangHelper.CurrentCulture == 0 ? this.libelle_en
                                                                         : this.libelle_fr)
                : string.Empty;
        }
    }
}