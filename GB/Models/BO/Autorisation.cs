using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Autorisation : GBBO
    {
        public long id_role { get; set; }
        public long id_menu { get; set; }
        public Role role { get; set; }
        public Menu menu { get; set; }
        public bool ajouter { get; set; }
        public bool modifier { get; set; }
        public bool supprimer { get; set; }
        public bool imprimer { get; set; }
        public bool lister { get; set; }

        public Autorisation(long id, long id_role, long id_menu, string view)
        {
            this.id = id;
            this.role = new Role(id_role);
            this.menu = new Menu(id_menu, view);
        }

        public Autorisation() {
            this.role = new Role();
            this.menu = new Menu();
        }

        public override void Crer_Id()
        {
            this.id = Program.db.autorisations.Count + 1;
        }
    }
}