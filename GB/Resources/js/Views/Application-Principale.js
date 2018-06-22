
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Changer le titre de la page -- //
        try {

            gbChangeTitle($GB_DONNEE.titre);

        } catch (e) { gbConsole(e.message); }

    }
);
