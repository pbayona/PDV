using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour {

    public void playArcadeGame()
    {
		if (Database.getTwoPlayers()) {
			SceneManager.LoadScene ("main_game_2players",LoadSceneMode.Single);
		} else {			
			SceneManager.LoadScene ("main_game",LoadSceneMode.Single);
		}

    }

    public void playSurvivalGame()
    {
        Debug.Log("Aquí tienes tu tortura.");
		SceneManager.LoadScene ("kids_game",LoadSceneMode.Single);
    }

    public void showConfig(GameObject config)
    {
        if (config.activeInHierarchy)
        {
            config.SetActive(false);
        }
        else
        {
            config.SetActive(true);
        }
    }

	public void twoPlayers()
	{
		Database.invertTwoPlayers ();
	}

    public void bouncingBullets()
    {
        Database.invertBouncingBullets();
    }
}
