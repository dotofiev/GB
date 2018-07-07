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
    }

    public enum GB_Enum_Action_Controller
    {
        Ajouter = 1,
        Modifier = 2,
        Supprimer = 3,
        Imprimer = 4,
        Lister = 5,
    }
}