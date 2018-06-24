
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

                    // -- Frame chargement -- //
                    gbAfficher_Page_Chargement(true, 'btn_authentifier');

                    // -- Ajax -- //
                    $.ajax({
                        type: "POST",
                        url: "/Home/Connexion",
                        data: form.serialize(),
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
                            gbAfficher_Page_Chargement(false, 'btn_authentifier');
                        },
                        error: function () {
                            // -- Frame chargement -- //
                            gbAfficher_Page_Chargement(false, 'btn_authentifier');
                            // -- Message -- //
                            gbMessage_Box();
                        }
                    });

                }
            );

        } catch (e) { gbConsole(e.message); }

    }
);
