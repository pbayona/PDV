using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    private int bounces = 0;
    private const int MAX_BOUNCES = 5;
    protected int speed;                  //Inicializar en cada clase a su valor correspondiente

    public void colBarrier(Collider col)
    {
        Database.incrementCollisions();
        if (Database.getCollisions() == 1)
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            //Database.call ();
            camera.SendMessage("call");
        }
        Destroy(gameObject);
        Destroy(col.gameObject);
    }
    public void colBound(Collider col)
    {
        bounces++;

        if (bounces < MAX_BOUNCES && Database.getBouncingBullets())
        {
            Rigidbody bulletRig = GetComponent<Rigidbody>();

            Vector3 bulletToPlayer = new Vector3(Main_PlayerMovement.position.x - transform.position.x,
                Main_PlayerMovement.position.y - transform.position.y, 0);
            bulletToPlayer = Vector3.Normalize(bulletToPlayer);

            bulletRig.velocity = Vector3.zero;

            bulletRig.AddForce(bulletToPlayer * (speed + bounces * 50));
            transform.LookAt(transform.position + bulletToPlayer);
            transform.Rotate(90, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public abstract void colPlayer(Collider col);
    public abstract void colPlayerBullet(Collider col);
}
