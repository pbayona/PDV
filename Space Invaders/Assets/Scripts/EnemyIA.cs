using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour
{
    public GameObject enemy_bullet;
    private float countdown;

    void Start()
    {
        //Asign enemies to the list
        countdown = Random.Range(Database.getShotMinTime(), Database.getShotMaxTime());
    }

    void Update()
    {
        if (countdown <= 0)
        {
			
            if (Random.Range(0, Database.getChancesOfShooting()) == 0)
            {
				GameObject fire_bullet = Instantiate(enemy_bullet, transform.position, Quaternion.Euler(0,0,0));
                fire_bullet.GetComponent<Rigidbody>().AddForce(-Vector3.right * 400);
            }

            //Instancia un nuevo timer
            countdown = Random.Range(Database.getShotMinTime(), Database.getShotMaxTime());
        }
        else
        {
            countdown--;
        }
    }
}
