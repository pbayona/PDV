using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused;
	public GameObject pauseMenuUI;

	void Start () {
		gameIsPaused = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			if(gameIsPaused)
			{
				resume ();
			}
			else{
				pause ();
			}
		}
	}

	public void resume()
	{
		Time.timeScale = 1f;
		pauseMenuUI.SetActive (false);
		gameIsPaused = false;
	}

	public void retry()
	{
		Database.reset(); //resetear puntuacion
		Time.timeScale = 1f;
		if (Database.getTwoPlayers ()) {
			SceneManager.LoadScene ("main_game_2players",LoadSceneMode.Single);
		} else {
			SceneManager.LoadScene ("main_game",LoadSceneMode.Single);
		}

	}

	public void pause()
	{
		Time.timeScale = 0f;
		pauseMenuUI.SetActive (true);
		gameIsPaused = true;
	}
}
