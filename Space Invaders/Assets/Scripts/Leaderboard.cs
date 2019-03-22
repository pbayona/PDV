using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
	public const int MAX_PLAYERS = 10;
	public static int current_players = 0;
	public static int highest_score;
	public static List<Player> players;
	public GUIStyle pStyle;
	public GUIStyle labStyle;
		
	static void sort()
	{
		players.Sort (sortByScore);
	}

	static int sortByScore(Player p1, Player p2){ //Ordenar jugadores por puntuacion
		return p2.getScore ().CompareTo (p1.getScore());
	}

	static void save(){
		int i = 0;
		foreach (Player player in players) {
			PlayerPrefs.SetInt ("Score"+i.ToString(),player.getScore());
			PlayerPrefs.SetString (i.ToString(),player.getName());
			i++;
		}
		PlayerPrefs.SetInt ("current_players",current_players);
	}

	static void load()
	{
		current_players = PlayerPrefs.GetInt ("current_players");
		if (current_players > 0) { //Llamo a todos los player prefs y los meto en la lista, luego los ordeno
			for (int i = 0; i < current_players; i++) { //Estan guardados con key en nombre 0,1, 2, 3, 4, etc. y con key en score0, score1, score2, score3
				players.Add (new Player(PlayerPrefs.GetString(i.ToString()),PlayerPrefs.GetInt("Score" + i.ToString())));
			}
			sort ();
		}
	}

	public static bool addPlayer(Player p)
	{		
		print (current_players);
		if (current_players < 10) { //Si hay menos de 10 players, se mete directamente
			players.Add (p);
			sort ();
			save ();
			current_players++;
			return true;
		} else if (current_players == 10){
			/* Hay que ver si puede entrar en el ranking por su puntuacion, si es así habrá que
			borrar el de puntuacion mas baja y meter a este	*/
			if (p.getScore () > getLowerScore()) {
				print ("Score de entrada: " + p.getScore ());
				print ("Score mas bajo en la lista: " + getLowerScore ());
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
			GUI.Label(new Rect(40, (100 + incremento), 400, 200),"Name < " + player.getName() + " > " + "-----" + " Points < " + player.getScore().ToString() + " >", pStyle);
			incremento += 25;
		}

	}

	public static void instantiateList()
	{
		players = new List<Player> ();
		current_players = PlayerPrefs.GetInt ("current_players");
		load (); // Al cargar el script lleno la lista de usuarios guardados con los playerPrefs
	}

	private static int getLowerScore()
	{
		int higherIndex = players.Count - 1;
		int k = 0;
		foreach (Player player in players) { //Metodo que devuelve la puntuacion mas baja de todos los elementos de nuestra lista de usuarios
			if (k == higherIndex) {
				return player.getScore ();
			}
			k++;
		}
		return -1;
	}

	private void deleteAllPlayerPrefs() //Este metodo borra todo lo que tenemos guardado en disco, nunca lo llamo lol pero ahi lo dejo
	{
		PlayerPrefs.DeleteAll ();
	}
}

