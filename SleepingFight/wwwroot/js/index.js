﻿
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
const enemyBulletController = new bulletController(canvas, 7, "white", false);
const enemyController = new EnemyController(canvas, enemyBulletController, playerBulletController);
const player = new Player(canvas, 3, playerBulletController);

let isGameOver = false;
let Won = false;

function game() {
    checkGameOver();
    ctx.drawImage(background, 0, 0, canvas.width, canvas.height);
    displayGameOver();
    if (!isGameOver) {   
    enemyController.draw(ctx);
    player.draw(ctx);
    playerBulletController.draw(ctx);
        enemyBulletController.draw(ctx);
    }
}

function displayGameOver() {
    if (isGameOver) {
        let text = Won ? "You Win!!!" : "Game Over";
        let textOffset = Won ? 3.5 : 5;

        ctx.fillStyle = "white";
        ctx.font = "70px Arial";
        ctx.fillText(text, canvas.width / textOffset, canvas.height / 2);
    }
}

function checkGameOver() {
    if (isGameOver) {
        return;
    }
    if (enemyBulletController.collideWith(player)) {
        isGameOver = true;
    }

    if (enemyController.collideWith(player)) {
        isGameOver = true;
    }

    if (enemyController.enemyRows.length === 0) {
        Won = true;
        isGameOver = true;
    }
}

setInterval(game, 1000 / 60);