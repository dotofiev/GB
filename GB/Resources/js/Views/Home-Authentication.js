
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Affichier le progress bar -- //
        try {

            // -- Lorsqu'une nouvelle langue est selectionnée -- //
            $("#langue").on("change",
                function () {

                    // -- Variables -- //
                    var value = $(this).val();

                    // -- Recharger la page -- //
                    gbHref('/GB/Set_Langue/?id_lang=' + value);

                }
            );

            // -- Lorsque le formulaire d'authentification est soumis -- //
            $("#auth_form").on("submit",
                function (event) {

                    // -- Annuler l'action de soumission -- //
                    event.preventDefault();
                    
                    // -- Variables -- //
                    var form = $(this);

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: "/Home/Connexion",
                        data: form.serialize(),
                        success: function (resultat) {
                            // -- Tester si le traitement s'est bien effectué -- //
                            if (resultat.notification.est_echec) {
                                // -- Message -- //
                                gbMessage_Box('danger', resultat.notification.message);
                            } else {
                                // -- Redirection vers la page d'application -- //
                                gbHref(resultat.notification.donnee.url);
                            }
                        },
                        error: function () {
                            // -- Message -- //
                            gbMessage_Box(null, null);
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

    }
);
