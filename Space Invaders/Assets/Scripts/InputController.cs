using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	public InputField entrada;
	public Text salida;

	public void GetInput(string input)
    {     
		Application.LoadLevel("leaderboard");
		Player aux = new Player (input, Database.current_score);
		Leaderboard.instantiateList ();
		if (Leaderboard.addPlayer (aux)) {
			Debug.Log("Se ha creado un jugador y se ha añadido al ranking");
		} else {
			Debug.Log("El jugador no se ha añadido al ranking");
		}
		//Cargar escena clasificacion
    }
    
	public void Clear(){
		entrada.text = "";
	}

}
