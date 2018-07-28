
// -- Variable global -- //
var $GB_VAR = {
    aes_key: 'global_bank_aes',
    cookie_autorise: 'cookie_autorise',
    url_language_dataTable: '/GB/Langue_DataTable',
    class_table_selection: 'gb-table-success'
};
var $GB_DONNEE = null;
var $GB_DONNEE_PARAMETRES = null;

// -- Variables -- //
var fonction_en_Timeout;
var fonction_en_Interval;

// -- Mettre la première lettre ne majuscule -- // 
try {

    String.prototype.gbCapitalize = function () {
        return this.charAt(0).toUpperCase() + this.slice(1);
    }

}
catch (ex) {
    // -- Log -- //
    gbConsole(ex.message);
}

// -- Remplacer une expression par un autre -- // 
try {

    String.prototype.gbReplace = function (ancien, nouveau) {
        return this.replace(
                    new RegExp(ancien, 'g'),
                    nouveau
                );
    }

}
catch (ex) {
    // -- Log -- //
    gbConsole(ex.message);
}

// -- Vérifie qu'un element est présent dans la liste -- //
function gbExist(obj, liste) {

    return (liste.indexOf(obj) > -1) ? true
                                     : false;

}

// -- Supprimer les validations parsley -- //
function gbSupprimerMessageValidationForm(id_form) {

    // -- Suppression des css sur les champs -- //
    $('#' + id_form + ' .parsley-error').removeClass('parsley-error');
    // -- Supprimer les messages label -- //
    $('ul.parsley-errors-list.filled').remove();

}

// -- Configurer le processus d'importation des ifhcier sur le formulaire -- //
function gbConfigurerImportationFichier(id_input, id_button_select, id_button_delete, id_label, id_image, id_image_statut) {

    // -- Lorsque le bouton est cliqué -- //
    $('#' + id_button_select).on('click',
        function () {
            // -- Déclencher le click sur le file upload -- //
            $('#' + id_input).trigger('click');
        }
    );

    // -- Lorsque le file uplaod change -- //
    $('#' + id_input).on('change',
        function () {
            // -- Réccupérer le fichier - //
            var fichier = this.files[0];

            // -- Si le fichier n'est pas soumis -- //
            if (fichier == undefined || fichier == null) {
                return false;
            }

            // -- vérifier la taille de l'image -- //
            if ((fichier.size / 1024) > $GB_DONNEE_PARAMETRES.TAILLE_MAX_IMAGE_IMPORTATION) {
                // -- Message -- //
                gbAlert({ est_echec: true, message: $GB_DONNEE_PARAMETRES.Lang.The_file_must_not_exceed + ' (' + $GB_DONNEE_PARAMETRES.TAILLE_MAX_IMAGE_IMPORTATION + ' Kb).' });
                return false;
            }

            // -- Afficher l'image -- //
            if (id_image != undefined && id_image != null) {
                img = new Image();
                img.onload = function () {
                    // -- Mise à jour de la taille de l'image -- //
                    this.width = (this.width * 138) / this.height;
                };
                img.src = (window.URL || window.webkitURL).createObjectURL(fichier);
                // -- Mise àj our de l'image dans le document -- //
                document.getElementById(id_image).src = img.src;
            }

            // -- Réccupération du nom du document -- //
            $('#' + id_label).html(fichier.name);

            // -- Mise à jour du statut de l'image -- //
            if (id_image_statut != undefined && id_image_statut != null) {
                $('#' + id_image_statut).val(1);
            }
        }
    );

    // -- Lorsque le bouton annuler est cliqué -- //
    $('#' + id_button_delete).on('click',
        function () {
            // -- Mise àj our de l'image dans le document -- //
            if (id_image != undefined && id_image != null) {
                document.getElementById(id_image).src = '/Resources/images/png/Utilisateur.png';
            }

            // -- Mise à jour du nom de l'image -- //
            $('#' + id_label).html($GB_DONNEE_PARAMETRES.Lang.Empty + ' ...');

            // -- Vider l'image chargé -- //
            if (id_input != undefined && id_input != null) {
                $('#' + id_input).val(null);
            }

            // -- Mise à jour du statut de l'image -- //
            if (id_image_statut != undefined && id_image_statut != null) {
                $('#' + id_image_statut).val(0);
            }
        }
    );

}

// -- Notifier en cas d'autorisation de liste refusé -- //
function gbNotificationListerRefuser(notification) {

    //if (notification.dynamique.autorisation_refuse) {
    //    gbMessage_Box({ est_echec: true, message: $GB_DONNEE_PARAMETRES.Lang.Permission_to_list_records_denied });
    //}

}

// -- AJouter un element dans une liste -- //
function gbAddInList(list, element) {

    // -- Initialiser la liste si elle est vide -- //
    if (list == undefined || list == null) {
        list = [];
    }

    // -- AJouter -- //
    list.push(element);

    return list;

}

// -- Retirer un element dans une liste -- //
function gbRemoveInList(list, element) {

    // -- Initialiser la liste si elle est vide -- //
    if (list == undefined || list == null) {
        return [];
    }

    // -- Supprimer -- //
    list.splice($.inArray(element, list), 1);

    return list;

}

// -- Récupérer la liste des identifiants sélectionné dans une table -- //
function gbSelectionIdsTable(name) {

    // -- Réccupérer les données electionné -- //
    var selection = $('input[name="' + name + '"]:checked');

    // -- Si la taille est supérieurs à 0 -- //
    if (selection.length == 0) {
        return [];
    }

    // -- Mise à jour de l'etat de la selection -- //
    selection = selection.serialize().split('&');

    // -- Appel de la fonction -- //
    var ids = [];
    // -- Réccupération des id -- //
    for (var i = 0; i < selection.length; i++) {
        ids.push(selection[i].replace(name + '=' + name + '_', ''));
    }

    return ids;

}

