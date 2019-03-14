using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{
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
        }
    }
}
