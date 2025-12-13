document.addEventListener("DOMContentLoaded", (event) => {
    gsap.from(".pbtImageTxt",
        {
            x: -300,
            y: 200,
            duration: 1,
            opacity: 0
        });


    // Balle bondissante:
    //let fenetre = document.querySelector('.pbtImage');
    //let rect = fenetre.getBoundingClientRect();
    //let largFenetre = rect.width;
    //let hauteurFenetre = rect.height;

    //let balle = document.querySelector('.pbtBalle img');
    //let rectBalle = balle.getBoundingClientRect();
    //let hauteurBalle = rectBalle.height;
    //let largeurBalle = rectBalle.width

    //let startX = largFenetre * 0.25;
    //let endX = largFenetre - largeurBalle;

    //let deltaY = hauteurFenetre - hauteurBalle;

    //console.log(startX);

    //gsap.set(".pbtBalle", { x: startX, y: 0, opacity: 0 })

    //const tl = gsap.timeline({ repeat: -1 });


    //tl.to(".pbtBalle", { opacity: 1, duration: 1 })
    //tl.to(".pbtBalle", { y: deltaY, duration: 1 })
    //tl.to(".pbtBalle", { x: endX, duration: 1 })
});