// -- Recharger la table -- //
function gbRechargerTable(frame, id_check_all, id_table, fonction_execution) {

    // -- Mise à jour paramètre id_check_all -- //
    if (id_check_all == undefined || id_check_all == null) {
        id_check_all = 'check-all';
    }

    // -- Mise à jour paramètre id_check_all -- //
    if (id_table == undefined || id_table == null) {
        id_table = 'table-donnee';
    }

    // -- Recharger la table -- //
    $('#' + id_table).DataTable().ajax.reload(
        function () {
            // -- Teste si c'est un seul element -- //
            if (frame) {
                // -- cacher le chargement -- //
                gbAfficher_Page_Chargement(false);
            }
            // -- Reset la taille de la table -- //
            $('#' + id_table).DataTable().columns.adjust().draw();
            // -- Selectionner une ligne de la table -- //
            gbTableSelectionLigne(null, id_table);
            // -- Désactiver le multiselect -- //
            $('#' + id_check_all).iCheck('uncheck');
            $('#' + id_table + ' .column-title').show();
            $('#' + id_table + ' .bulk-actions').hide();
            // -- Executer la fonction à la fin du chargement de la table si celle ci est soumise -- //
            if (fonction_execution != undefined && fonction_execution != null) {
                fonction_execution();
            }
        }
    );

}

// -- Selectionner une ligne de la table -- //
function gbTableSelectionLigne(ligne, id_table) {

    // -- Mise à jour du id_table si celui ci n'est pas soumis -- //
    if (id_table == undefined || id_table == null) {
        id_table = 'table-donnee';
    }

    // -- Suppression de toutes les lignes delectionnées -- //
    $('#' + id_table + ' tbody tr').each(
        function () {
            // -- Si l'element n'a pas la classe passer -- //
            if ($(this).hasClass($GB_VAR.class_table_selection)) {
                $(this).removeClass($GB_VAR.class_table_selection);
            }
        }
    );

    // -- Mise à jour de la couleur de la ligne -- //
    if (ligne != undefined && ligne != null) {
        ligne.addClass($GB_VAR.class_table_selection);
    }

}

// -- Activer/Desactiver formulaire -- //
function gbActiverDesactiverForm(id_form, desactiver) {

    // -- Si le id_form n'est pas soumis ne rien faire -- //
    if (id_form == undefined || id_form == null) {
        return false;
    }

    // -- Si il s'agit d'une activation -- //
    if (desactiver) {
        $("#" + id_form + " :input").attr("disabled", true);
    } else {
        $("#" + id_form + " :input").attr("disabled", false);
    }

}

// -- Fonction native -- //
try {

    // -- Convertir un formulaire en JSon -- //
    $.fn.gbConvertToJSON = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

} catch (e) { gbConsole(e.message); }


// -- Afficher une alerte sur un element -- //
function gbAlert(notification, id_element) {

    // -- Annuler le time out actuel -- //
    clearTimeout(fonction_en_Timeout);

    // -- Mise à jour de id_element -- //
    id_element = (id_element == null || id_element == undefined) ? 'gbAlert'
                                                                 : id_element;

    // -- Ecoute si le notificateur est soumis -- //
    if (notification == null || notification == undefined) {
        notification = {
            est_echec: true,
            message: $GB_DONNEE_PARAMETRES.Lang.Error_server_message,
        }
    }

    // -- Afficher l'alert -- //
    $('#' + id_element).html(
        '<div class="gbalert alert alert-' + ((notification.est_echec) ? 'danger'
                                                                       : 'success') + ' alert-dismissible fade in" role="alert">' +
            '<div class="row">' +
                '<div class="col-lg-12">' +
                    '<div class="pull-left">' +
                        '<b>Information</b><br/>' +
                        notification.message +
                    '</div>' +
                    '<div class="pull-right">' +
                        '<button type="button" class="btn btn-default" data-dismiss="alert" aria-label="Close">' +
                            '<i class="fa fa-remove"></i> ' + $GB_DONNEE_PARAMETRES.Lang.Close +
                        '</button>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>'
    );

    // -- Ne pas fermer si la valeur est -1 -- //
    if ($GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX > 0) {
        // -- Supprimer l'alert après un temps défini -- //
        fonction_en_Timeout =
            setTimeout(
                function () {
                    // -- Fermer l'alert -- //
                    $('#' + id_element + ' .alert').alert('close');
                },
                $GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX
            );
    }

}

// -- Changer le titre de la page -- //
function gbChangeTitle(titre, description) {

    // -- Mise à joru des variables -- //
    if (description == undefined || description == null) {
        description = { icon: '', message: '' };
    }

    // -- Modifier le titre du document -- //
    document.title = titre;
    // -- Modifier la description de la page -- //
    $('#titre_description_page').html(
        '<i class="' + description.icon + '"></i> ' + description.message
    );

}

// -- Méthode de cryptage d'une valeur -- //
function gbAESEncrypt(value) {

// -- Clés de cryptage -- //
    var cryptoJS_param = { key: CryptoJS.enc.Utf8.parse($GB_VAR.aes_key), iv: CryptoJS.enc.Utf8.parse($GB_VAR.aes_key) };

    // -- Réccupérere la méthode encrypté -- //
    //var encrypted = CryptoJS.AES.encrypt(value, aes_key);
    var encrypted = CryptoJS.AES.encrypt(value, cryptoJS_param.key, {
        keySize: 128 / 8,
        iv: cryptoJS_param.iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    });

    // -- Renvoyer le résltat -- //
    return encrypted;

}

