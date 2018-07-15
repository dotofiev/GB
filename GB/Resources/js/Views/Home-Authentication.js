
// -- Variables -- //
var form_mot_de_passe = $('#form_mot_de_passe');
var form_mot_de_passe_label = $('#form_mot_de_passe_label');
var form = $('#form');


// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Lorsque le formulaire d'authentification est soumis -- //
        try {

            form.on("submit",
                function (event) {

                    // -- Annuler l'action de soumission -- //
                    event.preventDefault();

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

        // -- Lorsqu'une nouvelle langue est selectionnée -- //
        try {

            $("#form_langue").on("change",
                function () {

                    // -- Variables -- //
                    var value = $(this).val();

                    // -- Recharger la page -- //
                    gbHref('/GB/Set_Langue/?id_lang=' + value);

                }
            );

        } catch (e) { gbConsole(e.message); }

        // -- Appeler le trigger de changement du mot de passe -- //
        try {

            //form_mot_de_passe.trigger('change');

        } catch (e) { gbConsole(e.message); }

        // -- Action l'arsqu'un click est effectué sur la page -- //
        try {

            /*
            $(document).on('keypress',
                function (e) {

                    // -- Si le champ mot de passe est focus -- //
                    if (form_mot_de_passe_label.hasClass('gb-focus')) {
                        // -- Variables -- //
                        var valeur = String.fromCharCode(e.which || e.keyCode);

                        // -- Si il faut reinitialiser le champ -- //
                        if (valeur === 'c') {
                            // -- Vider la mot de passe défini -- //
                            form_mot_de_passe.val('');
                            // -- Vider le label des mots de passe -- //
                            form_mot_de_passe_label.html('...');
                        }
                        // -- Incrémenter -- //
                        else {
                            // -- Si on incrémenter le mot de passe -- //
                            form_mot_de_passe.val(
                                form_mot_de_passe.val() + valeur
                            ).trigger('change');
                        }
                    }
                }
            );

            $(document).on('keydown',
                function (e) {

                    // -- Si le champ mot de passe est focus -- //
                    if (form_mot_de_passe_label.hasClass('gb-focus')) {
                        // -- Si il s'agit d'une suppression -- //
                        if (e.keyCode === 8) {
                            // -- Si on décrémenter le mot de passe -- //
                            form_mot_de_passe.val(form_mot_de_passe.val().slice(0, -1)).trigger('change');
                            // -- Mise à jour de la taille du label -- //
                            if (form_mot_de_passe.val() === undefined || form_mot_de_passe.val() === null || form_mot_de_passe.val() === '') {
                                // -- Vider le label des mots de passe -- //
                                form_mot_de_passe_label.html('...');
                            }
                        }
                    }
                }
            );
            */

        } catch (e) { gbConsole(e.message); }

    }
);
