#pragma strict

var style: GUISkin;
var current_score: int = 0;
static var current_enemies: int = 65;

function OnGUI () {
    GUI.skin = style;
    GUI.Label(Rect(10, 20, 200, 50), "SCORE < " + current_score.ToString() + " >");
}

function Update() {

    if (current_enemies == 0) {
        print("You win");
    }
}
