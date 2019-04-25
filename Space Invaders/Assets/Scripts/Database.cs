using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Database : MonoBehaviour
{
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
	private static bool twoPlayers = false;

    private static float enemy_shotMinTime;
    private static float enemy_shotMaxTime;
    private static float enemy_horizontalMovementFrecuency = 40.0f;
    private static int chancesOfShooting;
    private Camera myCamera;

    private static float current_enemies = 63;
    private static float max_enemies = 63;

    private static int p1current_score;
	private static int p2current_score;
    private static int current_health;

    private GUISkin style;
    private static int collisions;
    private GameObject[] aliens;
    private static List<GameObject> enemies;
    private static bool multiple; //Colision multiple en barreras o no
    private static int aux; //Almacenar el ultimo material cambiado
   

    void Start()
    {
        enemies = new List<GameObject>();
        aliens = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < aliens.Length; i++)
        {
            enemies.Add(aliens[i]);
        }
        aliens = null;
        enemy_shotMinTime = 20.0f;
        enemy_shotMaxTime = 50.0f;
        multiple = false;

        collisions = 0;
        p1current_score = 0;
		p2current_score = 0;
		if (twoPlayers == true) {
			current_health = 2;
		} else {
			current_health = 1;
		}
        recalculateFrecuency();
        recalculateChances();
    }

    void Update()
    {

        if (current_health <= 0)
        {
			SceneManager.LoadScene ("user_input",LoadSceneMode.Single);
        }
    }

    //Custom getters and setters

    public static void recalculateChances()
    {
		Database.chancesOfShooting = (int)(current_enemies*2);
        Database.enemy_shotMinTime = ((current_enemies / max_enemies) * 19.0f + 1.0f);
        Database.enemy_shotMaxTime = ((current_enemies / max_enemies) * 45.0f + 5.0f);
    }

	public static void killedEnemy(int aux) //Este aux me indica si el que ha matado ha sido el jugador 0 o 1
    {
		if (getTwoPlayers ()) {
			if (aux == 1) {
				p1current_score += 100; 
				Score2.p1current_score = p1current_score;
			} else {
				p2current_score += 100; 
				Score2.p2current_score = p2current_score;
			}
		} 
		else {
			p1current_score += 100; 
			Score.p1current_score = p1current_score;
		}
        
        Database.current_enemies -= 1;
        Database.recalculateChances();
        Database.recalculateFrecuency();
    }
		
    public static void hitPlayer()
    {
        Database.current_health--;
    }

    public static void recalculateFrecuency()
    {
        Database.enemy_horizontalMovementFrecuency = ((current_enemies / max_enemies) * 35 + 5);
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

	public static void setTwoPlayers(bool boolean)
	{
		Database.twoPlayers = boolean;
	}

	public static bool getTwoPlayers()
	{
		return Database.twoPlayers;
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

    public static int getChancesOfShooting()
    {
        return chancesOfShooting;
    }

    public static float getHorizontalMovementFrecuency()
    {
        return enemy_horizontalMovementFrecuency;
    }

    public static int getScore1()
    {
        return p1current_score;
    }

	public static int getScore2()
	{
		return p2current_score;
	}

    public static void setScore1(int score)
    {
        p1current_score += score;
    }

	public static void setScore2(int score)
	{
		p2current_score += score;
	}
				
    public static List<GameObject> getEnemies()
    {
        return enemies;
    }
		
    private void CollisionColor()
    {
        int j;
        if (!multiple)
        {
            do
            {
                j = Random.Range(0, 4); //Generamos una entero aleatorio que se encarga de aplicar a todos los aliens el mismo material
            } while (j == aux);
            foreach (GameObject enemy in enemies)
            {
                enemy.SendMessage("ChangeColor", j);
            }
            aux = j;
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SendMessage("RandomChangeColor");
            }
        }
    }

    public IEnumerator CollisionCounter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        if (collisions > 1)
        {
            multiple = true;
            CollisionColor();
            //Debug.Log ("multiple: " + collisions);
        }
        else if (collisions == 1)
        {
            multiple = false;
            CollisionColor();
            //Debug.Log ("single: " + collisions);
        }
        collisions = 0;
        //Debug.Log ("Restart: " + collisions);
    }

    IEnumerator auxCounter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
    }

    public void call()
    { //LLamado para llamar al contador de colisiones
        StartCoroutine(CollisionCounter(0.1f));
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
	public static void invertTwoPlayers()
	{
		if (twoPlayers) {
			twoPlayers = false;
		} else {
			twoPlayers = true;
		}
	}

	public static void reset() /* Metodo llamado desde leaderboard y pause menu cada vez que se reinicia una partida para que resetee los puntos */
	{
		p1current_score = 0;
		p2current_score = 0;
	}
}