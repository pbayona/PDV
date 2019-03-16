#pragma strict

static var goLeft: boolean = false;
static var goDown: boolean = false;
var is_boss: boolean=false;
var distance: int = 10;
var counter: int = 0;
var FRECUENCY: int;

function Update () {
    FRECUENCY = Database.enemy_horizontalMovementFrecuency;
    if (!is_boss) {  
        if (goLeft) {
            if (counter >= FRECUENCY) {
                transform.position.x -= distance * Time.deltaTime;
                counter = 0;
            } else {
                counter++;
            }
        }
        else {
            if (counter >= FRECUENCY) {
                transform.position.x += distance * Time.deltaTime;
                counter = 0;
            } else {
                counter++;
            }
        }

    if (goDown) {       
        transform.position.y -= distance * 2 * Time.deltaTime;
        goDown = false;
        }
    }
    else{
        transform.position.x -= distance / 4 * Time.deltaTime;
    }
    
}