function gbAESDecrypt(value) {

    // -- Réccupérere la méthode décrypté -- //
    var decrypted = CryptoJS.AES.decrypt(value, $GB_VAR.aes_key).toString(CryptoJS.enc.Utf8);
    
    // -- Renvoyer le résltat -- //
    return decrypted;

}

// -- Effectuer une requete AJAX Asynchrone d'envois de données -- // -- //
function gbAjaxPost(url, parameters, isJSon, callback) {
	// -- Construction de l'objet requette -- //
    var requete = new XMLHttpRequest();
	// -- Appel de la requête -- //
    requete.open("POST", url);
	// -- 2coute de la requête une fois celle ci terminé -- //
    requete.addEventListener("load", function () {
        if (requete.status >= 200 && requete.status < 400) {
            // -- Appelle la fonction callback en lui passant la réponse de la requête -- //
            callback(requete.responseText);
        } else {
			// -- Log -- //
			gbConsole('Méthode: iAjaxGet, Exception: ' + requete.status + " " + requete.statusText);
        }
    });
	// -- Ecoute de l'evenemment en cas d'erreur -- //
    requete.addEventListener("error", function () {
		// -- Log -- //
		gbConsole("Méthode: iAjaxGet, Exception: Erreur réseau avec l'URL " + url);
    });
	// -- Mise à jour des paramètres si c'est le JSon -- //
	if (isJSon != undefined && isJSon != null && isJSon) {
        // Définit le contenu de la requête comme étant du JSON
        req.setRequestHeader("Content-Type", "application/json");
        // Transforme la donnée du format JSON vers le format texte avant l'envoi
        parameters = JSON.stringify(parameters);
    }
	// -- Envoi de la reqête avec les paramètres -- //
    requete.send(parameters);
}

// -- Effectuer une requete AJAX Asynchrone -- // -- //
function gbAjaxGet(url, callback) {
	// -- Construction de l'objet requette -- //
    var requete = new XMLHttpRequest();
	// -- Appel de la requête -- //
    requete.open("GET", url);
	// -- 2coute de la requête une fois celle ci terminé -- //
    requete.addEventListener("load", function () {
        if (requete.status >= 200 && requete.status < 400) {
            // -- Appelle la fonction callback en lui passant la réponse de la requête -- //
            callback(requete.responseText);
        } else {
			// -- Log -- //
			gbConsole('Méthode: iAjaxGet, Exception: ' + requete.status + " " + requete.statusText);
        }
    });
	// -- Ecoute de l'evenemment en cas d'erreur -- //
    requete.addEventListener("error", function () {
		// -- Log -- //
		gbConsole("Méthode: iAjaxGet, Exception: Erreur réseau avec l'URL " + url);
    });
	// -- Envoi de la reqête avec les paramètres -- //
    requete.send(null);
}

// -- Scroller un element vers le bas -- //
function gbScrollTop(id_element) {
    // -- Réccupérer l'element -- //
    var element = $("#" + id_element);
    // -- Scroller l'element -- //
    element.scrollTop(element[0].scrollHeight);
}

// -- Initialiser les evenements -- //
function gbInitialiser_charger_evenement() {
    // -- Définition de la langue du pluging de validation Parsley -- //
    window.Parsley.setLocale(
        iLangue_Active()
    );

    // Panel toolbox
    $(".icollapse-link").on("click",
        function () {
            gbConsole("Je suis cliqué 2");
            var $iBOX_PANEL = $(this).closest(".icollapsable-panel"),
                $iICON = $(this).find('i'),
                $iBOX_CONTENT = $iBOX_PANEL.find(".icollapse-panel");

            if ($iBOX_PANEL.attr("style")) {
                $iBOX_CONTENT.slideToggle(200, function () {
                    $iBOX_PANEL.removeAttr("style");
                });
            } else {
                $iBOX_CONTENT.slideToggle(200);
                $iBOX_PANEL.css("height", "auto");
            }

            $iICON.toggleClass("fa-chevron-up fa-chevron-down");
            gbConsole("Je suis cliqué 1");
        }
    );

    $(".iclose-link").click(
        function () {
            var $iBOX_PANEL = $(this).closest(".iclosable-panel");
            $iBOX_PANEL.remove();
            gbConsole("Je suis cliqué");
        }
    );
    // /Panel toolbox

    // -- Charger le mask de date -- //
    try {

        $("[data-mask]").inputmask();

    } catch (ex) {
        // -- Log -- //
        gbConsole('Méthode: Charger le mask de date, Exception: ' + ex.message);
    }
}

// -- Fermer la page de description si celui ic est ouvert -- //
function gbDescription_Menu_Fermer() {
    // -- Teste si la fenêtre est visible -- //
    if ($("#menu_description").css('display') != 'none') {
        // -- Déclencher l'action de fermenure -- //
        $('#bouton_menu_description').trigger("click");
    }
}

// -- Jeter le telechargement d'un fichier -- //
function gbTelecharger_Fichier(fichierBase64, type, intitule) {
    try {
        /*
        // -- Telecharger le fichier -- //
        var blob = new Blob(
                        // -- COnvertir et charger le chier -- //
                        [iConvert_Base64_En_ArrayBuffer(fichierBase64)],
                        // -- Définir le type du fichier -- //
                        { type: type }
                    );
        var link = document.createElement("a");
        link.href = window.URL.createObjectURL(blob);
        // -- Définir le nom du document à telecharger -- //
        link.download = intitule;
        // -- Générer le telechargement à travers un click -- //
        link.click();
        */
        
        // -- Construction de l'objet blob à telecharger -- //
        var blob = new Blob(
                        // -- COnvertir et charger le chier -- //
                        [iConvert_Base64_En_ArrayBuffer(fichierBase64)],
                        // -- Définir le type du fichier -- //
                        { type: type }
                    );
        // -- générer le telechargement du fichier -- //
        saveAs(blob, intitule);
    } catch (ex) {
        // -- Log -- //
        gbConsole('Méthode: iTelecharger_Fichier, Exception: ' + ex.message);
        // -- Afficher le message d'erreur -- //
        iMessage_Box(
            'Information',
            iLangue_Active() == 'en' ? 'An error occurred while downloading the file'
                                     : 'Une erreur est survenue lors du téléchargement du fichier',
            3,
            true
        );
    }
}

