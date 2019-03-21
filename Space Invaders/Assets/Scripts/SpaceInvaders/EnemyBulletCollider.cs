﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{
    private int bounces = 0;
    private const int MAX_BOUNCES = 5;
    private const int SPEED = 300;

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Player")
        {
            Database.hitPlayer();
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Bullet(Clone)")
        {
            AudioManager.PlayExplosion();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Barrier")
        {	
			
            Destroy(gameObject);
            Destroy(col.gameObject);
			Database.collisions++;
        }
        else if (col.gameObject.tag == "Bound")
        {
            bounces++;

            if (bounces < MAX_BOUNCES)
            {
                Rigidbody bulletRig = GetComponent<Rigidbody>();

                Vector3 bulletToPlayer = new Vector3(Main_PlayerMovement.position.x - transform.position.x,
                    Main_PlayerMovement.position.y - transform.position.y, 0);
                bulletToPlayer = Vector3.Normalize(bulletToPlayer);

                bulletRig.velocity = Vector3.zero;

                bulletRig.AddForce(bulletToPlayer * (SPEED + bounces * 50));
                transform.LookAt(transform.position + bulletToPlayer);
                transform.Rotate(90, 0, 0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
