const canvas = document.getElementById("game");
const ctx = canvas.getContext("2d");

canvas.width = 500;
canvas.height = 500;

const background = new Image();
background.src = "Images/back.jpg";


function game() {
    ctx.drawImage(background, 0, 0, canvas.width, canvas.height);
}

setInterval(game, 1000 / 60);