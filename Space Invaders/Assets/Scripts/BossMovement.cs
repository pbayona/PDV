using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	Vector3 temp;
	public int distance;
	// Use this for initialization
	void Start () {
		temp = transform.position;
		distance = 16;
	}
	
	// Update is called once per frame
	void Update () {
		temp.y -= distance / 4 * Time.deltaTime;
		transform.position = temp; 
	}
}
