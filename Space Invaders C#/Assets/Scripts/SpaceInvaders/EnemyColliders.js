#pragma strict

var enemyMovement: EnemyMovement;

function OnTriggerEnter(col: Collider) {

    if (gameObject.tag != "Boss") {
        if (col.gameObject.name == "Left_Barrier") {
            enemyMovement.goLeft = false;
            enemyMovement.goDown = true;
        }
        else if (col.gameObject.name == "Right_Barrier") {
            enemyMovement.goLeft = true;
            enemyMovement.goDown = true;
        }
        else if (col.gameObject.name == "Player") {
            Database.hitPlayer();
        }
        else if (col.gameObject.tag == "Barrier") {
            Destroy(col.gameObject);
        }
    }
}
