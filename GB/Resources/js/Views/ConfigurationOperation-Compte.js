
// -- Variables -- //
var table = $('#table-donnee');
var table_nouveau_compte = $('#table-nouveau_compte-donnee');
var btn_ajouter = $('#btn-ajouter');
var btn_supprimer = $('#btn-supprimer');
var btn_imprimmer = $('#btn-imprimmer');
var btn_enregistrer = $('#btn-enregistrer');
var btn_generation = $('#btn-generation');
var btn_sauvegarder = $('#btn-sauvegarder');
var btn_table;
var form = $('#form');
var form_generation = $('#form_generation');
var modal_form_generation = $('#modal_form');


// -- Méthodes d'action sur les données -- // 
try {

    // -- Modifier -- //
    function table_donnee_modifier(code) {

        // -- Ajax -- //
        $.ajax({
            type: "POST",
            url: $GB_DONNEE.Urls.url_ajax_selection_enregistrement,
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
                    $('#form_cle').val(resultat.notification.donnee.cle);
                    $('#form_nature').val(resultat.notification.donnee.nature);
                    $('#form_statut').val(resultat.notification.donnee.statut);
                    $('#form_id_devise').val(resultat.notification.donnee.id_devise);
                    $('#form_libelle_devise').val(resultat.notification.donnee.id_devise);
                    // -- Mise à jour du label du bouton d'enregistrement -- //
                    btn_enregistrer.html('<i class="fa fa-check"></i>' + $GB_DONNEE_PARAMETRES.Lang.Update);
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
            url: $GB_DONNEE.Urls.url_ajax_suppression_enregistrement,
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

    function table_nouveau_compte_donnee_supprimer(id) {

        try 
        {
            // -- Suppression de l'element dans l'objet JSSession -- //
            for (var i = 0; i <= table_nouveau_compte.DataTable().rows().data().length; i++) {
                // -- Vérifier l'element -- //
                if (table_nouveau_compte.DataTable().row(i).data().col_0 === id) {
                    // -- Supprimer l'element des nouveaux comptes -- //
                    $GB_DONNEE.Nouveaux_comptes.splice(i, 1);
                    // -- Supprimer l'element de la table -- //
                    table_nouveau_compte.DataTable().row(i).remove().draw(false);
                    // -- QUItter la boucle -- //
                    break;
                }
            }

        } catch (e) { gbConsole(e.message); }

    }

    // -- Réinitialiser le formulaire -- //
    function formulaire_reinitialiser() {

        try {

            // -- Reinitialiser le formulaire -- //
            form[0].reset();

            // -- Reinitialiser le id -- //
            $('#form_id').val(0);

            // -- Mise à jour du label du bouton d'enregistrement -- //
            btn_enregistrer.html('<i class="fa fa-check"></i>' + $GB_DONNEE_PARAMETRES.Lang.Save);

            // -- Activer/Desactiver formulaire -- //
            gbActiverDesactiverForm(form.attr('id'), false);

            // -- Supprimer les validations parsley -- //
            gbSupprimerMessageValidationForm(form.attr('id'));

        } catch (e) { gbConsole(e.message); }

    }

} catch (e) { gbConsole(e.message); }

// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Initialiser le message box de confirmation -- //
        try {

            $GB_DONNEE.Confirmation_message_box = false;
            $GB_DONNEE.Nouveaux_comptes = [];

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
                    gbCharger_Css_Table('compte');
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
                    "url": $GB_DONNEE.Urls.url_ajax_dataTable,
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
                    { "data": "col_4" },                            // -- cle -- //
                    { "data": "col_5" },                            // -- nature -- //
                    { "data": "col_6" },                            // -- statut -- //
                    { "data": "col_7" },                            // -- devise -- //
                    { "data": "col_8", "class": "text-center" },    // -- date_creation -- //
                    { "data": "col_9" },                            // -- utilisateur_createur -- //
                    { "data": "col_10", "class": "text-center" }    // -- Action -- //
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

            // -- Table d'affichage des données -- //
            table_nouveau_compte.DataTable({
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, $GB_DONNEE_PARAMETRES.Lang.All]],
                "scrollCollapse": true,
                "paging": true,
                "searching": true,
                "autoWidth": false,
                "keys": true,
                "language": {
                    "url": $GB_VAR.url_language_dataTable
                },
                "ajax": {
                    "url": $GB_DONNEE.Urls.url_ajax_dataTable + '&id_vue=nouveau_compte',
                    "type": 'POST',
                    "dataSrc": function (resultat) {
                        // -- Notifier -- //
                        gbNotificationListerRefuser(resultat.notification);
                        // -- Retourner les données -- //
                        return resultat.notification.donnee;
                    }
                },
                "columns": [
                    { "data": "col_0", "class": "hidden" },        // -- id -- //
                    //{ "data": "col_1", "width": "20px" },         // -- Checkbox -- //
                    { "data": "col_2" },                            // -- code -- //
                    { "data": "col_3" },                            // -- libelle -- //
                    { "data": "col_4" },                            // -- cle -- //
                    { "data": "col_5" },                            // -- nature -- //
                    { "data": "col_6" },                            // -- statut -- //
                    { "data": "col_7", "class": "text-center" }    // -- Action -- //
                ]
            })
            .on('key', function (e, datatable, key, cell, originalEvent) { })
            .on('key-focus', function (e, datatable, cell) {
                // -- Réccupérer la cellule dans le DOM -- //
                var td = gbDataTablesConvertCell_To_td(cell);
                // -- Déclencher le click -- //
                td.trigger('click');
                // -- Déclencher le focus -- //
                td.children().trigger('focus');
            })
            .on('key-blur', function (e, datatable, cell) {
                // -- Réccupérer la cellule dans le DOM -- //
                var td = gbDataTablesConvertCell_To_td(cell);
                // -- Perdre le focus pour les input -- //
                if (td.find('input').length != 0)
                {
                    td.find('input').blur();
                }
                // -- Quitter si c'est un select -- //
                else if (td.find('select').length != 0) {
                    td.find('select').change();
                }
            });

            // -- Lorsqu'un click survient sur une ligne de la table -- //
            $('#table-nouveau_compte-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    gbTableSelectionLigne($(this), 'table-nouveau_compte-donnee');
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
                        url: $GB_DONNEE.Urls.url_ajax_modification_enregistrement,
                        data: {
                            obj: JSON.stringify(form.gbConvertToJSON()),
                            id_page: $GB_DONNEE.id_page
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Réinitialiser le formulaire -- //
                                formulaire_reinitialiser();
                                // -- Actualiser la table -- //
                                gbRechargerTable(false);
                            }
                            else {
                                // -- Afficher une alerte sur un element -- //
                                gbMessage_Box(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_enregistrer.attr('id'));
                        },
                        error: function () {
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_enregistrer.attr('id'));
                            // -- Afficher une alerte sur un element -- //
                            gbMessage_Box();
                        }
                    });

                }
            );

            // -- Soumet le formulaire -- //
            form_generation.on("submit",
                function (e) {
                    // -- Désactiver la soumission -- //
                    e.preventDefault();

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true, btn_generation.attr('id'));

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: $GB_DONNEE.Urls.url_ajax_ajout_enregistrement,
                        data: {
                            obj: JSON.stringify(form_generation.gbConvertToJSON()),
                            id_page: $GB_DONNEE.id_page
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Actualiser la table -- //
                                gbRechargerTable(false, null, table_nouveau_compte.attr('id'), null);
                                // -- Réccupérer les comptes -- //
                                $GB_DONNEE.Nouveaux_comptes = resultat.notification.donnee;
                            }
                            else {
                                // -- Afficher une alerte sur un element -- //
                                gbAlert(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_generation.attr('id'));
                        },
                        error: function () {
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_generation.attr('id'));
                            // -- Afficher une alerte sur un element -- //
                            gbAlert();
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Comportement lorsque le modal du formulaire se ferme -- //
        try {

            modal_form_generation.on('hidden.bs.modal',
                function (e) {

                    // -- Reinitialiser le formulaire -- //
                    form_generation[0].reset();

                    // -- Suppression de l'alert message box -- //
                    $('#gbAlert').html(null);

                    // -- Suppression de l'alert de confirmation -- //
                    $('#dsAlert_Message_Box').html(null);

                    // -- Activer/Desactiver formulaire -- //
                    gbActiverDesactiverForm(form_generation.attr('id'), false);

                    // -- Supprimer les validations parsley -- //
                    gbSupprimerMessageValidationForm(form_generation.attr('id'));

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton de suppression -- //
        try {

            // -- Mise à jour de l'action de suppression -- //
            btn_supprimer.on("click",
                function () {
                    // -- Réccupérer les données electionné -- //
                    var selection = $('input[name="compte"]:checked');

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
                        ids.push(selection[i].replace('compte=compte_', ''));
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

        // -- Action du bouton nouveau -- //
        try {

            // -- Initialiser les données temporaire des comptes -- //
            btn_ajouter.on("click",
                function () {

                    // -- Afficher le modal -- //
                    modal_form_generation.modal('show');

                    // -- Vider la table -- //
                    table_nouveau_compte
                        .DataTable()
                        .clear()
                        .draw();

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton de sauvegarde des comptes enregistrés -- //
        try {

            // -- Initialiser les données temporaire des comptes -- //
            btn_sauvegarder.on("click",
                function () {

                    // -- Si la taille est supérieurs à 0 -- //
                    if ($GB_DONNEE.Nouveaux_comptes.length == 0) {
                        // -- Afficher message d'erreur -- //
                        gbAlert({ est_echec: true, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected });
                        // -- Annuler l'action -- //
                        return false;
                    }

                    // -- Message d'erreur potentiel -- //
                    var message = '<ul>';
                    // -- Valider les données -- //
                    for (var i = 0; i < $GB_DONNEE.Nouveaux_comptes.length; i++)
                    {
                        // -- Si le libelle n'est pas modifié -- //
                        if ($GB_DONNEE.Nouveaux_comptes[i].libelle == null || $GB_DONNEE.Nouveaux_comptes[i].libelle == '') {
                            message +=
                                '<li>' +
                                    $GB_DONNEE.Lang.Account + ' <b>' + $GB_DONNEE.Nouveaux_comptes[i].code + '</b> : <i>' +
                                    $GB_DONNEE.Lang.Required_field + ' [' + $GB_DONNEE.Lang.Name + ']</i>' +
                                '</li>';
                        }
                        // -- Si les champs du compte 10 ne sont pas soumis -- //
                        if ($GB_DONNEE.Nouveaux_comptes[i].code != null && $GB_DONNEE.Nouveaux_comptes[i].code.length == 10)
                        {
                            // -- Si le cle n'est pas modifié -- //
                            if ($GB_DONNEE.Nouveaux_comptes[i].cle == null || $GB_DONNEE.Nouveaux_comptes[i].cle == '') {
                                message +=
                                    '<li>' +
                                        $GB_DONNEE.Lang.Account + ' <b>' + $GB_DONNEE.Nouveaux_comptes[i].code + '</b> : <i>' +
                                        $GB_DONNEE.Lang.Required_field + ' [' + $GB_DONNEE.Lang.Key + ']</i>' +
                                    '</li>';
                            }
                            // -- Si le nature n'est pas modifié -- //
                            if ($GB_DONNEE.Nouveaux_comptes[i].nature == null || $GB_DONNEE.Nouveaux_comptes[i].nature == '') {
                                message +=
                                    '<li>' +
                                        $GB_DONNEE.Lang.Account + ' <b>' + $GB_DONNEE.Nouveaux_comptes[i].code + '</b> : <i>' +
                                        $GB_DONNEE.Lang.Required_field + ' [' + 'Nature' + ']</i>' +
                                    '</li>';
                            }
                            // -- Si le statut n'est pas modifié -- //
                            if ($GB_DONNEE.Nouveaux_comptes[i].statut == null || $GB_DONNEE.Nouveaux_comptes[i].statut == '') {
                                message +=
                                    '<li>' +
                                        $GB_DONNEE.Lang.Account + ' <b>' + $GB_DONNEE.Nouveaux_comptes[i].code + '</b> : <i>' +
                                        $GB_DONNEE.Lang.Required_field + ' [' + $GB_DONNEE.Lang.Status + ']</i>' +
                                    '</li>';
                            }
                        }
                        // -- Vider les champs non autorisé -- //
                        else {
                            $GB_DONNEE.Nouveaux_comptes[i].cle = ''
                            $GB_DONNEE.Nouveaux_comptes[i].nature = ''
                            $GB_DONNEE.Nouveaux_comptes[i].statut = '';
                        }
                    }
                    // -- fermeture du message d'erreur potentiel -- //
                    message += '</ul>';

                    if (message != '<ul></ul>') {
                        // -- Afficher message d'erreur -- //
                        gbAlert({ est_echec: true, message: message });
                        // -- Annuler l'action -- //
                        return false;
                    }

                    // -- Ecouter la réponse du message de confirmation -- //
                    if (!$GB_DONNEE.Confirmation_message_box) {
                        // -- Afficher le message d'action -- //
                        gbConfirmationAlert_OuiOuNon(
                            null, null, null,
                            function () {
                                btn_sauvegarder.trigger('click');
                            }
                        );
                        // -- Annuler l'action -- //
                        return false;
                    }

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true, btn_sauvegarder.attr('id'));

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: $GB_DONNEE.Urls.url_controlleur + 'Compte_Enregistrer_Nouveau_Compte',
                        data: {
                            obj: JSON.stringify($GB_DONNEE.Nouveaux_comptes)
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Actualiser la table -- //
                                gbRechargerTable(false);
                                // -- Réccupérer les comptes -- //
                                $GB_DONNEE.Nouveaux_comptes = [];
                                // -- Fermer le modal -- //
                                modal_form_generation.modal('hide');
                            } else {
                                // -- Message -- //
                                gbAlert(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_sauvegarder.attr('id'));
                        },
                        error: function () {
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false, btn_sauvegarder.attr('id'));
                            // -- Message -- //
                            gbAlert();
                        }
                    });
                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action du bouton de soumission du formulaire de modification -- //
        try {

            btn_enregistrer.on("click",
                function () {

                    // -- Vérifier que le formulaire est en mode modifier -- //
                    if (parseInt($('#form_id').val()) === 0) {
                        // -- Afficher une alerte sur un element -- //
                        gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected });
                        // -- Annuler l'action -- //
                        return false;
                    }

                    // -- Soumettre le formulaire -- //
                    form.submit();
                    
                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Définition des champs modifiable de la table -- // 
        try {

            table_nouveau_compte.DataTable()
                .MakeCellsEditable({
                    "onUpdate": function (cell, row, ancienne_valeur) {
                        var nouvelle_valeur = cell.data();
                        var x = cell.index().column;
                        var y = cell.index().row;
                        var ligne = row.data();

                        // -- Mise à jour en fonction de l'index -- //
                        if (x == 2) {
                            $GB_DONNEE.Nouveaux_comptes[y].libelle = nouvelle_valeur;
                        }
                        else if (x == 3) {
                            // -- Réccupérer le premier caractère et le mettre en majuscule -- //
                            var premier_caractere = nouvelle_valeur.toString().substr(0, 1).toUpperCase();
                            $GB_DONNEE.Nouveaux_comptes[y].cle = premier_caractere;
                            // -- Mise à jour de la table -- //
                            cell.data(premier_caractere).draw();
                        }
                        else if (x == 4) {
                            $GB_DONNEE.Nouveaux_comptes[y].nature = nouvelle_valeur;
                        }
                        else if (x == 5) {
                            $GB_DONNEE.Nouveaux_comptes[y].statut = nouvelle_valeur;
                        }

                        // -- Ne pas autorisé la modification des clé, nature et statut pour les comptes non 10 -- //
                        if (x != 2 && ligne.col_2.length != 10) {
                            // -- Vérifier l'element -- //
                            if (table_nouveau_compte.DataTable().row(y).data().col_0 === ligne.col_0) {
                                // -- Reset de la valeur -- //
                                if (x == 3) {
                                    $GB_DONNEE.Nouveaux_comptes[y].cle = '';
                                }
                                else if (x == 4) {
                                    $GB_DONNEE.Nouveaux_comptes[y].nature = '';
                                }
                                else if (x == 5) {
                                    $GB_DONNEE.Nouveaux_comptes[y].statut = '';
                                }
                                // -- Mise à jour de la table -- //
                                cell.data('').draw();
                            }
                        }
                    },
                    "inputCss": 'form-control input-sm gb-color-black',
                    "columns": [2, 3, 4, 5],
                    "allowNulls": {
                        "columns": [2, 3, 4, 5],
                        "errorClass": 'error'
                    },
                    "inputTypes": [
                        {
                            "column": 2,
                            "type": "text",
                            "options": null
                        },
                        {
                            "column": 3,
                            "type": "text",
                            "options": null
                        },
                        {
                            "column": 4,
                            "type": "list",
                            "options": [
                                { "value": "",          "display": $GB_DONNEE.Lang.Not_required },
                                { "value": "Credit",    "display": $GB_DONNEE.Lang.Credit },
                                { "value": "Debit",     "display": $GB_DONNEE.Lang.Debit },
                                { "value": "Both",      "display": $GB_DONNEE.Lang.Both }
                            ]
                        },
                        {
                            "column": 5,
                            "type": "list",
                            "options": [
                                { "value": "",      "display": $GB_DONNEE.Lang.Not_required },
                                { "value": "Close", "display": $GB_DONNEE.Lang.Close },
                                { "value": "Open",  "display": $GB_DONNEE.Lang.Open }
                            ]
                        }
                    ]
                }
            );

        } catch (e) { gbConsole(e.message); }

    }
);