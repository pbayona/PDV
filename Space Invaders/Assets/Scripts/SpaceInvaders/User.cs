using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    private string name;
    private int score;
	
    public User(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public User(string name)
    {
        this.name = name;
    }

    public void setName(string n)
    {
        name = n;
    }
    public string getName()
    {
        return name;
    }
    public void setScore(int s)
    {
        score = s;
    }
    public int getScore()
    {
        return score;
    }

}
