using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Autorisation : BOClass, IBO<object>
    {
        public string id_role { get; set; }
        public string id_menu { get; set; }
        public Role role { get; set; }
        public Menu menu { get; set; }
        public bool ajouter { get; set; }
        public bool modifier { get; set; }
        public bool supprimer { get; set; }
        public bool imprimer { get; set; }
        public bool lister { get; set; }

        public Autorisation(string id, string id_role, string id_menu, string view)
        {
            this.id = id;
            this.role = new Role(id_role);
            this.menu = new Menu(id_menu, view);
        }

        public Autorisation() {
            this.role = new Role();
            this.menu = new Menu();
        }

        public void Crer_Id()
        {
            this.id = (Program.db.autorisations.Count + 1).ToString();
        }

        public object ToEntities(Dictionary<string, object> parametres = null)
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

        public static List<string> Classes_references
        {
            get
            {
                return
                    new List<string>() {
                        typeof(Menu).Name,
                        typeof(Role).Name
                    };
            }
        }
    }
}