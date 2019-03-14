using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    //public EnemyMovement enemyMovement;
    void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {

        if (gameObject.tag != "Boss")
        {
            if (col.gameObject.name == "Left_Barrier")
            {
                EnemyMovement.goLeft = false;
                EnemyMovement.goDown = true;
            }
            else if (col.gameObject.name == "Right_Barrier")
            {
                EnemyMovement.goLeft = true;
                EnemyMovement.goDown = true;
            }
            else if (col.gameObject.name == "Player")
            {
                Database.hitPlayer();
            }
            else if (col.gameObject.tag == "Barrier")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
