#pragma strict

static var enemy_shotMinTime: int;
static var enemy_shotMaxTime: int;
static var enemy_horizontalMovementFrecuency: int = 40;
static var chancesOfShooting: int;

static var current_enemies: double = 65;
static var max_enemies: double = 65;

static var current_score: int;
static var current_health: int;
static var lastLoadedGame: String; //Evita tener que hacer 2 escenas distintas para el finished de kids game y normal game

var style: GUISkin;

function Start() {
    enemy_shotMinTime = 20;
    enemy_shotMaxTime = 50;
    
    current_score = 0;
    current_enemies = 65;
    current_health = 1;
    lastLoadedGame = Application.loadedLevelName; //En database almacenamos si se ha cargado la escena para niños o de mayores de 13 y luego en finish game pedimos el nombre

    recalculateFrecuency();
    recalculateChances();
}

function Update() {
    if (current_enemies == 0) {
        Application.LoadLevel("win_game");
    }
    if (current_health == 0) {
        Application.LoadLevel("lose_game");
        Destroy(gameObject.Find("Player"));
        //current_health = -1;
    }
}

//Modifiers
    
static function recalculateChances() {
    chancesOfShooting = (Score.current_enemies*2);
    enemy_shotMinTime= ((current_enemies / max_enemies) * 19 + 1);
    enemy_shotMaxTime= ((current_enemies / max_enemies) * 45 + 5);
}

static function killedEnemy() {
    current_score += 100;
    current_enemies -= 1;
    recalculateChances();
    recalculateFrecuency();
}

static function hitPlayer() {
    current_health--;
}

static function recalculateFrecuency() {
    enemy_horizontalMovementFrecuency = ((current_enemies / max_enemies) * 35 + 5);
}

//GUI

function OnGUI() {
    GUI.skin = style;
    GUI.Label(Rect(10, 20, 200, 50), "SCORE < " + current_score.ToString() + " >");
    GUI.Label(Rect(10, 700, 200, 50), "LIVES < " + current_health.ToString() + " >");
}

