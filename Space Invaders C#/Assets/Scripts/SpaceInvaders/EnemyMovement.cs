using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static bool goLeft = false;
    public static bool goDown = false;
    public bool is_boss = false;
    public int distance = 10;
    public float counter = 0.0f;
    public float FRECUENCY;
	Vector3 temp;

	void Start ()
	{
		temp = transform.position;
        goLeft = true;
	}
    void Update()
    {
        FRECUENCY = Database.enemy_horizontalMovementFrecuency;
        if (!is_boss)
        {
            if (goLeft)
            {
                if (counter >= FRECUENCY)
                {
                    temp.x -= distance * Time.deltaTime;
                    counter = 0.0f;
                }
                else
                {
                    counter++;
                }
            }
            else
            {
                if (counter >= FRECUENCY)
                {
                    temp.x += distance * Time.deltaTime;
                    counter = 0.0f;
                }
                else
                {
                    counter++;
                }
            }

            if (goDown)
            {
                temp.y -= distance * 2 * Time.deltaTime;
                goDown = false;
            }
        }
        else
        {
            temp.x -= distance / 4 * Time.deltaTime;
        }

    }
}
