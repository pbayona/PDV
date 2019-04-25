using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawn : MonoBehaviour {

	public GameObject boss;
	public Vector3 respawn;

	void Start()
	{
		respawn.x = 12.3f;
		respawn.y = 9.49f;
		respawn.z = 8.8f;
	}
	public void callRespawn() //Llama al contador de respawn del boss
	{
		StartCoroutine(bossRespawn(10));
	}

	IEnumerator bossRespawn(int time)
	{
		yield return new WaitForSecondsRealtime(time);
		Instantiate(boss, respawn, Quaternion.Euler(0, 0, 90));
	}
}
