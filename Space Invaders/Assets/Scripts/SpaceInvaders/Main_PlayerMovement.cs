using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main_PlayerMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private CharacterController controller;
    private int playerSpeed = 10;
    public GameObject bullet;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
		movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movement = transform.TransformDirection(movement);  //From local to global coordinates
        movement *= playerSpeed;

        controller.Move(movement * Time.deltaTime);

        if (Input.GetKeyUp("space"))
        {
            AudioManager.PlayShoot();

            GameObject spawn_bullet = Instantiate(bullet, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            spawn_bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }
    }
    
}
