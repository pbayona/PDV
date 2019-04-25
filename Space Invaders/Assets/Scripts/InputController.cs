using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

	public InputField entrada;//El objeto que tiene el campo de texto que utilizamos para pillar el input del player
	public Text salida; //Mostrar mensaje de error si entrada vacia y ok pulsado
	public GUIStyle labStyle;

	private int intAux=0; //entero auxiliar que me ayuda a saber si ya se ha añadido un jugador al ranking o no
	private int nPlayers;


	public void ok(){ /* Este metodo recibe por teclado un texto que será el nombre del jugador, si el nombre no es
	vacío, se carga la escena del ranking y se instancia la lista que contiene a los 10 mejores jugadores (esta lista se instancia 
	cada vez que se accede al ranking, es asumible ya que solo hay 10 jugadores). Para más info ir al script Leaderboard*/
		if(entrada.text.Length > 10)
        {
            salida.text = "The name must be shorter than 10 letters.";
        }

        else if (entrada.text != null && entrada.text != "" ) {
			if (Database.getTwoPlayers( )) {
				nPlayers = 2;
			} else {
				nPlayers = 1;
			}

			Player aux;
			if (intAux > 0) {
				aux = new Player (entrada.text, Database.getScore2 ());
			} 
			else {
				aux = new Player (entrada.text, Database.getScore1 ());
			}
			Leaderboard.instantiateList ();
			if (Leaderboard.addPlayer (aux)) {
				Debug.Log ("Se ha creado un jugador y se ha añadido al ranking");
			} else {
				Debug.Log ("El jugador no se ha añadido al ranking");
			}
			intAux++;
			if (intAux == nPlayers) { 
				SceneManager.LoadScene ("leaderboard", LoadSceneMode.Single);
			} else {
				salida.text = "Please introduce the name of the player 2";
			}
		} 
		else {
			salida.text = "Please introduce your name before pressing the OK button";
		}
	}

	public void Clear(){
		entrada.text = "";
		salida.text = "";

	}
		
}
