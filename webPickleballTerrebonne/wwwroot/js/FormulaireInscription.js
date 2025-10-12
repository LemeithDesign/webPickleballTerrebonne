$(function () {
    $('.phone').on('input', function () {
        let val = $(this).val().replace(/\D/g, ''); // Supprime tout sauf les chiffres
        let formatted = '';

        if (val.length > 0) {
            formatted += val.substring(0, 3);
        }
        if (val.length >= 4) {
            formatted += '-' + val.substring(3, 6);
        }
        if (val.length >= 7) {
            formatted += '-' + val.substring(6, 10);
        }

        $(this).val(formatted);
    });
});


$(function () {
    $('.postal').on('input', function () {
        let val = $(this).val().toUpperCase().replace(/[^A-Z0-9]/g, ''); // Garde lettres et chiffres
        let formatted = '';

        if (val.length > 0) {
            formatted += val.substring(0, 1); // Lettre
        }
        if (val.length >= 2) {
            formatted += val.substring(1, 2); // Chiffre
        }
        if (val.length >= 3) {
            formatted += val.substring(2, 3); // Lettre
        }
        if (val.length >= 4) {
            formatted += ' ' + val.substring(3, 4); // Espace + Chiffre
        }
        if (val.length >= 5) {
            formatted += val.substring(4, 5); // Lettre
        }
        if (val.length >= 6) {
            formatted += val.substring(5, 6); // Chiffre
        }

        $(this).val(formatted);
    });
});
