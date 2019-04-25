using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour {

	public static int p1current_score;
	public static int p2current_score;
	public Text score1;
	public Text score2;

	void Start(){
		p1current_score = 0;
		p2current_score = 0;
	}

	void Update()
	{
		score1.text = "Score 1 < " + p1current_score.ToString() + " >";
		score2.text = "Score 2 < " + p2current_score.ToString () + " >";
	}
}
