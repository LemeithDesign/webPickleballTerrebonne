document.addEventListener("DOMContentLoaded", function () {
    const utilisateurId = getOrCreateUtilisateurId();

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/fileAttenteHub")
        .build();

    connection.start().then(() => {
        console.log("Connecté au hub SignalR");
        connection.invoke("RejoindreFile", utilisateurId, nomUtilisateur);
    }).catch(err => console.error(err.toString()));

    connection.on("PositionMiseAJour", (position, estActif) => {
        console.log(`Position : ${position}, Actif : ${estActif}`);

        if (estActif) {
            window.location.href = "/Inscription/Creer";
        } else {
            window.location.href = `/Attente?position=${position}`;
        }
    });

    document.getElementById("btnQuitter").addEventListener("click", function () {
        connection.invoke("QuitterFile", utilisateurId)
            .then(() => {
                console.log("Utilisateur retiré de la file");
                window.location.href = "/"; // Redirection après sortie
            })
            .catch(err => console.error(err.toString()));
    });

    function getOrCreateUtilisateurId() {
        const cookieName = "UtilisateurId";
        const existing = getCookie(cookieName);
        if (existing) return existing;

        const newId = crypto.randomUUID();
        document.cookie = `${cookieName}=${newId}; path=/`;
        return newId;
    }

    function getCookie(name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
    }
});