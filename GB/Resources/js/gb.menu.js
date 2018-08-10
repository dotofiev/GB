
// -- Lorsque le document est chargé -- //
$(function () {

    // -- Lorsqu'un menu est cliqué -- //
    $('.menu-gb').on("click",

        function (e) {

            // -- Annuler l'action de soumission -- //
            e.preventDefault();

            try {

                // -- Variables -- //
                var url = $(this).attr('name');
                var id = $(this).attr('id');

                // -- Check menu autorisé -- //
                if (url != '/Securite/Module' &&
                    url != '/Securite/Role' &&
                    url != '/Securite/Menu' &&

                    url != '/SecuriteUtilisateur/Utilisateur' &&

                    url != '/ConfigurationBanque/Institution' &&
                    url != '/ConfigurationBanque/Agence' &&
                    url != '/ConfigurationBanque/Banque' &&
                    url != '/ConfigurationBanque/CompteAgence' &&
                    url != '/ConfigurationBanque/CompteBanque' &&
                    url != '/ConfigurationBanque/Devise' &&
                    url != '/ConfigurationBanque/Parametre' &&
                    url != '/ConfigurationBanque/ParametreBanque' &&
                    url != '/ConfigurationBanque/ProduitClientPhysique' &&
                    url != '/ConfigurationBanque/ProduitClientJudiciaire' &&
                    url != '/ConfigurationBanque/Pays' &&
                    url != '/ConfigurationBanque/Ville' &&
                    url != '/ConfigurationBanque/ActiviteEconomique' &&
                    url != '/ConfigurationBanque/Titre' &&
                    url != '/ConfigurationBanque/UniteInstitutionnelle' &&
                    url != '/ConfigurationBanque/BEACNationalite' &&
                    url != '/ConfigurationBanque/CongeBanque' &&
                    url != '/ConfigurationBanque/Profitabilite' &&

                    url != '/ConfigurationBudget/ExerciceFiscal' &&
                    url != '/ConfigurationBudget/DirectionBudget' &&
                    url != '/ConfigurationBudget/AutoriteSignature' &&
                    
                    url != '/ConfigurationOperation/TypePret' &&
                    url != '/ConfigurationOperation/MotifPret' &&
                    url != '/ConfigurationOperation/ClassificationProvisionsPret' &&
                    url != '/ConfigurationOperation/TypeGarantie' &&
                    url != '/ConfigurationOperation/Journal' &&
                    url != '/ConfigurationOperation/TypeActif' &&
                    url != '/ConfigurationOperation/LocalisationActif' &&
                    url != '/ConfigurationOperation/WesternUnionZonePays' &&
                    url != '/ConfigurationOperation/Compte' &&
                    url != '/ConfigurationOperation/CompteConfiguration') {
                    // -- Message -- //
                    gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.Maintenance_message });

                    // -- Annuler l'action -- //
                    return false;
                }

                // -- Frame chargement -- //
                gbAfficher_Page_Chargement(true);

                // -- Charger le résultats dans la page -- //
                $("#conteneur").load(
                        // -- Lien de chargement de la page -- //
                        url,
                        // -- Fonction à éxecuter à la fin du chargement de la page -- //
                        function () {
                            // -- Frame chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    );

            } catch (e) { gbConsole(e.message); }

        }

    );

});