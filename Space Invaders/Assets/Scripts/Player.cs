using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private string pjName;
	private  int score;

	#region UI

	public Player(string n, int s)
	{
		pjName = n;
		score = s;
	}

	public void setName(string n)
	{
		pjName = n;
	}

	public void setScore(int s)
	{
		score = s;
	}

	public string getName()
	{
		return pjName;
	}

	public int getScore()
	{
		return score;
	}

	#endregion

}