// -- COnvertir base64 en tableau de byte -- //
function gbConvert_Base64_En_ArrayBuffer(base64) {
    try{
        var binaryString = window.atob(base64);
        var binaryLen = binaryString.length;
        var bytes = new Uint8Array(binaryLen);

        // -- Parcourir et lister -- //
        for (var i = 0; i < binaryLen; i++) {
            var ascii = binaryString.charCodeAt(i);
            bytes[i] = ascii;
        }

        // -- Renvoyer les bytes -- //
        return bytes;
    } catch (ex) {
        // -- Log -- //
        gbConsole('Méthode: iConvert_Base64_En_ArrayBuffer, Exception: ' + ex.message);
    }

    // -- Retourner Null en cas d'echec de convertion -- //
    return null;
}

// -- Afficher/Cacher l'etat de chargement de la page -- //
function gbAfficher_Page_Chargement(afficher, id_bouton) {
    if (afficher) {
        // -- Actualiser le bouton -- //
        if (id_bouton != undefined && id_bouton != null) {
            $('#' + id_bouton).button('loading');
        }
        // -- Affichier le progress bar -- //
        //NProgress.start();
        // -- Afficher le frame de chargelent -- //
        $('#frame_chargement').show();
    } else {
        // -- Actualiser le bouton -- //
        if (id_bouton != undefined && id_bouton != null) {
            $('#' + id_bouton).button('reset');
        }
        // -- Finaliser le chargement du progress bar -- //
        //NProgress.done();
        // -- Cacher le frae de chargement -- //
        $('#frame_chargement').hide();
    }
}

// -- Retourne le code de la langue actuellement présent dans l'application -- //
function gbLangue_Active() {
    return $('html').attr("lang");
}

// -- Afficher un message de confirmation d'actionn -- //
function gbConfirmation_OuiOuNon(message, id_soumission, fonction_execution) {

    // -- Initialisation de la réponse -- //
    $GB_DONNEE.Confirmation_message_box = false;

    // -- Mise à jour du message -- //
    $('#modal_message_question_message').html(
        (message == null) ? $GB_DONNEE_PARAMETRES.Lang.Confirm_action
                          : message
    );
    // -- Annuler tous les evenement précédement chargé -- //
    $('#modal_message_question_bouton_oui').off('click');
    $('#modal_message_question_bouton_non').off('click');
    $('#modal_message_question').off('hidden.bs.modal');

    // -- Définir les nouveaux evenements -- //
    // -- Comportement du bouton Oui -- //
    $("#modal_message_question_bouton_oui").on('click',
        function () {
            // -- Cacher le message box -- //
            $('#modal_message_question').modal('hide');
            // -- Mise à jour de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = true;
        }
    );
    // -- Comportement du bouton Non -- //
    $("#modal_message_question_bouton_non").on('click',
        function () {
            // -- Cacher le message box -- //
            $('#modal_message_question').modal('hide');
            // -- Mise à jour de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = false;
        }
    );
    // -- Méthode quand le message box se fermer -- //
    $("#modal_message_question").on('hidden.bs.modal',
        function () {
            // -- Si la réponse est non -- //
            if (!$GB_DONNEE.Confirmation_message_box) {
                return false;
            }

            // -- Si l'id est passé -- //
            if (id_soumission != null) {
                $("#" + id_soumission).submit();
            }
            // -- Executer la fonction -- //
            else {
                fonction_execution();
            }

            // -- Initialisation de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = false;
        }
    );

    // -- Afficher le message box -- //
    $('#modal_message_question').modal('show');

}

