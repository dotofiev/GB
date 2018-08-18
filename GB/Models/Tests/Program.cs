using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models.BO;
using GB.Models.Tests;
using GB.Models.Static;
using GB.Models.Entites;

namespace GB.Models.Tests
{
    public static class Program
    {
        public static BD db { get; set; }

        public static void Initialiser_BD(string url_base_de_donnees)
        {
            // -- Lire la base de données -- //
            db = GBConvert.JSON_To<BD>(System.IO.File.ReadAllText(url_base_de_donnees));

            // -- Mise à jour des references objet -- //
            // -- Groupe menu -- //
            db.utilisateurs.ForEach(l => {
                l.agence = db.agences.FirstOrDefault(ll => ll.id == l.id_agence);
                l.profession = db.professions.FirstOrDefault(ll => ll.id == l.id_profession);
                l.autorite_signature = db.autorites_signature.FirstOrDefault(ll => ll.id == l.id_autorite_signature);
                l.date_mise_a_jour_mot_de_passe = DateTime.Now.AddMonths(1).Ticks;
            });
            // -- Groupe menu -- //
            db.groupe_menus.ForEach(l => {
                l.module = db.modules.FirstOrDefault(ll => ll.id == l.id_module);
            });
            // -- Menu -- //
            db.menus.ForEach(l => {
                l.groupe_menu = db.groupe_menus.FirstOrDefault(ll => ll.id == l.id_groupe_menu);
            });
            // -- Parent -- //
            db.menus.ForEach(l => {
                l.menu_parent = db.menus.FirstOrDefault(ll => ll.id == (l.id_menu_parent ?? 0));
            });
            // -- Enfant -- //
            db.menus.ForEach(l => {
                l.menus_enfant = db.menus.Where(ll => (ll.id_menu_parent?? 0) == l.id).ToList();
            });
            // -- Autorisation -- //
            db.autorisations.ForEach(l => {
                l.role = db.roles.FirstOrDefault(ll => ll.id == l.id_role);
                l.menu = db.menus.FirstOrDefault(ll => ll.id == l.id_menu);
            });
            // -- Parametre_bancaires -- //
            db.parametres_banque.ForEach(l => {
                l.devise = db.devises.FirstOrDefault(ll => ll.id == l.id_devise);
            });
            // -- Produit judiciaire -- //
            db.produits_judiciare.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Pays -- //
            db.pays.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Ville -- //
            db.villes.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Activité économique -- //
            db.activites_economique.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Titre -- //
            db.titres.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Unite Institutionnelle -- //
            db.unites_institutionnelle.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- BEAC Nationalités -- //
            db.nationalites_beac.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Direction budget -- //
            db.direction_dudget.ForEach(l =>
            {
                l.exercice_fiscal = db.exercices_fiscal.FirstOrDefault(ll => ll.id == l.id_exercice_fiscal);
            });
            // -- Congés bancaire -- //
            db.conges_banque.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Type de garanties -- //
            db.types_garantie.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
            });
            // -- Zone pays Western Union -- //
            db.western_union_zones_pays.ForEach(l =>
            {
                l.pays = db.pays.FirstOrDefault(ll => ll.id == l.id_pays);
            });
            // -- Compte -- //
            db.comptes.ForEach(l =>
            {
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur);
                l.devise = db.devises.FirstOrDefault(ll => ll.id == l.id_devise);
            });
            // -- CompteAgence -- //
            db.comptes_agence.ForEach(l =>
            {
                l.agence = db.agences.FirstOrDefault(ll => ll.id == l.id_agence);
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur_createur);
                l.compte = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte);
                l.compte_emetteur = db.comptes.FirstOrDefault(ll => ll.id == (l.id_compte_emetteur?? 0));
            });
            // -- CompteBanque -- //
            db.comptes_banque.ForEach(l =>
            {
                l.banque = db.banques.FirstOrDefault(ll => ll.id == l.id_banque);
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur_createur);
                l.compte = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte);
            });
            // -- Banque -- //
            db.banques.ForEach(l =>
            {
                l.pays = db.pays.FirstOrDefault(ll => ll.id == l.id_pays);
                l.utilisateur_createur = db.utilisateurs.FirstOrDefault(ll => ll.id_utilisateur == l.id_utilisateur_createur);
            });
            // -- Societe -- //
            db.societes.ForEach(l =>
            {
                l.agence = db.agences.FirstOrDefault(ll => ll.id == l.id_agence);
                l.compte_interet_pret = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte_interet_pret);
                l.compte_paiement = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte_paiement);
                l.compte_pret = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte_pret);
                l.compte_transit = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte_transit);
            });
            // -- ParametreBudgetRevenu -- //
            db.parametres_budget_revenus.ForEach(l =>
            {
                l.compte = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte);
            });
            // -- ParametreBudgetFrais -- //
            db.parametres_budget_frais.ForEach(l =>
            {
                l.compte = db.comptes.FirstOrDefault(ll => ll.id == l.id_compte);
            });
        }
    }
}