#pragma strict

var style: GUIStyle;
var labStyle: GUIStyle;
var pStyle: GUIStyle;
var label_text: String = "YOU LOSE";
var points: int; //Variable que me permite no hacer 2 finishGames, si la puntuacion es
//0 es que no has matado a ningún marciano (modo niños) y por lo tanto
//no se muestra el label
//GUI

function OnGUI() {
    GUI.Label(Rect(20, 20, 1000, 500), label_text, labStyle);
    points = Database.current_score;

    if (points > 0) {
        GUI.Label(Rect(40, 200, 500, 250),"Points < " +  points.ToString() + " >", pStyle);
        //Linea comentada que da fallo SOLO al ganar la partida, al perderla muestra los puntos sin problema
        //pero al ganarla crashea
    }
        
    if(GUI.Button(Rect(50, 350, 370, 85), "RETRY", style)){
        //Reload
        Application.LoadLevel(Database.lastLoadedGame);
    }
    if(GUI.Button(Rect(50, 600, 670, 85), "QUIT GAME", style)){
        //Reload
        Application.LoadLevel("start_window");
    }
}

