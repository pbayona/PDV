using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static int p1current_score;
	public Text score;

	void Start(){
		p1current_score = 0;
	}

	void Update()
	{
		score.text = "Score < " + p1current_score.ToString() + " >";
	}

}
