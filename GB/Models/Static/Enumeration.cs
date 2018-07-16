using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class GB_Enum_Langue
    {
        public static string Francais   = "fr-FR";
        public static string Anglais    = "en-US";
    }

    public static class GB_Enum_Menu
    {
        public static string Securite_Role = "Securite-Role";
        public static string Securite_Module = "Securite-Module";
        public static string Securite_Menu = "Securite-Menu";
        public static string SecuriteUtilisateur_Utilisateur = "SecuriteUtilisateur-Utilisateur";
        public static string ConfigurationBanque_Institution = "ConfigurationBanque-Institution";
        public static string ConfigurationBanque_Agence = "ConfigurationBanque-Agence";
        public static string ConfigurationBanque_Devise = "ConfigurationBanque-Devise";
        public static string ConfigurationBanque_Parametre = "ConfigurationBanque-Parametre";
        public static string ConfigurationBanque_ParametreBanque = "ConfigurationBanque-ParametreBanque";
        public static string ConfigurationBanque_ProduitClientPhysique = "ConfigurationBanque-ProduitClientPhysique";
        public static string ConfigurationBanque_ProduitClientJudiciaire = "ConfigurationBanque-ProduitClientJudiciaire";
        public static string ConfigurationBanque_Pays = "ConfigurationBanque-Pays";
        public static string ConfigurationBanque_Ville = "ConfigurationBanque-Ville";
        public static string ConfigurationBanque_ActiviteEconomique = "ConfigurationBanque-ActiviteEconomique";
        public static string ConfigurationBanque_Titre = "ConfigurationBanque-Titre";
        public static string ConfigurationBanque_UniteInstitutionnelle = "ConfigurationBanque-UniteInstitutionnelle";
        public static string ConfigurationBanque_BEACNationalite = "ConfigurationBanque-BEACNationalite";        
    }

    public enum GB_Enum_Action_Controller
    {
        Ajouter = 1,
        Modifier = 2,
        Supprimer = 3,
        Imprimer = 4,
        Lister = 5,
    }

    public enum GB_Enum_Type_Produit
    {
        Physique,
    }
}