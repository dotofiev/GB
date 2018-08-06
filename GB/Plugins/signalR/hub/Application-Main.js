
$(
    function () {

        // -- Generation du proxy hub coté client -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub = $.connection.applicationMainHub;

        // -- Fonction de la la mise à jour des lors de la connexion d'un utilisateur -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub.client.deconnecterClient = function (notification) {
            // -- Notifier -- //
            gbNotification(notification);
            // -- Appuyer sur le bouton de déconnexion -- //
            $("#btn-deconnexion").trigger('click');
        }

        // -- Fonction de la la mise à jour du connectionId dans l'objet session du client -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub.client.chargerConnectionIdClient = function (notification) {
            // -- Ajax -- //
            $.ajax({
                type: "POST",
                url: "/Home/Charger_ConnectionId_Client",
                data: {
                    connectionId: notification.donnee
                },
                success: function (resultat) {
                    // -- Tester si le traitement s'est bien effectué -- //
                    if (resultat.notification.est_echec) {
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

        // -- Fonction de mise à jour de tous les combox box chez les clients -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub.client.rechargerCombo = function (notification) {
            try {
                // -- Mise à jour des données sur le formulaire si ceux ci existe -- //
                if ($(notification.donnee.form_id).length != 0) {
                    $(notification.donnee.form_id).html(notification.donnee.select_code);
                }
                if ($(notification.donnee.form_libelle).length != 0) {
                    $(notification.donnee.form_libelle).html(notification.donnee.select_libelle);
                }
            }
            catch (e) { gbConsoleStringify(e); }
        }

        // -- Fonction de mise à jour de toutes les tables chez les clients -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub.client.rechargerTable = function (notification) {
            try {
                // -- Vérifier que le client est sur la page active -- //
                if ($GB_DONNEE.id_page === notification.donnee.id_page) {
                    gbRechargerTable(false);
                }
            }
            catch (e) { gbConsoleStringify(e); }
        }

        // -- Fonction de mise à jour de tous les combox box ComboEasyAutocomplete chez les clients -- //
        $GB_DONNEE_PARAMETRES.applicationMainHub.client.rechargerComboEasyAutocomplete = function (notification) {
            try {
                // -- Mise à jour des données sur le formulaire si tout ceux ci existe -- //
                if ($(notification.donnee.form_id).length != 0 && $(notification.donnee.form_code).length != 0 && $(notification.donnee.form_libelle).length != 0) {
                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: $GB_DONNEE.Urls.url_ajax_recharger_easyAutocomplete,
                        data: {
                            id_vue: notification.donnee.id_vue
                        },
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (resultat.notification.est_echec) {
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
            }
            catch (e) { gbConsoleStringify(e); }
        }

        // -- Demmarrage de la connexion -- //
        $.connection.hub.start()
            //.pipe(init)
            //.pipe(
            //    function () {
            //        return $GB_DONNEE_PARAMETRES.applicationMainHub.server.getMessageSizeConnected();
            //    }
            //)
            .done(
                function () {
                    $(document).ready(
                        function () {
                            //$GB_DONNEE_PARAMETRES.applicationMainHub.server.notificationMaConnexion();
                        }
                    );
                }
            );

    }
);