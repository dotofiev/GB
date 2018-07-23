
// -- Variables -- //
var url_controlleur = '/ConfigurationOperation/';
var table = $('#table-donnee');
var url_ajax_dataTable = url_controlleur + 'Charger_Table/?id_page=' + $GB_DONNEE.id_page;
var url_ajax_selection_enregistrement = url_controlleur + 'Selection_Enregistrement/';
var btn_ajouter = $('#btn-ajouter');
var btn_supprimer = $('#btn-supprimer');
var btn_imprimmer = $('#btn-imprimmer');
var btn_enregistrer = $('#btn-enregistrer');
var btn_table;
var form = $('#form');
var modal_form = $('#modal_form');
var url_suppression = url_controlleur + 'Supprimer_Enregistrement';


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
                    // -- Mise à jour de sa valeur dans le formulaire -- //
                    $('#form_id').val(resultat.notification.donnee.id);
                    $('#form_code').val(resultat.notification.donnee.code);
                    $('#form_libelle').val(resultat.notification.donnee.libelle);
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
                    gbRechargerTable(false);
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

            gbChangeTitle($GB_DONNEE.titre, $GB_DONNEE.description);

        } catch (e) { gbConsole(e.message); }

        // -- Traitement table -- //
        try {

            // -- Lorsque la table est redessiné -- //
            table.on('draw.dt',
                function () {
                    // -- Fonction pour initiliser les style css javascript des tables -- //
                    gbCharger_Css_Table('localisationActif');
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
                        // -- Notifier -- //
                        gbNotificationListerRefuser(resultat.notification);
                        // -- Retourner les données -- //
                        return resultat.notification.donnee;
                    }
                },
                "columns": [
                    { "data": "col_1", "width": "20px" },           // -- Checkbox -- //
                    { "data": "col_2" },                            // -- code -- //
                    { "data": "col_3" },                            // -- libelle -- //
                    { "data": "col_4" },                            // -- date_creation -- //
                    { "data": "col_5", "class": "text-center" }     // -- Action -- //
                ]
            });

            // -- Lorsqu'un click survient sur une ligne de la table -- //
            $('#table-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    gbTableSelectionLigne($(this));
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
                        var action_ajouter = (parseInt($('#form_id').val()) === 0);
                        
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

                    // -- Activer/Desactiver formulaire -- //
                    gbActiverDesactiverForm(form.attr('id'), false);

                    // -- Supprimer les validations parsley -- //
                    gbSupprimerMessageValidationForm(form.attr('id'));

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton de suppression -- //
        try {

            // -- Mise à jour de l'action de suppression -- //
            btn_supprimer.on("click",
                function () {
                    // -- Réccupérer les données electionné -- //
                    var selection = $('input[name="localisationActif"]:checked');

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
                        ids.push(selection[i].replace('localisationActif=localisationActif_', ''));
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

    }
);
