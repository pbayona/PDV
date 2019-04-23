using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Database : MonoBehaviour {
    /*Singletone variables*/
    private static int counter = 0;
    private static Database instance = null;
    public static Database getInstance
    {
        get
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }
    }

    private Database()
    {
        counter++;
    }
        
        private static bool bouncingBullets = true;

        private static float enemy_shotMinTime;
	    private static float enemy_shotMaxTime;
	    private static float enemy_horizontalMovementFrecuency = 40.0f;
        private static int chancesOfShooting;
	    private Camera myCamera;
	    private GameObject boss;

        private static float current_enemies = 65;
        private static float max_enemies = 65;

        private static int current_score;
        private static int current_health;
        private static string lastLoadedGame; //Evita tener que hacer 2 escenas distintas para el finished de kids game y normal game

        private GUISkin style;
	    private static int collisions;
	    private GameObject[] aliens;
	    private static List<GameObject> enemies;
	    private static bool multiple; //Colision multiple en barreras o no
	    private static int aux; //Almacenar el ultimo material cambiado
	    private Vector3 respawn;

	    void Start()
	    {            
		    enemies = new List<GameObject> ();
		    aliens = GameObject.FindGameObjectsWithTag("Enemy");
		    for (int i = 0; i < aliens.Length; i++)
		    {
			    enemies.Add (aliens [i]);
		    }
		    aliens = null;
            enemy_shotMinTime = 20.0f;
            enemy_shotMaxTime = 50.0f;
		    multiple = false;
		    respawn.x = 12.3f;
		    respawn.y = 9.49f;
		    respawn.z = 8.8f;
			
		    collisions = 0;
            current_score = 0;
            current_enemies = 65;
            current_health = 1;
            lastLoadedGame = Application.loadedLevelName;   //En database almacenamos si se ha cargado la escena para niños o de mayores de 13 y luego en finish game pedimos el nombre

            recalculateFrecuency();
            recalculateChances();
        }

        void Update()
        {
            if (current_enemies == 0) //esto está deprecated jajaja xd
            {
                Application.LoadLevel("win_game");
			    //Captura de pantalla
            }
            if (current_health <= 0) 
            {	
				/*
			    int [] array = new int[2];
			    array[0] = Screen.width;
			    array[1] = Screen.height;
			    myCamera.SendMessage ("takeScreenshot",array);
			    auxCounter (0.3f); //Este pequeño delay en cambiar de escena es para que renderice el jugador y la bala ya que son destruidas
				*/
				Application.LoadLevel ("user_input");
                Destroy(GameObject.Find("Player"));
            }

        }

    //Custom getters and setters

    public static void recalculateChances()
    {
        chancesOfShooting = (Score.current_enemies * 2);
        enemy_shotMinTime = ((current_enemies / max_enemies) * 19.0f + 1.0f);
        enemy_shotMaxTime = ((current_enemies / max_enemies) * 45.0f + 5.0f);
    }

    public static void killedEnemy()
    {
        current_score += 100;
        current_enemies -= 1;
        recalculateChances();
        recalculateFrecuency();
    }

    public static void hitPlayer()
    {
        current_health--;
    }

    public static void recalculateFrecuency()
    {
        enemy_horizontalMovementFrecuency = ((current_enemies / max_enemies) * 35 + 5);
    }

    public static void incrementCollisions()
    {
        Database.collisions++;
    }

    
    //Default getters and setters

    public static int getCollisions()
    {
        return Database.collisions;
    }

    public static void setBouncingBullets(bool boolean)
    {
        Database.bouncingBullets = boolean;
    }

    public static bool getBouncingBullets()
    {
        return Database.bouncingBullets;
    }

    public static float getShotMinTime()
    {
        return enemy_shotMinTime;
    }

    public static float getShotMaxTime()
    {
        return enemy_shotMaxTime;
    }

    public static float getChancesOfShooting()
    {
        return chancesOfShooting;
    }

    public static float getHorizontalMovementFrecuency()
    {
        return enemy_horizontalMovementFrecuency;
    }

    public static int getScore()
    {
        return current_score;
    }

    public static void setScore(int score)
    {
        current_score += score;
    }

    public static string getLastLoadedGame()
    {
        return lastLoadedGame;
    }

    public static List<GameObject> getEnemies()
    {
        return enemies;
    }

    //GUI

    public void OnGUI()
        {
            GUI.skin = style;
            GUI.Label(new Rect(10, 20, 200, 50), "SCORE < " + current_score.ToString() + " >");
            GUI.Label(new Rect(10, 700, 200, 50), "LIVES < " + current_health.ToString() + " >");
        }

	    private void CollisionColor()
	    {
		    int j;
		    if (!multiple) {
			    do{
				    j = Random.Range(0, 4); //Generamos una entero aleatorio que se encarga de aplicar a todos los aliens el mismo material
			    }while(j == aux);				
			    foreach (GameObject enemy in enemies) {
				    enemy.SendMessage ("ChangeColor",j);
			    }
			    aux = j;
		    } else {
			    foreach (GameObject enemy in enemies) {
				    enemy.SendMessage ("RandomChangeColor");
			    }
		    }
	    }

	    public IEnumerator CollisionCounter(float time)
	    {
			    yield return new WaitForSecondsRealtime (time);
			    if (collisions > 1) {
				    multiple = true;
				    CollisionColor ();
				    //Debug.Log ("multiple: " + collisions);
			    } else if(collisions == 1){
				    multiple = false;
				    CollisionColor ();
				    //Debug.Log ("single: " + collisions);
			    }				
			    collisions = 0;
			    //Debug.Log ("Restart: " + collisions);
	    }

	    IEnumerator auxCounter(float time)
	    {
		    yield return new WaitForSecondsRealtime (time);
	    }

	    public void call(){ //LLamado para llamar al contador de colisiones
		    StartCoroutine (CollisionCounter (0.1f));
	    }

	    public void callRespawn() //Llama al contador de respawn del boss
	    {
		    StartCoroutine (bossRespawn (10));
	    }

	    IEnumerator bossRespawn(int time)
	    {
		    yield return new WaitForSecondsRealtime (time);
		    Instantiate (boss, respawn, Quaternion.Euler (0, 0, 90));
	    }

        public static void invertBouncingBullets()
        {
            if (bouncingBullets)
            {
                bouncingBullets = false;
            }
            else
            {
                bouncingBullets = true;
            }
        }
}

    