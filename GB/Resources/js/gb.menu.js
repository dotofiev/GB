
// -- Lorsque le document est chargé -- //
$(function () {

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

    // -- Lorsqu'un menu est cliqué -- //
    $('.menu-gb').on("click",

        function (event) {

            // -- Annuler l'action de soumission -- //
            event.preventDefault();

            try {

                // -- Variables -- //
                var url = $(this).attr('name');
                var id = $(this).attr('id');

                // -- Check menu autorisé -- //
                if (url != '/Securite/Module') {
                    // -- Message -- //
                    gbMessage_Box({ est_echec: null, message: $GB_DONNEE_PARAMETRES.Lang.Maintenance_message });

                    // -- Annuler l'action -- //
                    return false;
                }

                // -- Frame chargement -- //
                gbAfficher_Page_Chargement(true);

                // -- Charger le résultats dans la page -- //
                $("#conteneur").load(
                        // -- Lien de chargement de la page -- //
                        url,
                        // -- Fonction à éxecuter à la fin du chargement de la page -- //
                        function () {
                            // -- Frame chargement -- //
                            gbAfficher_Page_Chargement(false);
                        }
                    );

            } catch (e) { gbConsole(e.message); }

        }

    );

});