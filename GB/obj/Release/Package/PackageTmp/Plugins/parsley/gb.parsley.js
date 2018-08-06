
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Définition des nouveau validateurs -- //
        try {

            // -- Validateur de teste 
            Parsley.addValidator('test', {
                requirementType: 'string',
                validateString: function (value) {
                    return (value === 'POKA');
                },
                priority: 22,
                messages: {
                    fr: "Ce n'est pas POKA.",
                    en: "Is not POKA."
                }
            });

        } catch (e) { gbConsole(e.message); }

    }
);