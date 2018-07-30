
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Changer le titre de la page -- //
        try {
            gbConsoleStringify($GB_DONNEE);
            if (!$GB_DONNEE.reconnecter) {
                gbChangeTitle($GB_DONNEE.titre, $GB_DONNEE.description);
            }

        } catch (e) { gbConsole(e.message); }

    }
);
