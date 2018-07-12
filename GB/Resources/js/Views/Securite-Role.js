
// -- Variables -- //
var table = $('#table-donnee');
var table_configuration = $('#table-configuration-donnee');
var table_menu = $('#table-menu-donnee');
var url_ajax_dataTable = '/Securite/Charger_Table/?id_page=' + $GB_DONNEE.id_page;
var url_ajax_selection_enregistrement = '/Securite/Selection_Enregistrement/';
var btn_ajouter = $('#btn-ajouter');
var btn_supprimer = $('#btn-supprimer');
var btn_imprimmer = $('#btn-imprimmer');
var btn_enregistrer = $('#btn-enregistrer');
var btn_rechercher_role = $('#btn-configuration-rechercher-role');
var btn_selectionner_menu = $('#btn-configuration-selectionner');
var btn_ajouter_menu = $('#btn-autorisation-ajouter-menu');
var btn_supprimer_menu = $('#btn-autorisation-supprimer-menu');
var btn_synchronisation_autorisation = $('#btn-autorisation-enregistrer');
var btn_table;
var form = $('#form');
var form_configuration = $('#form-configuration');
var modal_form = $('#modal_form');
var modal_menu = $('#modal_menu');
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

    // -- Mise à jour objet du panie menu -- //
    function panier_menu_mise_a_jour(action, id_menu, etat) {

        // -- Vérifier les paramètres -- //
        if (action != undefined && action != null && id_menu != undefined && id_menu != null) {
            // -- Parcourir la liste -- //
            for (var i = 0; i <= $GB_DONNEE.Panier_menu.length; i++) {
                // -- Vérifier l'element -- //
                if ($GB_DONNEE.Panier_menu[i].id_menu != undefined && $GB_DONNEE.Panier_menu[i].id_menu === id_menu) {
                    // -- Mettre à jour l'objet -- //
                    if (action === 'ajouter') {
                        $GB_DONNEE.Panier_menu[i].ajouter = etat;
                    }
                    else if (action === 'modifier') {
                        $GB_DONNEE.Panier_menu[i].modifier = etat;
                    }
                    else if (action === 'supprimer') {
                        $GB_DONNEE.Panier_menu[i].supprimer = etat;
                    }
                    else if (action === 'imprimer') {
                        $GB_DONNEE.Panier_menu[i].imprimer = etat;
                    }
                    else if (action === 'lister') {
                        $GB_DONNEE.Panier_menu[i].lister = etat;
                    }
                    // -- QUItter la boucle -- //
                    break;
                }
            }
        }

    }

} catch (e) { gbConsole(e.message); }

// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Initialiser le message box de confirmation -- //
        try {

            $GB_DONNEE.Confirmation_message_box = false;
            $GB_DONNEE.Panier_menu = [];

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
                    gbCharger_Css_Table('role');
                }
            );
            table_configuration.on('draw.dt',
                function () {
                    // -- Fonction pour initiliser les style css javascript des tables -- //
                    gbCharger_Css_Table('autorisation', 'check-configuration-all', 'table-configuration-donnee');
                }
            );
            table_menu.on('draw.dt',
                function () {

                    // -- Fonction pour initiliser les style css javascript des tables -- //
                    gbCharger_Css_Table('menu', 'check-menu-all', 'table-menu-donnee');
                                        
                    try {

                        // -- Lorsque un élement de la liste est sélectionné -- //
                        $('#table-menu-donnee .flat').on('ifChecked',
                            function () {
                                // -- Réccupérer l'identifiant -- //
                                var id_menu = $(this).attr('id_menu');
                                // -- Annuler l'action si le id_menu n'est pas défini -- //
                                if (id_menu === undefined || id_menu === null || id_menu === '') {
                                    return false;
                                }
                                // -- Ajouter dans le panie menu -- //
                                $GB_DONNEE.Panier_menu.push({
                                    id_menu     : id_menu,
                                    ajouter     : $('input[name="ajouter"][id_menu="'   + id_menu + '"].flat-blue').attr("etat"),
                                    modifier    : $('input[name="modifier"][id_menu="'  + id_menu + '"].flat-blue').attr("etat"),
                                    supprimer   : $('input[name="supprimer"][id_menu="' + id_menu + '"].flat-blue').attr("etat"),
                                    imprimer    : $('input[name="imprimer"][id_menu="'  + id_menu + '"].flat-blue').attr("etat"),
                                    lister      : $('input[name="lister"][id_menu="'    + id_menu + '"].flat-blue').attr("etat"),
                                });
                                // -- Mise à jour de la valeur -- //
                                $(this).attr('etat', 'true');
                            }
                        );

                        // -- Lorsque un élement de la liste est désélectionné -- //
                        $('#table-menu-donnee .flat').on('ifUnchecked',
                            function () {
                                // -- Réccupérer l'identifiant -- //
                                var id_menu = $(this).attr('id_menu');
                                // -- Annuler l'action si le id_menu n'est pas défini -- //
                                if (id_menu === undefined || id_menu === null || id_menu === '') { return false; }
                                // -- Parcourir la liste -- //
                                for (var i = 0; i <= $GB_DONNEE.Panier_menu.length; i++) {
                                    // -- Vérifier l'element -- //
                                    if ($GB_DONNEE.Panier_menu[i].id_menu === id_menu) {
                                        // -- Supprimer l'element -- //
                                        $GB_DONNEE.Panier_menu.splice(i, 1);
                                        // -- QUItter la boucle -- //
                                        break;
                                    }
                                }
                                // -- Mise à jour de la valeur -- //
                                $(this).attr('etat', 'false');
                                // -- Désactiver tous les elements actif -- //
                                $('input[etat="true"][id_menu="' + id_menu + '"].flat-blue').iCheck('uncheck');
                            }
                        );

                        // -- Lorsque un élement de la liste de menus est sélectionné -- //
                        $('#table-menu-donnee .flat-blue').on('ifChecked',
                            function () {
                                // -- Réccupérer l'identifiant -- //
                                var id_menu = $(this).attr('id_menu');
                                // -- Annuler l'action si le id_menu n'est pas défini -- //
                                if (id_menu === undefined || id_menu === null || id_menu === '') { return false; }
                                // -- Mise à jour de la valeur -- //
                                $(this).attr('etat', 'true');
                                // -- Réccupéler le check de la ligne -- //
                                var check_ligne = $('input[id_menu="' + id_menu + '"].flat');
                                // -- Check la ligne si celui ci ne l'est pas encore -- //
                                if (check_ligne.attr('etat') === 'false') {
                                    // -- Activer -- //
                                    check_ligne.iCheck('check');
                                }
                                else {
                                    // -- Mettre à jour la valeur de l'objet en mémoire -- //
                                    panier_menu_mise_a_jour($(this).attr('name'), id_menu, true);
                                }
                            }
                        );

                        // -- Lorsque un élement de la liste de menus est désélectionné -- //
                        $('#table-menu-donnee .flat-blue').on('ifUnchecked',
                            function () {
                                // -- Réccupérer l'identifiant -- //
                                var id_menu = $(this).attr('id_menu');
                                // -- Annuler l'action si le id_menu n'est pas défini -- //
                                if (id_menu === undefined || id_menu === null || id_menu === '') { return false; }
                                // -- Mise à jour de la valeur -- //
                                $(this).attr('etat', 'false');
                                // -- Réccupéler le check de la ligne -- //
                                var check_ligne = $('input[id_menu="' + id_menu + '"].flat');
                                // -- Check la ligne si celui ci ne l'est pas encore -- //
                                if (check_ligne.attr('etat') === 'true' && $('input[etat="true"][id_menu="' + id_menu + '"].flat-blue').length === 0) {
                                    // -- Désactiver -- //
                                    check_ligne.iCheck('uncheck');
                                }
                                else {
                                    // -- Mettre à jour la valeur de l'objet en mémoire -- //
                                    panier_menu_mise_a_jour($(this).attr('name'), id_menu, false);
                                }
                            }
                        );

                    } catch (e) { gbConsole(e.message); }
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
                    { "data": "col_3" },                            // -- libelle_fr -- //
                    { "data": "col_4" },                            // -- libelle_en -- //
                    { "data": "col_5", "class": "text-center" }     // -- Action -- //
                ]
            });
            table_configuration.DataTable({
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, $GB_DONNEE_PARAMETRES.Lang.All]],
                "scrollCollapse": true,
                "paging": true,
                "searching": true,
                "autoWidth": false,
                "language": {
                    "url": $GB_VAR.url_language_dataTable
                },
                "ajax": {
                    "url": url_ajax_dataTable + '&id_vue=autorisation',
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
                    { "data": "col_4", "class": "text-center" },    // -- Ajouter -- //
                    { "data": "col_5", "class": "text-center" },    // -- Modifier -- //
                    { "data": "col_6", "class": "text-center" },    // -- Supprimer -- //
                    { "data": "col_7", "class": "text-center" },    // -- Imprimer -- //
                    { "data": "col_8", "class": "text-center" },    // -- Lister -- //
                ]
            });
            table_menu.DataTable({
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, $GB_DONNEE_PARAMETRES.Lang.All]],
                "scrollCollapse": true,
                "paging": true,
                "searching": true,
                "autoWidth": false,
                "language": {
                    "url": $GB_VAR.url_language_dataTable
                },
                "ajax": {
                    "url": url_ajax_dataTable + '&id_vue=menu',
                    "type": 'POST',
                    "dataSrc": function (resultat) {
                        // -- Initialiser le panier menu -- //
                        $GB_DONNEE.Panier_menu = [];
                        // -- Notifier -- //
                        gbNotificationListerRefuser(resultat.notification);
                        // -- Retourner les données -- //
                        return resultat.notification.donnee;
                    }
                },
                "columns": [
                    { "data": "col_1", "width": "20px" },           // -- Checkbox -- //
                    { "data": "col_2" },                            // -- libelle -- //
                    { "data": "col_3" },                            // -- groupe_menu -- //
                    { "data": "col_4" },                            // -- module -- //
                    { "data": "col_5", "class": "text-center" },                            // -- ajouter -- //
                    { "data": "col_6", "class": "text-center" },                            // -- modifier -- //
                    { "data": "col_7", "class": "text-center" },                            // -- suprimer -- //
                    { "data": "col_8", "class": "text-center" },                            // -- imprimer -- //
                    { "data": "col_9", "class": "text-center" },                            // -- lister -- //
                ]
            });

            // -- Lorsqu'un click survient sur une ligne de la table -- //
            $('#table-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    gbTableSelectionLigne($(this));
                }
            );
            $('#table-configuration-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    gbTableSelectionLigne($(this), 'table-configuration-donnee');
                }
            );
            $('#table-menu-donnee tbody').on('click', 'tr',
                function () {
                    // -- Selectionner une ligne de la table -- //
                    gbTableSelectionLigne($(this), 'table-menu-donnee');
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
            form_configuration.on("submit",
                function (e) {
                    // -- Désactiver la soumission -- //
                    e.preventDefault();

                    // -- Variables -- //
                    form_configuration.parsley().validate();

                    // If the form is valid
                    if (form_configuration.parsley().isValid()) {

                        // -- Afficher le chargement -- //
                        gbAfficher_Page_Chargement(true, btn_rechercher_role.attr('id'));

                        // -- Ajax -- //
                        $.ajax({
                            type: "POST",
                            url: url_controlleur + 'Role_Rechercher_Autorisation',
                            data: form_configuration.serialize(),
                            success: function (resultat) {
                                // -- Tester si le traitement s'est bien effectué -- //
                                if (!resultat.notification.est_echec) {
                                    // -- Actualiser la table -- //
                                    gbRechargerTable(false, 'check-configuration-all', 'table-configuration-donnee');
                                    gbRechargerTable(false, 'check-menu-all', 'table-menu-donnee');
                                    // -- Activer les bouton de gestion des privilèges -- //
                                    $('.gb-temps-btn-action-menu').prop('disabled', false);
                                }
                                else {
                                    // -- Afficher une alerte sur un element -- //
                                    gbMessage_Box(resultat.notification);
                                }
                                // -- Afficher le chargement -- //
                                gbAfficher_Page_Chargement(false, btn_rechercher_role.attr('id'));
                            },
                            error: function () {
                                // -- Afficher le chargement -- //
                                gbAfficher_Page_Chargement(false, btn_rechercher_role.attr('id'));
                                // -- Afficher une alerte sur un element -- //
                                gbMessage_Box();
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
                    var selection = $('input[name="role"]:checked');

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
                        ids.push(selection[i].replace('role=role_', ''));
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

        // -- Action de lactivation/désactivation d'une action-- //
        try {

            $('.btn-group .gbtemp').on("click",
                function () {

                    // -- Réccupérer les données electionné -- //
                    var ids = gbSelectionIdsTable('autorisation');

                    // -- Si la taille est supérieurs à 0 -- //
                    if (ids.length == 0) {
                        // -- Afficher message d'erreur -- //
                        gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected });

                        return false;
                    }

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true);

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: url_controlleur + 'Role_Modifier_Autorisation',
                        data: {
                            ids: JSON.stringify(ids),
                            id_action: $(this).attr('name').split(',')[0],
                            etat: $(this).attr('name').split(',')[1],
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Recharger la table -- //
                                gbRechargerTable(false, 'check-configuration-all', 'table-configuration-donnee');
                            } else {
                                // -- Message -- //
                                gbMessage_Box(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        },
                        error: function () {
                            // -- Message -- //
                            gbMessage_Box();
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action de selection des menus à ajouter -- //
        try {

            btn_selectionner_menu.on("click",
                function () {
                    // -- Réccupération des positions des objets à supprimer -- //
                    var id_menus = [];
                    for (var i = 0; i < $GB_DONNEE.Panier_menu.length; i++) {
                        if ($GB_DONNEE.Panier_menu[i].id_menu != undefined &&
                            ($GB_DONNEE.Panier_menu[i].ajouter === 'false' && $GB_DONNEE.Panier_menu[i].modifier === 'false' &&
                             $GB_DONNEE.Panier_menu[i].supprimer === 'false' && $GB_DONNEE.Panier_menu[i].imprimer === 'false' && $GB_DONNEE.Panier_menu[i].lister === 'false'))
                        {
                            // -- Enregistrer la position -- //
                            id_menus.push($GB_DONNEE.Panier_menu[i].id_menu);
                        }
                    }
                    // -- Parcours des positions et suppressio ndes elements -- //
                    for (var i = 0; i < id_menus.length; i++)
                    {
                        // -- Supprimer l'element -- //
                        $('input[id_menu="' + id_menus[i] + '"].flat').iCheck('uncheck');
                    }
                    // -- Si la taille est supérieurs à 0 -- //
                    if ($GB_DONNEE.Panier_menu.length === 0) {
                        // -- Afficher message d'erreur -- //
                        gbAlert({ est_echec: true, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected }, 'gbAlert2');

                        return false;
                    }

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true);

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: url_controlleur + 'Role_Ajouter_Supprimer_Menu',
                        data: {
                            data: JSON.stringify($GB_DONNEE.Panier_menu),
                            ajouter: true
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Fermer le modal -- //
                                modal_menu.modal('hide');
                                // -- Recharger la table -- //
                                gbRechargerTable(false, 'check-configuration-all', 'table-configuration-donnee');
                                gbRechargerTable(false, 'check-menu-all', 'table-menu-donnee');
                            } else {
                                // -- Message -- //
                                gbAlert(resultat.notification, 'gbAlert2');
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        },
                        error: function () {
                            // -- Message -- //
                            gbAlert(null, 'gbAlert2');
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action de selection des menus à supprimer -- //
        try {

            btn_supprimer_menu.on("click",
                function () {

                    // -- Réccupérer les données electionné -- //
                    var ids = gbSelectionIdsTable('autorisation');

                    // -- Si la taille est supérieurs à 0 -- //
                    if (ids.length == 0) {
                        // -- Afficher message d'erreur -- //
                        gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.No_item_selected });

                        return false;
                    }

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true);

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: url_controlleur + 'Role_Ajouter_Supprimer_Menu',
                        data: {
                            data: JSON.stringify(ids),
                            ajouter: false
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Fermer le modal -- //
                                modal_menu.modal('hide');
                                // -- Recharger la table -- //
                                gbRechargerTable(false, 'check-configuration-all', 'table-configuration-donnee');
                                gbRechargerTable(false, 'check-menu-all', 'table-menu-donnee');
                            } else {
                                // -- Message -- //
                                gbMessage_Box(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        },
                        error: function () {
                            // -- Message -- //
                            gbMessage_Box();
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Action d'enregistrement des modifications survenue sur les autorisations -- //
        try {

            btn_synchronisation_autorisation.on("click",
                function () {

                    // -- Ecouter la réponse du message de confirmation -- //
                    if (!$GB_DONNEE.Confirmation_message_box) {
                        // -- Afficher le message d'action -- //
                        gbConfirmation_OuiOuNon(null, null, function () { btn_synchronisation_autorisation.trigger('click'); });
                        // -- Annuler l'action -- //
                        return false;
                    }

                    // -- Afficher le chargement -- //
                    gbAfficher_Page_Chargement(true);

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: url_controlleur + 'Role_Enregistrer_Modification',
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (!resultat.notification.est_echec) {
                                // -- Notification -- //
                                gbNotification(resultat.notification);
                            } else {
                                // -- Message -- //
                                gbMessage_Box(resultat.notification);
                            }
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        },
                        error: function () {
                            // -- Message -- //
                            gbMessage_Box();
                            // -- Afficher le chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }        

        // -- Appliquer le icheck sur tous les elements flat de la page -- //
        try {

            // -- Green -- //
            if ($("input.flat")[0]) {
                $('input.flat').iCheck({
                    checkboxClass: 'icheckbox_flat-green',
                    radioClass: 'iradio_flat-green'
                });
            }

        } catch (e) { gbConsole(e.message); }

        // -- Désactiver tous les bouton d'action -- //
        try {

            $('.gb-temps-btn-action-menu').prop('disabled', true);

        } catch (e) { gbConsole(e.message); }

    }
);
