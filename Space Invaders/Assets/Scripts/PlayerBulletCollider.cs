using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : Bullet
{
	public bool p1;
    private bool friendlyFire;         

    void Start()
	{
        speed = 500;
        StartCoroutine(Counter(1));                                        
    }



    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            colEnemy(col);
        }
        else if (col.gameObject.tag == "Boss")
        {
            colBoss(col);
        }
        else if (col.gameObject.tag == "Barrier")
        {
            colBarrier(col);
        }
        else if (col.gameObject.tag == "Bound") /*Hay que mirar esto */
        {
            colBound(col);
        }
        else if (col.gameObject.tag == "Player")
        {
            colPlayer(col);
        }
        else if(col.gameObject.tag == "PlayerBullet")
        {
            colPlayerBullet(col);
        }
		else if(col.gameObject.tag == "EnemyBullet")
        {
            colEnemyBullet(col);
        }
        else if (col.gameObject.tag != "Player")
        {
            colElse(col);
        }
    }

    /*Métodos auxiliares para colisiones*/

    public override void colPlayer(Collider col)
    {
        if (friendlyFire)
        {
            Database.hitPlayer();
            Destroy(gameObject);
			Destroy (col.gameObject);
        }
    }
    public override void colPlayerBullet(Collider col)
    {
        Destroy(gameObject);
    }

    void colEnemy(Collider col)
    {
        Database.getEnemies().Remove(col.gameObject);
        AudioManager.PlayKill();
		if (p1 == true) {
			Database.killedEnemy (1);
		} else {
			Database.killedEnemy (2);
		}
        
        Destroy(gameObject);
        Destroy(col.gameObject);
    }
    void colBoss(Collider col)
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera"); /*Pillo la camara ya que necesito llamar a un metodo
				de database y por estáticos peta*/
        camera.SendMessage("callRespawn");
        AudioManager.PlayKill();
        Destroy(gameObject);
        Destroy(col.gameObject);
		if (Database.getTwoPlayers ()) {
			if (p1 == true) {
				Database.setScore1 (150);
				Score2.p1current_score = Database.getScore1 ();
			} else {
				Database.setScore2 (150);
				Score2.p2current_score = Database.getScore2 ();
			}
		} else {
			Database.setScore1 (150);
			Score.p1current_score = Database.getScore1 ();
		}
			
    }

    void colEnemyBullet(Collider col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
    void colElse(Collider col)
    {
        Destroy(gameObject);
        Debug.Log("Colisión no contemplada con " + col.gameObject.name);
    }


    /*Para que al disparar la bala no nos haga daño*/

    IEnumerator Counter(int time)
    {
        yield return new WaitForSeconds(time);
        friendlyFire = true;
    }
}
