using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class Menu
    {
        public static string Source(long id_utilisateur)
        {
            string menus = "";

            for(int i = 1; i <= 3; i++)
            {
                menus +=
                @"<div class=""menu_section"">
                    
                    <h3>{groupe_menu}</h3>
                    
                    <ul class=""nav side-menu"">".Replace("{groupe_menu}", "Groupe menu " + i);

                        for(int ii = 1; ii <= 3; ii++)
                        {
                            menus +=
                            @"<li>
                                <a>
                                    <i class=""fa fa-square""></i> {menu} <span class=""fa fa-chevron-down""></span>
                                </a>
                                <ul class=""nav child_menu"">".Replace("{menu}", "Menu " + ii);

                                for(int iii = 1; iii <= 3; iii++)
                                {
                                    menus += $"<li><a href=\"#\">{"Sous menu " + iii}</a></li>";
                                }

                            menus +=
                                @"</ul>
                            </li>";
                        }

                        menus +=
                    @"</ul>
                </div>";
            }

            return menus;
        }
    }
}