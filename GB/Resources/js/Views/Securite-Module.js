
// -- Variables -- //
var table = $('#table-donnee');
var url_ajax_dataTable = '/Securite/Charger_Table/?id_page=' + $GB_DONNEE.id_page;
var url_ajax_selection_enregistrement = '/Securite/Selection_Enregistrement/';
var btn_ajouter = $('#btn-ajouter');
var btn_supprimer = $('#btn-supprimer');
var btn_imprimmer = $('#btn-imprimmer');
var btn_enregistrer = $('#btn-enregistrer');
var btn_table;
var form = $('#form');
var modal_form = $('#modal_form');
var url_controlleur = '/Securite/';


// -- Comportement des boutons des datatable -- // 
try {

    // -- Modifier -- //
    function table_donnee_modifier(id) {

        // -- Variables objet -- //
        btn_table = $('#table_donnee_modifier_id_' + id);

        // -- Actualiser le bouton d'action -- //
        btn_table.button('loading');

        // -- Ajax -- //
        $.ajax({
            type: "POST",
            url: url_ajax_selection_enregistrement,
            data: {
                id: id,
                id_page: $GB_DONNEE.id_page
            },
            success: function (resultat) {
                // -- Tester si le traitement s'est bien effectué -- //
                if (!resultat.notification.est_echec) {
                    // -- Mise à jour de sa valeur dans le formulaire -- //
                    $('#form_id').val(resultat.notification.donnee.id);
                    $('#form_code').val(resultat.notification.donnee.code);
                    $('#form_libelle_en').val(resultat.notification.donnee.libelle_en);
                    $('#form_libelle_fr').val(resultat.notification.donnee.libelle_fr);
                    // -- Mise à jour du label du bouton d'enregistrement -- //
                    btn_enregistrer.html('<i class="fa fa-check"></i>' + $GB_DONNEE_PARAMETRES.Lang.Update);
                    // -- Afficher le modal formulaire -- //
                    modal_form.modal('show');
                } else {
                    // -- Message -- //
                    gbMessage_Box(resultat.notification);
                }
                // -- fin boutton d'actualisation -- //
                btn_table.button('reset');
            },
            error: function () {
                // -- Message -- //
                gbMessage_Box();

                // -- fin boutton d'actualisation -- //
                btn_table.button('reset');
            }
        });

    }

} catch (e) { gbConsole(e.message); }

// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Initialiser le message box de confirmation -- //
        try {

            $GB_DONNEE.Confirmation_message_box = false;

        } catch (e) { gbConsole(e.message); }

        // -- Changer le titre de la page -- //
        try {

            gbChangeTitle($GB_DONNEE.titre);

        } catch (e) { gbConsole(e.message); }

        // -- Traitement table -- //
        try {

            // -- Lorsque la table est redessiné -- //
            table.on('draw.dt',
                function () {
                    // -- Fonction pour initiliser les style css javascript des tables -- //
                    gbCharger_Css_Table('module');
                }
            );

            // -- Table d'affichage des données -- //
            table.DataTable({
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, $GB_DONNEE_PARAMETRES.Lang.All]],
                "scrollCollapse": true,
                "paging": true,
                "searching": true,
                "autoWidth": false,
                "language": {
                    "url": $GB_VAR.url_language_dataTable
                },
                "ajax": {
                    "url": url_ajax_dataTable,
                    "type": 'POST',
                    "dataSrc": function (resultat) {
                        return resultat.notification.donnee;
                    }
                },
                "columns": [
                    { "data": "col_1", "width": "20px" },           // -- Checkbox -- //
                    { "data": "col_2" },                            // -- id -- //
                    { "data": "col_3" },                            // -- code -- //
                    { "data": "col_4" },                            // -- libelle_fr -- //
                    { "data": "col_5" },                            // -- libelle_en -- //
                    { "data": "col_6", "class": "text-center" }     // -- Action -- //
                ]
            });

            // -- Recharger la table -- //
            function table_recharger(frame) {

                // -- Recharger la table -- //
                table.DataTable().ajax.reload(
                    function () {
                        // -- Teste si c'est un seul element -- //
                        if (frame) {
                            // -- cacher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                        // -- Reset la taille de la table -- //
                        table.DataTable().columns.adjust().draw();
                    }
                );

            }

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
                            gbConfirmationAlert_OuiOuNon(null, null, form.attr('id'), null);
                            // -- Annuler l'action -- //
                            return false;
                        }

                        // -- Définition de l'action de traitement -- //
                        var action_ajouter = (parseInt($('#form_id').val()) == 0);
                        
                        // -- Afficher le chargement -- //
                        gbAfficher_Page_Chargement(true, btn_enregistrer.attr('id'));

                        // -- Ajax -- //
                        $.ajax({
                            type: "POST",
                            url: url_controlleur + (action_ajouter ? 'Ajouter_Enregistrement'
                                                                   : 'Modifier_Enregistrement'),
                            data: form.serialize() + '&id_page=' + $GB_DONNEE.id_page,
                            success: function (resultat) {
                                // -- Tester si le traitement s'est bien effectué -- //
                                if (!resultat.notification.est_echec) {
                                    // -- Fermer le modal -- //
                                    modal_form.modal('hide');
                                    // -- Actualiser la table -- //
                                    table_recharger(false);
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

        // -- Comportement lorsque le modal du formulaire se ferme -- //
        try {

            modal_form.on('hidden.bs.modal',
                function (e) {

                    // -- Reinitialiser le formulaire -- //
                    form[0].reset();

                    // -- Reinitialiser le id -- //
                    $('#form_id').val(0);

                    // -- Mise à jour du label du bouton d'enregistrement -- //
                    btn_enregistrer.html('<i class="fa fa-check"></i>' + $GB_DONNEE_PARAMETRES.Lang.Save);

                    // -- Suppression de l'alert message box -- //
                    $('#gbAlert').html(null);

                }
            );

        } catch (e) { gbConsole(e.message); }

    }
);
