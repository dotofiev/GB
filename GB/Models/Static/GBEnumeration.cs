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
        public static string Erreur_Page = "Erreur-Page";
        public static string Home_Authentication = "Home-Authentication";
        public static string Application_Main = "Application-Main";
        public static string Securite_Role = "Securite-Role";
        public static string Securite_Module = "Securite-Module";
        public static string Securite_Menu = "Securite-Menu";
        public static string SecuriteUtilisateur_Utilisateur = "SecuriteUtilisateur-Utilisateur";
        public static string ConfigurationBanque_Institution = "ConfigurationBanque-Institution";
        public static string ConfigurationBanque_Agence = "ConfigurationBanque-Agence";
        public static string ConfigurationBanque_CompteAgence = "ConfigurationBanque-CompteAgence";
        public static string ConfigurationBanque_Devise = "ConfigurationBanque-Devise";
        public static string ConfigurationBanque_Parametre = "ConfigurationBanque-Parametre";
        public static string ConfigurationBanque_ParametreBanque = "ConfigurationBanque-ParametreBanque";
        public static string ConfigurationBanque_ProduitClientPhysique = "ConfigurationBanque-ProduitClientPhysique";
        public static string ConfigurationBanque_ProduitClientJudiciaire = "ConfigurationBanque-ProduitClientJudiciaire";
        public static string ConfigurationBanque_Pays = "ConfigurationBanque-Pays";
        public static string ConfigurationBanque_Ville = "ConfigurationBanque-Ville";
        public static string ConfigurationBanque_ActiviteEconomique = "ConfigurationBanque-ActiviteEconomique";
        public static string ConfigurationBanque_Titre = "ConfigurationBanque-Titre";
        public static string ConfigurationBanque_Banque = "ConfigurationBanque-Banque";        
        public static string ConfigurationBanque_UniteInstitutionnelle = "ConfigurationBanque-UniteInstitutionnelle";
        public static string ConfigurationBanque_BEACNationalite = "ConfigurationBanque-BEACNationalite";
        public static string ConfigurationBanque_Profitabilite = "ConfigurationBanque-Profitabilite";
        public static string ConfigurationBanque_CompteBanque = "ConfigurationBanque-CompteBanque";        
        public static string ConfigurationBudget_ExerciceFiscal = "ConfigurationBudget-ExerciceFiscal";
        public static string ConfigurationBudget_DirectionBudget = "ConfigurationBudget-DirectionBudget";
        public static string ConfigurationBanque_CongeBanque = "ConfigurationBanque-CongeBanque";
        public static string ConfigurationBudget_AutoriteSignature = "ConfigurationBudget-AutoriteSignature";
        public static string ConfigurationOperation_TypePret = "ConfigurationOperation-TypePret";
        public static string ConfigurationOperation_MotifPret = "ConfigurationOperation-MotifPret";
        public static string ConfigurationOperation_ClassificationProvisionsPret = "ConfigurationOperation-ClassificationProvisionsPret";
        public static string ConfigurationOperation_TypeGarantie = "ConfigurationOperation-TypeGarantie";
        public static string ConfigurationOperation_Journal = "ConfigurationOperation-Journal";
        public static string ConfigurationOperation_TypeActif = "ConfigurationOperation-TypeActif";
        public static string ConfigurationOperation_LocalisationActif = "ConfigurationOperation-LocalisationActif";
        public static string ConfigurationOperation_WesternUnionZonePays = "ConfigurationOperation-WesternUnionZonePays";
        public static string ConfigurationOperation_Compte = "ConfigurationOperation-Compte";
        public static string ConfigurationOperation_CompteConfiguration = "ConfigurationOperation-CompteConfiguration";       
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