﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            AudioManager.PlayKill();
            Database.killedEnemy();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Boss")
        {
            AudioManager.PlayKill();
            Destroy(gameObject);
            Destroy(col.gameObject);
            Database.current_score += 150;
        }
        else if (col.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            //gameObject.GetComponent<>().material.color = Color.yellow;
        }
        else if (col.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
