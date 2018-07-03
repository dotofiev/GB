
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
var form_id_controller = $('#form_id_controller');
var form_view = $('#form_view');
var modal_form = $('#modal_form');
var url_controlleur = '/Securite/';
var url_suppression = '/Securite/Supprimer_Enregistrement';
var class_table_selection = 'gb-table-success';


// -- Méthodes d'action sur les données -- // 
try {

    // -- Modifier -- //
    function table_donnee_modifier(code) {

        // -- Ajax -- //
        $.ajax({
            type: "POST",
            url: url_ajax_selection_enregistrement,
            data: {
                code: code,
                id_page: $GB_DONNEE.id_page
            },
            success: function (resultat) {
                // -- Tester si le traitement s'est bien effectué -- //
                if (!resultat.notification.est_echec) {
                    // -- Réccépération de la valeur -- //
                    $GB_DONNEE.form_view_valeur = resultat.notification.donnee.view;
                    $GB_DONNEE.form_id_controller_valeur = resultat.notification.donnee.id_controller;
                    // -- Mise à jour de sa valeur dans le formulaire -- //
                    $('#form_id').val(resultat.notification.donnee.id);
                    $('#form_code').val(resultat.notification.donnee.code);
                    $('#form_libelle_en').val(resultat.notification.donnee.libelle_en);
                    $('#form_libelle_fr').val(resultat.notification.donnee.libelle_fr);
                    form_id_controller.val(resultat.notification.donnee.id_controller).change();
                    // -- Mise à jour du label du bouton d'enregistrement -- //
                    btn_enregistrer.html('<i class="fa fa-check"></i>' + $GB_DONNEE_PARAMETRES.Lang.Update);
                    // -- Afficher le modal formulaire -- //
                    modal_form.modal('show');
                } else {
                    // -- Message -- //
                    gbMessage_Box(resultat.notification);
                }
            },
            error: function () {
                // -- Message -- //
                gbMessage_Box();
            }
        });

    }

    // -- Mise à jour des bouton de rafraichissement de la table -- //
    function table_bouton_action_etat(bouton_table, activation, id_bouton) {

        // -- Teste si c'est un element de la table -- //
        if (bouton_table) {
            // -- Si le bouton est activé -- //
            if (activation) {
                // -- Variables objet -- //
                btn_table = $('#table_donnee_supprimer_id_' + id_bouton);
            }
            // -- bouton d'action -- //
            btn_table.button((activation) ? 'loading'
                                          : 'reset');
        } else {
            // -- boutton d'actualisation -- //
            btn_supprimer.button((activation) ? 'loading'
                                              : 'reset');
        }

        // -- Afficher le chargement -- //
        gbAfficher_Page_Chargement(activation);

    }

    // -- Supprimer -- //
    function table_donnee_supprimer(ids, bouton_table) {

        // -- Ecouter la réponse du message de confirmation -- //
        if (!$GB_DONNEE.Confirmation_message_box) {
            // -- Afficher le message d'action -- //
            gbConfirmation_OuiOuNon(null, null, function () { table_donnee_supprimer(ids, bouton_table); });
            // -- Annuler l'action -- //
            return false;
        }

        // -- Mise à jour des bouton de rafraichissement de la table -- //
        table_bouton_action_etat(bouton_table, true, ids[0]);

        // -- Ajax -- //
        $.ajax({
            type: "POST",
            url: url_suppression,
            data: {
                ids: JSON.stringify(ids),
                id_page: $GB_DONNEE.id_page
            },
            success: function (resultat) {
                // -- Tester si le traitement s'est bien effectué -- //
                if (!resultat.notification.est_echec) {
                    // -- Recharger la table -- //
                    table_recharger(false);
                } else {
                    // -- Message -- //
                    gbMessage_Box(resultat.notification);
                }

                // -- Mise à jour des bouton de rafraichissement de la table -- //
                table_bouton_action_etat(bouton_table, false, null);
            },
            error: function () {
                // -- Message -- //
                gbMessage_Box();

                // -- Mise à jour des bouton de rafraichissement de la table -- //
                table_bouton_action_etat(bouton_table, false, null);
            }
        });

    }

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
                // -- Selectionner une ligne de la table -- //
                table_selection_ligne();
                // -- Désactiver le multiselect -- //
                $("#check-all").iCheck('uncheck');
                $('.column-title').show();
                $('.bulk-actions').hide();
            }
        );

    }

    // -- Selectionner une ligne de la table -- //
    function table_selection_ligne(ligne) {

        // -- Suppression de toutes les lignes delectionnées -- //
        $('#table-donnee tbody tr').each(
            function () {
                // -- Si l'element n'a pas la classe passer -- //
                if ($(this).hasClass(class_table_selection)) {
                    $(this).removeClass(class_table_selection);
                }
            }
        );

        // -- Mise à jour de la couleur de la ligne -- //
        if (ligne != undefined && ligne != null) {
            ligne.addClass(class_table_selection);
        }

    }

} catch (e) { gbConsole(e.message); }

// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Initialiser le message box de confirmation et autres paramètres -- //
        try {

            $GB_DONNEE.Confirmation_message_box = false;
            $GB_DONNEE.form_view_valeur = null;
            $GB_DONNEE.form_id_controller_valeur = 0;

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
                    gbCharger_Css_Table('menu');
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
                    { "data": "col_2" },                            // -- code -- //
                    { "data": "col_3" },                            // -- libelle_fr -- //
                    { "data": "col_4" },                            // -- libelle_en -- //
                    { "data": "col_5" },                            // -- groupe_menu -- //
                    { "data": "col_6" },                            // -- vues -- //
                    { "data": "col_7", "class": "text-center" }     // -- Action -- //
                ]
            });

            // -- Lorsqu'un click survient sur une ligne de la table -- //
            $('#table-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    table_selection_ligne($(this));
                }
            );

            // -- Lorsqu'un double click survient sur une ligne de la table -- //
            $('#table-donnee tbody').on('dblclick', 'tr',
                function () {
                    // -- Réccupération des données de la table -- //
                    var donnees = table.DataTable().row(this).data();

                    // -- Vérifie qu'un enregistrement est sélectionné -- //
                    if (donnees != undefined && donnees != null) {
                        // -- Modifier l'enregistrement -- //
                        table_donnee_modifier(donnees.col_2);
                    }
                }
            );

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

                    // -- Suppression de l'alert de confirmation -- //
                    $('#dsAlert_Message_Box').html(null);

                    // -- Suppression des combo box dynamique -- //
                    form_view.html('<option value="" title="' + $GB_DONNEE_PARAMETRES.Lang.Select + '...">' + $GB_DONNEE_PARAMETRES.Lang.Select + '...</option>');

                    // -- Suppression des paramètres -- //
                    $GB_DONNEE.form_view_valeur = null;
                    $GB_DONNEE.form_id_controller_valeur = 0;

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton de suppression -- //
        try {

            // -- Mise à jour de l'action de suppression -- //
            btn_supprimer.on("click",
                function () {
                    // -- Réccupérer les données electionné -- //
                    var selection = $('input[name="menu"]:checked');

                    // -- Si la taille est supérieurs à 0 -- //
                    if (selection.length == 0) {
                        // -- Afficher message d'erreur -- //
                        gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected });
                        
                        return false;
                    }

                    // -- Mise à jour de l'etat de la selection -- //
                    selection = selection.serialize().split('&');

                    // -- Appel de la fonction -- //
                    var ids = [];
                    // -- Réccupération des id -- //
                    for (var i = 0; i < selection.length; i++) {
                        ids.push(selection[i].replace('menu=menu_', ''));
                    }

                    // -- SOumettre les données au traitement -- //
                    table_donnee_supprimer(ids, false);
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

        // -- Action de selection d'un groupe menu -- //
        try {

            form_id_controller.on("change",
                function () {

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: url_controlleur + 'Arbre_Menu',
                        data: {
                            id_controller: $(this).val()
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Mise à jour du composant select -- //
                                form_view.html(resultat.notification.donnee);
                                // -- Mettre à jour la valeur si elle est défini -- //
                                if ($GB_DONNEE.form_view_valeur != null) {
                                    // -- Teste si c'est la valeur d'origine -- //
                                    if (parseInt(form_id_controller.val()) === parseInt($GB_DONNEE.form_id_controller_valeur)) {
                                        form_view.val($GB_DONNEE.form_view_valeur);
                                    }
                                } else {
                                    form_view.val('');
                                }
                            }
                            else {
                                // -- Afficher une alerte sur un element -- //
                                gbAlert(resultat.notification, null);
                            }
                        },
                        error: function () {
                            // -- Afficher une alerte sur un element -- //
                            gbAlert();
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

    }
);
