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
