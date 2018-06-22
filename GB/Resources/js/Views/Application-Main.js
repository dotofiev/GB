
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Lorsqu'on souhaite se déconnecter de l'application -- //
        $("#btn-deconnexion").on("click",
            function (event) {

                // -- Annuler l'action de soumission -- //
                event.preventDefault();

                // -- Variables -- //
                var form = $(this);

                // -- Frame chargement -- //
                gbAfficher_Page_Chargement(true, null);

                // -- Ajax -- //
                $.ajax({
                    type: "POST",
                    url: "/Home/Deconnexion",
                    //data: form.serialize(),
                    success: function (resultat) {
                        // -- Tester si le traitement s'est bien effectué -- //
                        if (resultat.notification.est_echec) {
                            // -- Message -- //
                            gbMessage_Box('danger', resultat.notification.message);
                        } else {
                            // -- Redirection vers la page d'application -- //
                            gbHref(resultat.notification.donnee.url);
                        }
                        // -- Frame chargement -- //
                        gbAfficher_Page_Chargement(false, null);
                    },
                    error: function () {
                        // -- Frame chargement -- //
                        gbAfficher_Page_Chargement(false, null);
                        // -- Message -- //
                        gbMessage_Box(null, null);
                    }
                });

            }
        );

    }
);