// -- Afficher un message de confirmation d'actionn -- //
function gbConfirmationAlert_OuiOuNon(id_alert, message, id_form, fonction_execution) {

    // -- Annuler le time out actuel -- //
    clearTimeout(fonction_en_Timeout);

    // -- Mise à jour de id_element -- //
    id_alert = (id_alert == null || id_alert == undefined) ? 'gbAlert'
                                                           : id_alert;

    // -- Initialisation de la réponse -- //
    $GB_DONNEE.Confirmation_message_box = false;

    // -- Afficher l'alert -- //
    $('#' + id_alert).html(
        '<div id="gbAlert_id" class="gbalert alert alert-dismissible fade in" role="alert" style="border-color: rgba(38,185,154,.88);">' +
            '<div class="row">' +
                '<div class="col-lg-12">' +
                    '<div class="pull-left">' +
                        '<b>Information</b><br/>' +
                        ((message == null) ? $GB_DONNEE_PARAMETRES.Lang.Confirm_action
                                           : message) +
                    '</div>' +
                    '<div class="pull-right">' +
                        '<button id="alert_message_question_bouton_non" type="button" class="btn btn-default" data-dismiss="alert" aria-label="Close">' +
                            '<i class="fa fa-remove"></i> ' + $GB_DONNEE_PARAMETRES.Lang.No +
                        '</button>' +
                        '<button id="alert_message_question_bouton_oui" type="button" class="btn btn-success" data-dismiss="alert" aria-label="Close">' +
                            '<i class="fa fa-check"></i> ' + $GB_DONNEE_PARAMETRES.Lang.Yes +
                        '</button>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>'
    );

    // -- Annuler tous les evenement précédement chargé -- //
    $('#alert_message_question_bouton_oui').off('click');
    $('#alert_message_question_bouton_non').off('click');
    $('#gbAlert_id').off('closed.bs.alert');

    // -- Définir les nouveaux evenements -- //
    // -- Comportement du bouton Oui -- //
    $("#alert_message_question_bouton_oui").on('click',
        function () {
            // -- Fermer le message box -- //
            $('#gbAlert_id').alert('close');
            // -- Mise à jour de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = true;
        }
    );
    // -- Comportement du bouton Non -- //
    $("#alert_message_question_bouton_non").on('click',
        function () {
            // -- Fermer le message box -- //
            $('#gbAlert_id').alert('close');
            // -- Mise à jour de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = false;
        }
    );
    // -- Méthode quand le message box se fermer -- //
    $('#gbAlert_id').on('closed.bs.alert',
        function () {
            // -- Activer/Desactiver formulaire -- //
            gbActiverDesactiverForm(id_form, false);

            // -- Si la réponse est non -- //
            if (!$GB_DONNEE.Confirmation_message_box) {
                return false;
            }

            // -- Si l'id est passé -- //
            if (id_form != null) {
                $("#" + id_form).submit();
            }
            // -- Executer la fonction -- //
            else {
                fonction_execution();
            }

            // -- Initialisation de la réponse -- //
            $GB_DONNEE.Confirmation_message_box = false;
        }
    );

    // -- Activer/Desactiver formulaire -- //
    gbActiverDesactiverForm(id_form, true);

    // -- Ne pas fermer si la valeur est -1 -- //
    if ($GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX > 0) {
        // -- Supprimer l'alert après un temps défini -- //
        fonction_en_Timeout =
            setTimeout(
                function () {
                    // -- Fermer l'alert -- //
                    $('#gbAlert_id').alert('close');
                },
                $GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX
            );
    }

}

// -- Retourner un objetc location portant les détails sur mon emplacement -- //
function gbMa_Localite(adresse)
{
    try {
        $.getJSON(
            (adresse == null) ? 'https://ipinfo.io/json'
                              : adresse, 
            function (reponse) {
                return {
                    ip          : reponse.ip,
                    ville       : reponse.city,
                    region      : reponse.region,
                    pays        : reponse.country,
                    coordonnees : reponse.loc,
                    organisation: reponse.org
                }
            }
        );
    } catch (ex) {
        // -- Log -- //
        gbConsole('Méthode: iMa_Localite, Exception: ' + ex.message);
        // -- Retourne null -- //
        return null;
    }
}

// -- Confirmer avant de fermer la page -- //
function gbConfirmation_fermeture_page(message) {
    $(window).bind(
        'beforeunload',
        function (e) {
            // Your code and validation
            if (confirm) {
                return message;
            }
        }
    );
}

// -- Lire un fichier audio -- //
function gbJouer_Audio(id_aution) {
    try {
        // -- Réccupérer l'element -- //
        var audio = document.getElementById(id_aution);
        // -- Mettre pause au song si il est en cours -- //
        audio.pause();
        // -- Mettre la position de lecture à 0 -- //
        audio.currentTime = 0;
        // -- Jouer l'element -- //
        audio.play();
    }
    catch (ex) {
        // -- Log -- //
        gbConsole('Méthode: iJouer_Audio, Exception: ' + ex.message);
    }
}

// -- Fonction pour afficher le modal de rehcerche d'un employé -- //
function gbAfficher_Modal_Rechercher_Employe(url_donnee) {
    // -- Variable -- //
    var $modal = $('#modal_recherche_employe_table');
    // -- Afficher le chargement -- //
    iAfficher_Page_Chargement(true);
    // -- Recharger la table des employé à rechercher -- //
    if (!$.fn.dataTable.isDataTable('#modal_recherche_employe_table')) {
        // -- Créer le data table -- //
        $modal.DataTable({
            "lengthMenu": [
                [3, 5, 10],
                [3, 5, 10]
            ],
            "scrollCollapse": true,
            "paging": true,
            "searching": true,
            "autoWidth": false,
            "language": {
                "url": "/iRoll/LangueTableDonnee"
            },
            "ajax": {
                "url": url_donnee,
                "type": 'POST',
                "dataSrc": function (resultat) {
                    // -- Notifier -- //
                    gbNotificationListerRefuser(resultat.notification);
                    // -- Retourner les données -- //
                    return resultat.notification.donnee;
                }
            },
            "columns": [
                { "data": "col_1", "width": "20px", "class": "text-center" }, // -- Action -- //
                { "data": "col_2" }, // -- Matricule -- //
                { "data": "col_3" }, // -- Nom -- //
                { "data": "col_4" }, // -- Prenom -- //
                { "data": "col_5" }, // -- Agence -- //
                { "data": "col_6" }, // -- Departemant -- //
                { "data": "col_7" }, // -- Service -- //
                { "data": "col_8" }, // -- Fonction -- //
                { "data": "col_9", "class": "text-center" } // -- Date de création -- //
            ]
        });
        // -- cacher le chargement -- //
        iAfficher_Page_Chargement(false);
        // -- Afficher le modal quand la table fini de recharger -- //
        $('#modal_recherche_employe').modal('show');
    } else {
        // -- Recharger la table depuis le lien -- //
        $modal.DataTable()
              .ajax.url(url_donnee)
              .load(
                    function () {
                        // -- cacher le chargement -- //
                        iAfficher_Page_Chargement(false);
                        // -- Afficher le modal quand la table fini de recharger -- //
                        $('#modal_recherche_employe').modal('show');
                        // -- Reset la taille de la table -- //
                        $modal.DataTable().columns.adjust().draw();
                    }
              );
    }

    // -- Lorsque le modal est visible -- //
    //$('#modal_recherche_employe').on('show.bs.modal',
    //    function () {
    //        gbConsole('Je suis visible');
    //        //function_validation;
    //    }
    //);
}

