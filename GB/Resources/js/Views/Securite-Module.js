
// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Variables -- //
        var $table = $('#table-donnee');
        var url_controlleur = '/Securite/';

        // -- Changer le titre de la page -- //
        try {

            gbChangeTitle($GB_DONNEE.titre);

        } catch (e) { gbConsole(e.message); }

        // -- Traitement table -- //
        try {

            // -- Lorsque la table est redessiné -- //
            $table.on('draw.dt',
                function () {
                    // -- Fonction pour initiliser les style css javascript des tables -- //
                    gbCharger_Css_Table('module');
                }
            );

            // -- Table d'affichage des données -- //
            $table.DataTable({
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, $GB_DONNEE_PARAMETRES.Lang.All]],
                "scrollCollapse": true,
                "paging": true,
                "searching": true,
                "autoWidth": false,
                "language": {
                    "url": "/GB/Langue_DataTable"
                },
                "ajax": {
                    "url": url_controlleur + 'Charger_Table/?id_page=' + $GB_DONNEE.id_page,
                    "type": 'POST',
                    "dataSrc": function (resultat) {
                        return resultat.notification.donnee;
                    }
                },
                "columns": [
                    { "data": "col_1", "width": "20px" },           // -- Checkbox -- //
                    { "data": "col_2" },                            // -- id -- //
                    { "data": "col_3" },                            // -- Coderole -- //
                    { "data": "col_4" },                            // -- libelle_fr -- //
                    { "data": "col_5" },                            // -- libelle_en -- //
                    { "data": "col_6", "class": "text-center" }     // -- Action -- //
                ]
            });

        } catch (e) { gbConsole(e.message); }

    }
);
