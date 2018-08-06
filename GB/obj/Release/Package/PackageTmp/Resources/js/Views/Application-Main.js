
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Charger la page d'acceuil -- //
        try {

            // -- Frame chargement -- //
            gbAfficher_Page_Chargement(true);

            $("#conteneur").load(
                // -- Lien de chargement de la page -- //
                '/Application/Principale/',
                // -- Fonction à éxecuter à la fin du chargement de la page -- //
                function () {
                    // -- Frame chargement -- //
                    gbAfficher_Page_Chargement(false);
                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Lorsqu'on souhaite se déconnecter de l'application -- //
        $("#btn-deconnexion").on("click",
            function (event) {

                // -- Annuler l'action de soumission -- //
                event.preventDefault();

                // -- Variables -- //
                var form = $(this);

                // -- Frame chargement -- //
                gbAfficher_Page_Chargement(true);

                // -- Ajax -- //
                $.ajax({
                    type: "POST",
                    url: "/Home/Deconnexion",
                    //data: form.serialize(),
                    success: function (resultat) {
                        // -- Tester si le traitement s'est bien effectué -- //
                        if (resultat.notification.est_echec) {
                            // -- Message -- //
                            gbMessage_Box(resultat.notification);
                        } else {
                            // -- Redirection vers la page d'application -- //
                            gbHref(resultat.notification.donnee.url);
                        }
                        // -- Frame chargement -- //
                        gbAfficher_Page_Chargement(false);
                    },
                    error: function () {
                        // -- Frame chargement -- //
                        gbAfficher_Page_Chargement(false);
                        // -- Message -- //
                        gbMessage_Box();
                    }
                });

            }
        );

    }
);
