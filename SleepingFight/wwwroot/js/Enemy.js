export default class Enemy{
    constructor(x,y){
        this.x = x;
        this.y = y;
        this.width = 30;
        this.height = 30;

        this.image = new Image();
        this.image.src = `/Images/enemy.png`;
    }

    draw(ctx){
        ctx.drawImage(this.image, this.x, this.y, this.width, this.height);
    }

    move(xVelocity, yVelocity){
        this.x += xVelocity;
        this.y += yVelocity;
    }

    collideWith(sprite) {
        if (this.x + this.width > sprite.x && this.x < sprite.x + sprite.width &&
            this.y + this.height > sprite.y && this.y < sprite.y + sprite.height) {
            return true;
        }
        else {
            return false;
        }
    }
}