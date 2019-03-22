﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	public InputField entrada;
	public Text salida;

	public void GetInput(string input)
    {     
		if (Leaderboard.addPlayer (new Player (Leaderboard.current_players.ToString (), Database.current_score))) {
			print ("Se ha creado un jugador y se ha añadido al ranking");
		} else {
			print ("El jugador no se ha añadido al ranking");
		}
		//Cargar escena clasificacion
		Application.LoadLevel("leaderboard");
    }
    /*
	public void Clear(){
		entrada.text = "";
	}
	*/
}