// -- Fonction pour initiliser les style css javascript des tables -- //
function gbCharger_Css_Table(type_donnee, id_check_all, id_table) { //
    
    // -- Mise à jour paramètre id_check_all -- //
    if (id_check_all == undefined || id_check_all == null) {
        id_check_all = 'check-all';
    }

    // -- Mise à jour paramètre id_check_all -- //
    if (id_table == undefined || id_table == null) {
        id_table = 'table-donnee';
    }

    // iCheck
    // -- Green -- //
    if ($('#' + id_table + ' .flat')[0]) {
        $('#' + id_table + ' .flat').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });
    }
    // -- blue -- //
    if ($('#' + id_table + ' .flat-blue')[0]) {
        $('#' + id_table + ' .flat-blue').iCheck({
            checkboxClass: 'icheckbox_flat-blue',
            radioClass: 'iradio_flat-blue'
        });
    }

    // Table
    $("table input[name='" + type_donnee + "']").on('ifChecked', function () {
        $(this).parent().parent().parent().addClass('selected');
        gbCharger_Css_Table_Nombre_Selection(type_donnee, '', id_check_all, id_table);
    });
    $("table input[name='" + type_donnee + "']").on('ifUnchecked', function () {
        $(this).parent().parent().parent().removeClass('selected');
        gbCharger_Css_Table_Nombre_Selection(type_donnee, '', id_check_all, id_table);
    });

    $(".bulk_action input[name='" + type_donnee + "']").on('ifChecked', function () {
        $(this).parent().parent().parent().addClass('selected');
        gbCharger_Css_Table_Nombre_Selection(type_donnee, '', id_check_all, id_table);
    });
    $(".bulk_action input[name='" + type_donnee + "']").on('ifUnchecked', function () {
        $(this).parent().parent().parent().removeClass('selected');
        gbCharger_Css_Table_Nombre_Selection(type_donnee, '', id_check_all, id_table);
    });

    $('.bulk_action input#' + id_check_all).on('ifChecked', function () {
        gbCharger_Css_Table_Nombre_Selection(type_donnee, 'all', id_check_all, id_table);
    });
    $('.bulk_action input#' + id_check_all).on('ifUnchecked', function () {
        gbCharger_Css_Table_Nombre_Selection(type_donnee, 'none', id_check_all, id_table);
    });

}

// -- Mettre à jour le label du nombre d'element selectionné -- //
function gbCharger_Css_Table_Nombre_Selection(type_donnee, checkState, id_check_all, id_table) {

    if (checkState === 'all') {
        $(".bulk_action input[name='" + type_donnee + "']").iCheck('check');
    }
    if (checkState === 'none') {
        $(".bulk_action input[name='" + type_donnee + "']").iCheck('uncheck');
    }

    //var checkCount = $(".bulk_action input[name='" + type_donnee + "']:checked").length;

    //if (checkCount) {
    //    $('#' + id_table + ' .column-title').hide();
    //    $('#' + id_table + ' .bulk-actions').show();
    //    $('#' + id_table + ' .action-cnt').html(checkCount);
    //} else {
    //    $('#' + id_table + ' .column-title').show();
    //    $('#' + id_table + ' .bulk-actions').hide();
    //}

}

// -- Fonction sur les actions de la description menu -- //
function gbMenu_Description_Gestion() {

    // -- Lorsque le panel d'aide d'un menu est appelé -- //
    $(".aide-iroll").on("click",
        function () {
            // -- Variables -- //
            var libelle_menu = $(this).attr('title');
            // -- Ajax -- //
            $.ajax({
                type: "POST",
                url: "/iRoll/Description_Menu",
                data: {
                    codemenu: $(this).attr('name')
                },
                success: function (resultat) {
                    // -- Tester si le traitement s'est bien effectué -- //
                    if (resultat.notification.est_echec) {
                        // -- Notifier -- //
                        iNotification(resultat.notification);
                    } else {
                        // -- Changer la description du menu dans le panel -- //
                        if (resultat.notification.donnee != null) {
                            // -- Charger le contenu de la description -- //
                            $("#detail_menu_description").html(resultat.notification.donnee.description);
                            // -- Charger le titre du menu -- //
                            $("#titre_menu_description").html(libelle_menu);
                            // -- Charger le code du menu dans le bouton d'impression -- //
                            $("#bouton_imprimer_menu_description").attr('name', resultat.notification.donnee.codemenu);
                            // -- Afficher la description -- //
                            $("#menu_description").slideToggle("slow");
                        }
                    }
                },
                error: function () {
                    // -- Notifier -- //
                    iMessage_Box('Information', 'Une erreur serveur est survenue!', 4, false);
                }
            });
        }
    );

}

// -- Réccupérer la valeur de l'attribut d'un cookie -- //
function gbGet_Cookie_Attribut(cookie_name, cookie_attribut) {
    // -- Réccupérer la valuer du cookie -- //
    var cookie_value = iGet_Cookie(cookie_name);

    for (var i = 0; i < cookie_value.split('&').length; i++) {
        if (cookie_value.split('&')[i].split('=')[0] == cookie_attribut) {
            // -- Retourner la valeur de l'attribut -- //
            return cookie_value.split('&')[i].split('=')[1];
        }
    }
    // -- Retourner une chaine vide -- //
    return "";
}

