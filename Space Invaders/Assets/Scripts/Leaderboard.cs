using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
	public const int MAX_PLAYERS = 10;
	public static int current_players = 0;
	public static int highest_score;
	public static int lowest_score;
	public static List<Player> players;
	public GUIStyle pStyle;
	public GUIStyle labStyle;
	// Use this for initialization
	void Start ()
	{
		players = new List<Player> ();
		current_players = PlayerPrefs.GetInt ("current_players");
		load (); // Al cargar el script lleno la lista de usuarios guardados 
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		current_players = players.Count;
		PlayerPrefs.SetInt ("current_players",current_players);
		PlayerPrefs.SetInt ("highest_score",highest_score);
		PlayerPrefs.SetInt ("lowest_score",lowest_score);
	}

	static void sort()
	{
		players.Sort (sortByScore);
	}

	static int sortByScore(Player p1, Player p2){ //Ordenar jugadores por puntuacion
		return p1.getScore ().CompareTo (p2.getScore());
	}

	static void save(){
		int i = 0;
		foreach (Player player in players) {
			PlayerPrefs.SetInt ("Score"+i.ToString(),player.getScore());
			PlayerPrefs.SetString (i.ToString(),player.getName());
			i++;
		}
	}

	static void load()
	{
		if (current_players > 0) {
			for (int i = 0; i < current_players; i++) { //Estan guardados con key en nombre 1, 2, 3, 4, etc. y con key en score1, score2, score3
				players.Add (new Player(PlayerPrefs.GetString(i.ToString()),PlayerPrefs.GetInt("Score" + i.ToString())));
			}
			sort ();
		}
	}

	public static bool addPlayer(Player p)
	{		
		if (current_players < 10) { //Si hay menos de 10 players, se mete directamente
			players.Add (p);
			sort ();
			save ();
			return true;
		} else if (current_players == 10){
			int puntuacion = p.getScore (); /* Hay que ver si puede entrar en el ranking por su puntuacion, si es así habrá que
			borrar el de puntuacion mas baja y meter a este	*/
			if (p.getScore () > lowest_score) {
				players.RemoveAt (9); 
				players.Add (p);
				sort ();
				save ();
				return true;
			}
		}
		return false;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(20, 20, 1000, 500), "RANKING", labStyle);
		int incremento = 0;
		foreach (Player player in players) {
			GUI.Label(new Rect(40, (150 + incremento), 500, 250),"Name < " + player.getName() + " > " + "-----" + " Points < " + player.getScore().ToString() + " >", pStyle);
			incremento += 10;
		}

	}
}

