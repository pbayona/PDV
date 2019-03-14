﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartWindow : MonoBehaviour {

    public GUIStyle style;
    public GUIStyle style1;

	void OnGUI () {

        GUI.Label(new Rect(60, 80, 1000, 500), "Space Invaders", style);

        if (GUI.Button(new Rect(50, 300, 780, 71), "- Play: +13 game", style1))
        {
            Application.LoadLevel("main_game");
            //SceneManager.LoadScene("main_game", LoadSceneMode.Additive);
        }
        if (GUI.Button(new Rect(50, 450, 1000, 90), "- Play: non-violent\ngame", style1))
        {
            Application.LoadLevel("kids_game");
        }
    }
	
}
