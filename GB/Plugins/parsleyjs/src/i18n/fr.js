// Validation errors messages for Parsley
import Parsley from '../parsley';

Parsley.addMessages('fr', {
    defaultMessage: "Cette valeur semble non valide.",
    type: {
        email: "Cette valeur n'est pas une adresse email valide.",
        url: "Cette valeur n'est pas une URL valide.",
        number: "Cette valeur doit &ecirc;tre un nombre.",
        integer: "Cette valeur doit &ecirc;tre un entier.",
        digits: "Cette valeur doit &ecirc;tre num&eacute;rique.",
        alphanum: "Cette valeur doit &ecirc;tre alphanum&eacute;rique."
    },
    notblank: "Cette valeur ne peut pas &ecirc;tre vide.",
    required: "Ce champ est requis.",
    pattern: "Cette valeur semble non valide.",
    min: "Cette valeur ne doit pas &ecirc;tre inf&eacute;rieure &agrave; %s.",
    max: "Cette valeur ne doit pas exc&eacute;der %s.",
    range: "Cette valeur doit &ecirc;tre comprise entre %s et %s.",
    minlength: "Cette cha&icirc;ne est trop courte. Elle doit avoir au minimum %s caract&egrave;res.",
    maxlength: "Cette cha&icirc;ne est trop longue. Elle doit avoir au maximum %s caract&egrave;res.",
    length: "Cette valeur doit contenir entre %s et %s caract&egrave;res.",
    mincheck: "Vous devez s&eacute;lectionner au moins %s choix.",
    maxcheck: "Vous devez s&eacute;lectionner %s choix maximum.",
    check: "Vous devez s&eacute;lectionner entre %s et %s choix.",
    equalto: "Cette valeur devrait &ecirc;tre identique."
});

Parsley.setLocale('fr');
