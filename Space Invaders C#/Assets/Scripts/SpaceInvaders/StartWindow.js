#pragma strict

var style: GUIStyle;
var style1: GUIStyle;

function OnGUI() {
    GUI.Label(Rect(60, 80, 1000, 500),"Space Invaders", style);

    if (GUI.Button(Rect(50, 300, 780, 71),"- Play: +13 game", style1)) {
        Application.LoadLevel("main_game");
    }
    if (GUI.Button(Rect(50, 450, 1000, 90),"- Play: non-violent\ngame", style1)) {

        Application.LoadLevel("kids_game");
    }
    
}
