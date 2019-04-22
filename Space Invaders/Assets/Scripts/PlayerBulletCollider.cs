using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : Bullet
{
    private static GameObject player;  
    private bool friendlyFire;         

	private int aux;    


    void Start()
	{
        speed = 500;

        player = GameObject.FindWithTag("Player");  
        StartCoroutine(Counter(1));                 
        aux = 0;                                    
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
        }
    }
    public override void colPlayerBullet(Collider col)
    {
        Destroy(gameObject);
    }

    void colEnemy(Collider col)
    {
        Database.enemies.Remove(col.gameObject);
        AudioManager.PlayKill();
        Database.killedEnemy();
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
        Database.current_score += 150;
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
