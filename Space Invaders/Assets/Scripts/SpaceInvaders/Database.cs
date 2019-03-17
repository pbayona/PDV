using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {
        public static float enemy_shotMinTime;
		public static float enemy_shotMaxTime;
		public static float enemy_horizontalMovementFrecuency = 40.0f;
        public static int chancesOfShooting;

        public static float current_enemies = 65;
        public static float max_enemies = 65;

        public static int current_score;
        public static int current_health;
        public static string lastLoadedGame;                //Evita tener que hacer 2 escenas distintas para el finished de kids game y normal game

        public GUISkin style;

        void Start()
        {
            enemy_shotMinTime = 20.0f;
            enemy_shotMaxTime = 50.0f;

            current_score = 0;
            current_enemies = 65;
            current_health = 1;
            lastLoadedGame = Application.loadedLevelName;   //En database almacenamos si se ha cargado la escena para niños o de mayores de 13 y luego en finish game pedimos el nombre

            recalculateFrecuency();
            recalculateChances();
        }

        void Update()
        {
            if (current_enemies == 0)
            {
                Application.LoadLevel("win_game");
            }
            if (current_health <= 0)
            {
                Application.LoadLevel("lose_game");
                Destroy(GameObject.Find("Player"));
                //current_health = -1;
            }
        }

        //Modifiers

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

        //GUI

        public void OnGUI()
        {
            GUI.skin = style;
            GUI.Label(new Rect(10, 20, 200, 50), "SCORE < " + current_score.ToString() + " >");
            GUI.Label(new Rect(10, 700, 200, 50), "LIVES < " + current_health.ToString() + " >");
        }
    }