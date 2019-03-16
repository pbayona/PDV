#pragma strict

var enemy_bullet: GameObject;

private var countdown: int;


function Start() {
    //Asign enemies to the list
    countdown = Random.Range(Database.enemy_shotMinTime, Database.enemy_shotMaxTime);
}

function Update() {
    if (countdown <= 0) {
        //Dispara
        if (Random.Range(0, Database.chancesOfShooting) == 0) {
            var fire_bullet = Instantiate(enemy_bullet, transform.position, Quaternion.identity);
            fire_bullet.GetComponent(Rigidbody).AddForce(-Vector3.up * 400);
        }

        //Instancia un nuevo timer
        countdown = Random.Range(Database.enemy_shotMinTime, Database.enemy_shotMaxTime);
    } else {
        countdown--;
    }
}