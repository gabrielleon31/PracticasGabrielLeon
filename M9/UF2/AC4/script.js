document.addEventListener("DOMContentLoaded", () => {
    let activeAudio = null;

    document.querySelectorAll("audio").forEach(audio => {
        audio.addEventListener("play", () => {
            activeAudio = audio;
        });
    });

    document.getElementById("play").addEventListener("click", () => {
        if (activeAudio) activeAudio.play();
    });

    document.getElementById("pause").addEventListener("click", () => {
        if (activeAudio) activeAudio.pause();
    });

    document.getElementById("vol-up").addEventListener("click", () => {
        if (activeAudio && activeAudio.volume < 1) activeAudio.volume += 0.1;
    });

    document.getElementById("vol-down").addEventListener("click", () => {
        if (activeAudio && activeAudio.volume > 0) activeAudio.volume -= 0.1;
    });

    document.getElementById("seek-forward").addEventListener("click", () => {
        if (activeAudio) activeAudio.currentTime += 5;
    });

    document.getElementById("seek-backward").addEventListener("click", () => {
        if (activeAudio) activeAudio.currentTime -= 5;
    });

    document.getElementById("speed-up").addEventListener("click", () => {
        if (activeAudio && activeAudio.playbackRate < 2.0) {
            activeAudio.playbackRate += 0.1;
        }
    });

    document.getElementById("speed-down").addEventListener("click", () => {
        if (activeAudio && activeAudio.playbackRate > 0.5) {
            activeAudio.playbackRate -= 0.1;
        }
    });

    document.getElementById("mute").addEventListener("click", () => {
        if (activeAudio) activeAudio.muted = !activeAudio.muted;
    });
});

let currentIndexSVG = 0;
let currentIndexPNG = 0;

function moveSlideSVG(direction) {
    const items = document.querySelectorAll('.carousel-svgs .carousel-item');
    const totalItems = items.length;

    currentIndexSVG += direction;

    if (currentIndexSVG < 0) {
        currentIndexSVG = totalItems - 1;
    } else if (currentIndexSVG >= totalItems) {
        currentIndexSVG = 0;
    }

    const newTransformValue = -currentIndexSVG * 100;
    document.querySelector('.carousel-svgs .carousel-images').style.transform = `translateX(${newTransformValue}%)`;
}

function moveSlidePNG(direction) {
    const items = document.querySelectorAll('.carousel-pngs .carousel-item');
    const totalItems = items.length;

    currentIndexPNG += direction;

    if (currentIndexPNG < 0) {
        currentIndexPNG = totalItems - 1;
    } else if (currentIndexPNG >= totalItems) {
        currentIndexPNG = 0;
    }

    const newTransformValue = -currentIndexPNG * 100;
    document.querySelector('.carousel-pngs .carousel-images').style.transform = `translateX(${newTransformValue}%)`;
}

window.onload = function () {
    document.querySelector('.carousel-svgs .carousel-images').style.transform = `translateX(0%)`;
    document.querySelector('.carousel-pngs .carousel-images').style.transform = `translateX(0%)`;
};

document.addEventListener("DOMContentLoaded", () => {
    const formulario = document.querySelector(".contact-form");

    formulario.addEventListener("submit", (event) => {
        event.preventDefault(); // Prevenir el envío real del formulario
        // Muestra una alerta usando sweetAlert
        Swal.fire({
            title: '¡Mensaje Enviado!',
            text: 'Gracias por tu mensaje, nos pondremos en contacto contigo pronto.',
            icon: 'success',
            confirmButtonText: 'Cerrar'
        });
    });
});

