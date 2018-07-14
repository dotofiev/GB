using GB.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Tests
{
    public class BD
    {
        public List<Module> modules { get; set; }
        public List<Role> roles { get; set; }
        public List<Menu> menus { get; set; }
        public List<Autorisation> autorisations { get; set; }
        public List<Utilisateur> utilisateurs { get; set; }
        public List<GroupeMenu> groupe_menus { get; set; }
        public List<Agence> agences { get; set; }
        public List<Profession> professions { get; set; }
        public List<Institution> institutions { get; set; }
        public List<Devise> devises { get; set; }
        public List<Parametre> parametres { get; set; }
        public List<ParametreBancaire> parametre_bancaires { get; set; }
        public List<ProduitPhysique> produits_physique { get; set; }
        public List<ProduitJudiciaire> produits_judiciare { get; set; }
        public List<Pays> pays { get; set; }
        public List<Ville> villes { get; set; }
        public List<ActiviteEconomique> activites_economique { get; set; }
        
        public BD() { }
    }
}