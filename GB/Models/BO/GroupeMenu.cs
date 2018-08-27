using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class GroupeMenu : BO, IBO<object>
    {
        public string id_module { get; set; }
        public Module module { get; set; }
        public List<Menu> menus { get; set; }
        public string icon { get; set; }
        public string controller { get; set; }

        public GroupeMenu(string id, string controller)
        {
            this.id = id;
            this.menus = new List<Menu>();
            this.module = new Module("0");
            this.icon = string.Empty;
            this.controller = controller;
        }

        public GroupeMenu()
        {
            this.menus = new List<Menu>();
            this.module = new Module();
            this.icon = string.Empty;
            this.controller = string.Empty;
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
                                <i class=""{icon}""></i> {libelle}
                            </a>
                            <ul class=""nav child_menu"">
                                {menus}
                            </ul>
                        </li>
                    </ul>"
                    .Replace("{icon}", icon)
                    .Replace("{menus}", HTML_menu)
                    .Replace("{libelle}", LangHelper.CurrentCulture == 0 ? this.libelle_en
                                                                         : this.libelle_fr)
                : string.Empty;
        }

        public void Crer_Id()
        {

        }

        public object ToEntities()
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