// -- Mettre à jour l'attribut d'un cookie -- //
function gbCookiees_MiseAJour_Attribut(cookie_name, cookie_attribut, valeur) {
    // -- Réccupérer la valuer du cookie -- //
    var cookie_value = iGet_Cookie(cookie_name);
    // -- Dit oui ou non si un attribut a été trouvé -- //
    var existe = false;
    for (var i = 0; i < cookie_value.split('&').length; i++) {
        if (cookie_value.split('&')[i].split('=')[0] == cookie_attribut) {
            cookie_value = cookie_value.replace(cookie_attribut + '=' + cookie_value.split('&')[i].split('=')[1], cookie_attribut + '=' + valeur);
            existe = true;
        }
    }
    // -- Si aucun attribut n'a été trouvé alors ajouter en un -- //
    if (!existe) {
        cookie_value = cookie_value + '&' + cookie_attribut + '=' + valeur;
    }
    // -- Mettre à jour la valeur du cookie -- //
    iSet_Cookie(cookie_name, cookie_value, 1);
}

// -- Notifier l'utilisation des cookies -- //
function gbCookiees_Notification() {
    // -- Test si l'utilisateur à accepter la présence des cookies - //
    if (iGet_Cookie_Attribut('iroll_utilisateur', 'cookies_est_active') != 'true') {
        $("#message_cookiees").slideToggle("slow");
    }
}

// -- Teste si les cookies sont actif sur la page et effectue des traitement en cas de desactivation -- //
function gbCookiees_Verification(titre, message, afficher_bouton_reconnexion) {
    // -- toutes les 1 secondes -- //
    setInterval(
        function () {
            if (!iCookiees_Active()) {
                // -- Afficher le message d'alerte -- //
                if (!$('#modal_message_cookiees').hasClass('in')) {
                    iMessage_Cookiees(titre, message, afficher_bouton_reconnexion);
                }
            } else {
                // -- Cacher le message box -- //
                $('#modal_message_cookiees').modal('hide');
            }
        },
        1000
    );
}

// -- Retourne si oui ou non les cookiees sont activés sur le navigateur -- //
function gbCookiees_Active()
{
    return navigator.cookieEnabled;
}

// -- Afficher l'heure sur un element indiqué -- //
function gbMontre(id_element, titre, message, afficher_bouton_reconnexion) {
    // -- toutes les 1 secondes -- //
    fonction_en_Interval = setInterval(
                                function () {
                                    // -- Mise à jour du html de l'element -- //
                                    $('#' + id_element).html(moment().format(((iLangue_Active() == 'en') ? 'hh:mm A'
                                                                                                         : 'HH:mm')));
                                    // ------------- //
                                    // -- Cookies -- //
                                    if (!iCookiees_Active()) {
                                        // -- Afficher le message d'alerte -- //
                                        if (!$('#modal_message_cookiees').hasClass('in')) {
                                            iMessage_Cookiees(titre, message, afficher_bouton_reconnexion);
                                        }
                                    } else {
                                        // -- Cacher le message box -- //
                                        $('#modal_message_cookiees').modal('hide');
                                    }
                                    // ------------- //
                                },
                                1000
                           );
}

// -- Function de conversion d'un objet en string -- //
function gbTo_String(value) {
    return JSON.stringify(value);
}

// -- Function de redirection à une localité spécifique -- //
function gbHref(url) {

    window.location.href = url;

}

// -- Function d'écriture dans la console -- //
function gbConsole(value) {

    console.log(value);

}

function gbConsoleStringify(value) {

    console.log(JSON.stringify(value));

}

// -- Notificateur -- //
function gbNotification(notification, titre) {

    // -- Ecoute si le notificateur est soumis -- //
    if (notification == null || notification == undefined) {
        notification = {
            est_echec: true,
            message: $GB_DONNEE_PARAMETRES.Lang.Error_server_message,
        }
    }

    // - Notifier -- //
    new PNotify({
        title: titre == undefined || titre == null ? 'Information'
                                                   : titre,
        text: notification.message,
        type: (notification.est_echec === null) ? 'info'
                                                : (notification.est_echec) ? 'error'
                                                                           : 'success'
    });

}

// -- Message Cookiees -- //
function gbMessage_Cookiees(titre, message, afficher_bouton_reconnexion) {

    // -- Mise à jour du message -- //
    $('#modal_message_cookiees_message').html('<div class="ipanel-msg-cookiees">' +
                                                '<div class="ipanel-body text-center">' +
                                                    '<p>' +
                                                        '<span class="gbtext-bold"><i class="fa fa-info-circle"></i> ' + titre + '</span><br/>' +
                                                        message +
                                                    '</p>' +
                                                '</div>' +
                                              '</div>');
    // -- Afficher ou cacher le bouton de reconnexion -- //
    if (afficher_bouton_reconnexion) {
        $('#modal_message_cookiees_bt_reconnexion').show();
    } else {
        $('#modal_message_cookiees_bt_reconnexion').hide();
    }
    // -- Afficher le message box -- //
    $('#modal_message_cookiees').modal('show');

}

