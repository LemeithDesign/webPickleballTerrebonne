$(function () {
    // Date cible
    const targetDate = new Date("2025-09-20T17:00:00");
    const now = new Date();

    // Calcul du délai en millisecondes
    const delay = targetDate.getTime() - now.getTime();

    // Si la date est dans le futur
    if (delay > 0) {
        setTimeout(function () {
            // Action à exécuter à la date cible
            $("#btnJoindre").removeClass("d-none");
            $("#cardNouvMem").addClass("d-none");

        }, delay);
    } else {
        // Si la date est déjà passée, on peut exécuter immédiatement
        $("#btnJoindre").removeClass("d-none");
        $("#cardNouvMem").addClass("d-none");
    }
});
