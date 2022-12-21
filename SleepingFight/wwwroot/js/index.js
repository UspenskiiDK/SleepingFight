
import EnemyController from "/js/EnemyController.js";
import Player from "/js/Player.js";
import bulletController from "/js/BulletController.js";

const canvas = document.getElementById("game");
const ctx = canvas.getContext("2d");

canvas.width = 500;
canvas.height = 500;

const background = new Image();
background.src = "/Images/back.jpg";

const playerBulletController = new bulletController(canvas, 10, "yellow", true);
const enemyController = new EnemyController(canvas);
const player = new Player(canvas, 3, playerBulletController);


function game() {
    ctx.drawImage(background, 0, 0, canvas.width, canvas.height);
    enemyController.draw(ctx);
    player.draw(ctx);
    playerBulletController.draw(ctx);
}

setInterval(game, 1000 / 60);