// -- Message box de notification -- //
function gbMessage_Box(notification) {

    // -- Mise à jour des variable en cas d'erreur serveur -- //
    if (notification === undefined || notification === null) {
        notification = {
            est_echec: true,
            message: $GB_DONNEE_PARAMETRES.Lang.Error_server_message,
        }
    }

    // -- Mise à jour de la taille -- //
    $('#modal_message_taille').removeClass('modal-dialog');
    $('#modal_message_taille').addClass('modal-dialog modal-sm');
    // -- Définir l'entête -- //
    $('#modal_message_titre').html('<i class="glyphicon glyphicon-info-sign text-' + ((notification.est_echec != null) ? 
                                                                                        (notification.est_echec) ? 'danger' 
                                                                                                                 : 'success'
                                                                                            : 'info') + '"></i> Information');
    // -- Definir le message -- //
    $('#modal_message_text').html(notification.message);
    // -- Afficher -- //
    $('#modal_message').modal('show');

    // -- Ne pas fermer si la valeur est -1 -- //
    if ($GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX > 0) {
        // -- Supprimer l'alert après un temps défini -- //
        setTimeout(
            function () {
                // -- Fermer le modal -- //
                $('#modal_message').modal('hide');
            },
            $GB_DONNEE_PARAMETRES.DUREE_VISIBILITE_MESSAGE_BOX
        );
    }

}

// -- Afficher un pop overs sur un element -- //
function gbPop_Over(id, message, type, delai_apparition, delai_visibilite) {
    // -- Annuler le time out actuel -- //
    clearTimeout(fonction_en_Timeout);

    $('#' + id).html('<div class="alert alert-' + ((type == 1) ? 'success'
                                                               : (type == 2) ? 'info'
                                                                             : (type == 3) ? 'warning'
                                                                                           : 'danger') + ' alert-dismissible fade in" role="alert">' +
                        '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>' +
                         message +
                     '</div>');

    // -- Afficher le pop over -- //
    $('#' + id).show(delai_apparition);

    // -- Definition de la durée d'afficharge si celle ci est défini -- //
    if (delai_visibilite != null && !isNaN(delai_visibilite)) {
        fonction_en_Timeout = setTimeout(
                                    function () {
                                        // -- Cacher le pop over -- //
                                        $('#' + id).hide(delai_apparition);
                                    },
                                    delai_visibilite
                                );
    }
}

// -- Converti une date C# en date Javascript -- //
function gbConvert_Date(date) {
    var milliSecondes = date.replace('/Date(', '')
                            .replace(')/', '');
    var DATE = new Date(
                    parseInt(milliSecondes)
               );

    return DATE;
}

// -- Définir un cookies -- //
function gbSetCookie(cookie_name, cookie_value, exdays) {

    // -- Vérifie que le paramètre n'est pas null -- //
    if (cookie_value != null && cookie_value != undefined) {
        // -- Cryptage du paramètre valeur -- //
        //cookie_value = gbAESEncrypt(cookie_value.toString());

        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cookie_name + "=" + cookie_value + ";" + expires + ";path=/";
    }

}

// -- Suppression d'un cookies -- //
function gbRemoveCookie(cookie_name) {

    // -- Mise à jour de la valeur du cookie pour suppression -- //
    document.cookie = cookie_name + "=;expires=Thu, 01 Jan 1970 00:00:00 UTC;path=/;";

}

// -- Réccupérer la valeur d'un cookie -- //
function gbGetCookie(cookie_name) {

    var name = cookie_name + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return
                c.substring(name.length, c.length);
                // -- Décryptage de la valeur -- //
                //gbAESDecrypt(
                //    c.substring(name.length, c.length)
                //);
        }
    }

    return "";

}

// -- Retourne vrai ou faux si une valeur existe dans une chaine -- //
function gbString_Existe(chaine, value) {

    return (chaine.indexOf(value) > 0) ? true
    								   : false;

}

// -- Lorsque le document est chargé -- //
$(
    function () {

        // -- Affichier le progress bar -- //
        try {

            //NProgress.start();

        } catch (e) { gbConsole(e.message); }

        // -- Frame de chargement de la page -- //
        try {

            // Create overlay and append to body:
            $('<div id="frame_chargement"/>').css({
                position: 'fixed',
                top: 0,
                left: 0,
                width: '100%',
                height: $(window).height() + 'px',
                opacity: 0.4,
                zIndex: 999999,
                cursor: 'wait',
                background: 'lightgray url(../../Resources/images/gif/loading_1_50px.gif) no-repeat center'
            }).hide().appendTo('body');

            // -- Cacher la page en chargement -- //
            $('<div id="frame_cacher"/>').css({
                position: 'fixed',
                top: 0,
                left: 0,
                width: '100%',
                height: $(window).height() + 'px',
                opacity: 1,
                zIndex: 999999,
                cursor: 'wait',
                background: 'lightgray url(../../Resources/images/gif/loading_1_50px.gif) no-repeat center'
            }).hide().appendTo('body');

        } catch (e) { gbConsole(e.message); }

        // -- Notifier l'utilisation des cookiees -- //
        try {

            // -- Lors du click sr le bouton de validation -- //
            //$("#bt_valide_cookie_use").on("click",
            //    function () {
            //        // -- Définir l'autorisation d'exploitation des cookies -- //
            //        gbSetCookie($GB_VAR.cookie_autorise, 1, 365);

            //        // -- Cacher le panel cookie -- //
            //        $("#cookie_panel").slideToggle("slow");
            //    }
            //);

            //// -- Notifier l'utilisation des cookies -- //
            //if (gbGetCookie($GB_VAR.cookie_autorise) === "") {
            //    // -- Afficher le panel cookiees -- //
            //    $("#cookie_panel").slideToggle("slow");
            //}

        } catch (e) { gbConsole(e.message); }

        // -- Charger le masque sur les champ date -- //
        try {

            //$("[data-mask]").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

        } catch (e) { gbConsole(e.message); }

        // -- Finaliser le chargement du progress bar -- //
        try {

            //NProgress.done();

        } catch (e) { gbConsole(e.message); }

    }
);