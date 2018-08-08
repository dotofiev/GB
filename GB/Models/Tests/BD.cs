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
        public List<ParametreBanque> parametres_banque { get; set; }
        public List<ProduitPhysique> produits_physique { get; set; }
        public List<ProduitJudiciaire> produits_judiciare { get; set; }
        public List<Pays> pays { get; set; }
        public List<Ville> villes { get; set; }
        public List<ActiviteEconomique> activites_economique { get; set; }
        public List<Titre> titres { get; set; }
        public List<UniteInstitutionnelle> unites_institutionnelle { get; set; }
        public List<BEACNationalite> nationalites_beac { get; set; }
        public List<ExerciceFiscal> exercices_fiscal { get; set; }
        public List<DirectionBudget> direction_dudget { get; set; }
        public List<CongeBanque> conges_banque { get; set; }
        public List<AutoriteSignature> autorites_signature { get; set; }
        public List<TypePret> types_pret { get; set; }
        public List<MotifPret> motifs_pret { get; set; }
        public List<ClassificationProvisionsPret> classification_provisions_pret { get; set; }
        public List<TypeGarantie> types_garantie { get; set; }
        public List<Journal> journaux { get; set; }
        public List<TypeActif> types_actif { get; set; }
        public List<LocalisationActif> localisations_actif { get; set; }
        public List<WesternUnionZonePays> western_union_zones_pays { get; set; }
        public List<Compte> comptes { get; set; }
        public List<CompteAgence> comptes_agence { get; set; }
        
        public BD() { }
    }
}