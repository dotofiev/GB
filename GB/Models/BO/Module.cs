﻿using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Module : GBBO
    {
        public List<GroupeMenu> groupe_menus { get; set; }

        public Module(long id)
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

        public override void Crer_Id()
        {
            this.id = TestClass.db_modules.Count + 1;
        }
    }
}