using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Module : BO, IBO<object>
    {
        public List<GroupeMenu> groupe_menus { get; set; }

        public Module(string id)
        {
            this.id = id;
            this.groupe_menus = new List<GroupeMenu>();
        }

        public Module()
        {
            this.groupe_menus = new List<GroupeMenu>();
        }

        public string HTML()
        {
            // -- Variables -- //
            string HTML_groupe_menu = string.Empty;
            // -- Réccupération du HTML des groupes menu -- //
            this.groupe_menus.ForEach(groupe_menu =>
            {
                HTML_groupe_menu += groupe_menu.HTML();
            });


            // -- Retourner les menus -- //
            return
                HTML_groupe_menu != string.Empty ?
                    @"<div class=""menu_section"">
                        <h3>{libelle}</h3>
                        {groupe_menus}
                    </div>"
                    .Replace("{groupe_menus}", HTML_groupe_menu)
                    .Replace("{libelle}", LangHelper.CurrentCulture == 0 ? this.libelle_en
                                                                         : this.libelle_fr)
                : string.Empty;
        }

        public void Crer_Id()
        {
            this.id = (Program.db.modules.Count + 1).ToString();
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