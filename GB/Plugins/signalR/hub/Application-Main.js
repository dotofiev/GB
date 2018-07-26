
$(
    function () {

        // -- Generation du proxy hub coté client -- //
        var applicationMainHub = $.connection.applicationMainHub;

        // -- Fonction de la la mise à jour des lors de la connexion d'un utilisateur -- //
        applicationMainHub.client.deconnecterClient = function (notification) {
            // -- Notifier -- //
            gbNotification(notification);
            // -- Appuyer sur le bouton de déconnexion -- //
            $("#btn-deconnexion").trigger('click');
        }

        // -- Fonction de la la mise à jour du connectionId dans l'objet session du client -- //
        applicationMainHub.client.chargerConnectionIdClient = function (notification) {
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

        // -- Demmarrage de la connexion -- //
        $.connection.hub.start()
            //.pipe(init)
            //.pipe(
            //    function () {
            //        return applicationMainHub.server.getMessageSizeConnected();
            //    }
            //)
            .done(
                function () {
                    $(document).ready(
                        function () {
                            //applicationMainHub.server.notificationMaConnexion();
                        }
                    );
                }
            );

    }
);