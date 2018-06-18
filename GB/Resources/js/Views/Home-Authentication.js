
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

        } catch (e) { gbConsole(e.message); }

    }
);
