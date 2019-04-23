using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : Bullet
{
    private void Start()
    {
        speed = 300;
    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            colPlayer(col);
        }
        else if (col.gameObject.tag == "PlayerBullet")
        {
            colPlayerBullet(col);
        }
        else if (col.gameObject.tag == "Barrier")
        {
            colBarrier(col);
        }
		else if (col.gameObject.tag == "Bound") /*Hay que mirar esto */
        {
            colBound(col);
        }
    }

    public override void colPlayer(Collider col)
    {
        Database.hitPlayer();
        Destroy(gameObject);
    }

    public override void colPlayerBullet(Collider col)
    {
        Debug.Log("Colisión");
        AudioManager.PlayExplosion();
        Destroy(gameObject);
        Destroy(col.gameObject);
    }
}
