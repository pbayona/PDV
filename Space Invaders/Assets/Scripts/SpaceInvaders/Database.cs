﻿using System.Collections;
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
        public static string lastLoadedGame; //Evita tener que hacer 2 escenas distintas para el finished de kids game y normal game

        public GUISkin style;
		public static int collisions;
		private GameObject[] aliens;
		public static List<GameObject> enemies;
		private static bool multiple; //Colision multiple en barreras o no
		private static int aux; //Almacenar el ultimo material cambiado

		void Start()
		{
			enemies = new List<GameObject> ();
			aliens = GameObject.FindGameObjectsWithTag("Enemy");
			for (int i = 0; i < aliens.Length; i++)
			{
				enemies.Add (aliens [i]);
			}
            enemy_shotMinTime = 20.0f;
            enemy_shotMaxTime = 50.0f;
			multiple = false;
			
			collisions = 0;
            current_score = 0;
            current_enemies = 65;
            current_health = 1;
            lastLoadedGame = Application.loadedLevelName;   //En database almacenamos si se ha cargado la escena para niños o de mayores de 13 y luego en finish game pedimos el nombre

            recalculateFrecuency();
            recalculateChances();
			//StartCoroutine(Counter(0.1f));
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
					Debug.Log ("multiple: " + collisions);
				} else if(collisions == 1){
					multiple = false;
					CollisionColor ();
					Debug.Log ("single: " + collisions);
				}				
				collisions = 0;
				Debug.Log ("Restart: " + collisions);
		}

		public void call(){
			StartCoroutine (CollisionCounter (0.1f));
		}
}

    