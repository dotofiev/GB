
// -- Variables -- //
var url_ajax_dataTable = '/ConfigurationBanque/Charger_Table/?id_page=' + $GB_DONNEE.id_page;
var url_ajax_selection_enregistrement = '/ConfigurationBanque/Selection_Enregistrement/';
var btn_ajouter = $('#btn-ajouter');
var btn_supprimer = $('#btn-supprimer');
var btn_imprimmer = $('#btn-imprimmer');
var btn_enregistrer = $('#btn-enregistrer');
var btn_table;
var form = $('#form');
var modal_form = $('#modal_form');
var url_controlleur = '/ConfigurationBanque/';
var url_suppression = '/ConfigurationBanque/Supprimer_Enregistrement';


// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Initialiser le message box de confirmation -- //
        try {

            $GB_DONNEE.Confirmation_message_box = false;

        } catch (e) { gbConsole(e.message); }

        // -- Changer le titre de la page -- //
        try {

            gbChangeTitle($GB_DONNEE.titre, $GB_DONNEE.description);

        } catch (e) { gbConsole(e.message); }

        // -- Soumission du formulaire ajout/modification -- //
        try {

            // -- Soumet le formulaire -- //
            form.on("submit",
                function (e) {
                    // -- Désactiver la soumission -- //
                    e.preventDefault();

                    // -- Variables -- //
                    form.parsley().validate();

                    // If the form is valid
                    if (form.parsley().isValid()) {

                        // -- Ecouter la réponse du message de confirmation -- //
                        if (!$GB_DONNEE.Confirmation_message_box) {
                            // -- Afficher le message d'action -- //
                            gbConfirmation_OuiOuNon(null, form.attr('id'), null);
                            // -- Annuler l'action -- //
                            return false;
                        }
                        
                        // -- Afficher le chargement -- //
                        gbAfficher_Page_Chargement(true, btn_enregistrer.attr('id'));

                        // -- Ajax -- //
                        $.ajax({
                            type: "POST",
                            url: url_controlleur + 'Modifier_Enregistrement',
                            data: {
                                obj: JSON.stringify(form.gbConvertToJSON()),
                                id_page: $GB_DONNEE.id_page
                            },
                            success: function (resultat) {
                                // -- Tester si le traitement s'est bien effectué -- //
                                if (!resultat.notification.est_echec) {
                                    // -- Fermer le modal -- //
                                    modal_form.modal('hide');
                                    // -- Actualiser la table -- //
                                    gbRechargerTable(false);
                                }
                                else {
                                    // -- Afficher une alerte sur un element -- //
                                    gbAlert(resultat.notification, null);
                                }
                                // -- Afficher le chargement -- //
                                gbAfficher_Page_Chargement(false, btn_enregistrer.attr('id'));
                            },
                            error: function () {
                                // -- Afficher le chargement -- //
                                gbAfficher_Page_Chargement(false, btn_enregistrer.attr('id'));
                                // -- Afficher une alerte sur un element -- //
                                gbAlert();
                            }
                        });

                    }
                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton d'impression -- //
        try {

            // -- Mise à jour de l'action de suppression -- //
            btn_imprimmer.on("click",
                function () {
                    
                    // -- Message -- //
                    gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.Maintenance_message });

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Mise à jour des données sur le formuaire -- //
        try {

            $('#form_id').val($GB_DONNEE.parametre.id);
            $('#form_nombre_ligne_historique_compte').val($GB_DONNEE.parametre.nombre_ligne_historique_compte);
            $('#form_utilisation_chequier').val($GB_DONNEE.parametre.utilisation_chequier.toString());
            $('#form_nombre_jour_avant_apuration_credit').val($GB_DONNEE.parametre.nombre_jour_avant_apuration_credit);
            $('#form_periode_dormante').val($GB_DONNEE.parametre.periode_dormante);
            $('#form_periode_litige').val($GB_DONNEE.parametre.periode_litige);
            $('#form_utilisation_version_centrale').val($GB_DONNEE.parametre.utilisation_version_centrale.toString());
            $('#form_periode_de_non_paiement').val($GB_DONNEE.parametre.periode_de_non_paiement);
            $('#form_controler_le_nombre_de_pret').val($GB_DONNEE.parametre.controler_le_nombre_de_pret.toString());
            $('#form_controler_le_nombre_de_comptes').val($GB_DONNEE.parametre.controler_le_nombre_de_comptes.toString());
            $('#form_tva').val($GB_DONNEE.parametre.tva.toString());
            $('#form_controler_session').val($GB_DONNEE.parametre.controler_session.toString());
            $('#form_duree_session').val($GB_DONNEE.parametre.duree_session);
            $('#form_sms_banking').val($GB_DONNEE.parametre.sms_banking.toString());
            $('#form_nombre_de_jour_ouverture_back_date').val($GB_DONNEE.parametre.nombre_de_jour_ouverture_back_date);
            $('#form_methode_de_post_interet_reserver').val($GB_DONNEE.parametre.methode_de_post_interet_reserver);
            $('#form_utilisation_litige_methode_cobac').val($GB_DONNEE.parametre.utilisation_litige_methode_cobac.toString());
            $('#form_modifier_les_attributs_client_dans_la_branch').val($GB_DONNEE.parametre.modifier_les_attributs_client_dans_la_branch.toString());
            $('#form_conter_le_nombre_de_page_dans_historique').val($GB_DONNEE.parametre.conter_le_nombre_de_page_dans_historique.toString());
            $('#form_mise_a_jour_position_client').val($GB_DONNEE.parametre.mise_a_jour_position_client.toString());
            $('#form_poster_credit').val($GB_DONNEE.parametre.poster_credit.toString());
            $('#form_poster_litige_pret').val($GB_DONNEE.parametre.poster_litige_pret.toString());
            $('#form_poster_collection_locale').val($GB_DONNEE.parametre.poster_collection_locale.toString());
            $('#form_western_union').val($GB_DONNEE.parametre.western_union.toString());
            $('#form_poster_bon_de_caisse_et_depot_a_terme').val($GB_DONNEE.parametre.poster_bon_de_caisse_et_depot_a_terme.toString());
            $('#form_methode_de_sauvegarde').val($GB_DONNEE.parametre.methode_de_sauvegarde);
            $('#form_lien_sauvegarde_numero_1_label').html($GB_DONNEE.parametre.lien_sauvegarde_numero_1);
            $('#form_lien_sauvegarde_numero_2_label').html($GB_DONNEE.parametre.lien_sauvegarde_numero_2);
            $('#form_lien_sauvegarde_numero_1').val($GB_DONNEE.parametre.lien_sauvegarde_numero_1);
            $('#form_lien_sauvegarde_numero_2').val($GB_DONNEE.parametre.lien_sauvegarde_numero_2);

        } catch (e) { gbConsole(e.message); }

        // -- Configurer le processus d'importation des ifhcier sur le formulaire -- //
        try {

            gbConfigurerImportationFichier('form_lien_sauvegarde_numero_1_fichier', 'form_lien_sauvegarde_numero_1_btn', 'form_lien_sauvegarde_numero_1_btn_delete', 'form_lien_sauvegarde_numero_1_label', null, null);

            gbConfigurerImportationFichier('form_lien_sauvegarde_numero_2_fichier', 'form_lien_sauvegarde_numero_2_btn', 'form_lien_sauvegarde_numero_2_btn_delete', 'form_lien_sauvegarde_numero_2_label', null, null);

        } catch (e) { gbConsole(e.message); }

        // -- Mise à jour de la taille des label -- //
        try {

            // -- Variable de la position -- //
            var positions = [];
            var index = 1;
            var index_2 = 1;
            var range = [];
            // -- Parcourir tous les label -- //
            $('label').each(
                function () {
                    // -- Les 24 premier element -- //
                    if (index <= 24) {
                        var width = parseFloat($(this).css('width').replace('px', null));
                        var width_for = parseFloat($('#' + $(this).attr('for')).css('width').replace('px', null));
                        // -- AJout à la liste des for -- //
                        range.push($(this).attr('for'));
                        // -- Mise à jou de la taille si le with est trop grand -- //
                        if (width >= width_for) {
                            // -- AJout à la position -- //
                            positions.push(index);
                        }
                        // -- Incrémenter l'index -- //
                        index++;
                    }
                }
            );

            gbConsole('positions: ' + JSON.stringify(positions));

            // -- Mise à jour des taille -- //
            for (var index_position = 1; index_position <= positions.length; index_position++) {

                if (positions[index_position] >= 1 && positions[index_position] <= 6) {
                    for (var i = 1; i <= 6; i++) {
                        // -- Différent de ma position -- //
                        if (!gbExist(i, positions)) {
                            var label = $('label[for="' + range[i - 1] + '"]');
                            // -- Mise à jour du HTML -- //
                            label.html('<br/>' + label.html());
                        }
                    }
                }
                else if (positions[index_position] >= 7 && positions[index_position] <= 12) {
                    for (var i = 7; i <= 12; i++) {
                        // -- Différent de ma position -- //
                        if (!gbExist(i, positions)) {
                            var label = $('label[for="' + range[i - 1] + '"]');
                            // -- Mise à jour du HTML -- //
                            label.html('<br/>' + label.html());
                        }
                    }
                }
                else if (positions[index_position] >= 13 && positions[index_position] <= 18) {
                    for (var i = 13; i <= 18; i++) {
                        // -- Différent de ma position -- //
                        if (!gbExist(i, positions)) {
                            var label = $('label[for="' + range[i - 1] + '"]');
                            // -- Mise à jour du HTML -- //
                            label.html('<br/>' + label.html());
                        }
                    }
                }
                else if (positions[index_position] >= 19 && positions[index_position] <= 24) {
                    for (var i = 19; i <= 24; i++) {
                        // -- Différent de ma position -- //
                        if (!gbExist(i, positions)) {
                            var label = $('label[for="' + range[i - 1] + '"]');
                            // -- Mise à jour du HTML -- //
                            label.html('<br/>' + label.html());
                        }
                    }
                }

            }

        } catch (e) { gbConsole(e.message); }

    }
);
