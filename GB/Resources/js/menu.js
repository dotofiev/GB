
// -- Lorsque le document est chargé -- //
$(function () {

    // -- Lorsqu'un menu est cliqué -- //
    $('.menu-iroll').on("click",
        function () {
            // -- Afficher le chargement -- //
            iAfficher_Page_Chargement(true);
            // -- Fermer la page de description si celui ic est ouvert -- //
            iDescription_Menu_Fermer();
            // -- Charger le résultats dans la page -- //
            $("#conteneur_module").load(
                    $(this).attr('name'),
                    function () {
                        // -- cacher le chargement -- //
                        iAfficher_Page_Chargement(false);
                    }
                );
        }
    );

});