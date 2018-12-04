using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on an en enemy npc
//INTENT: destroy the enemy after 4 seconds 
public class EnemyDeath : MonoBehaviour {

	public int DeathTimer = 3; 
	// Use this for initialization
	void Start () {
		
	}

	IEnumerator DeathCorotine() //a coroutine that waits while we die 
	{
		yield return new WaitForSeconds(DeathTimer); //waits for the appropriate amount of seconds
		Destroy(this.gameObject);  //destroys game object
	}

	public void OnCollisionEnter (Collision collision)
	{
		StartCoroutine(DeathCorotine () ); //start the coroutine 
	}
}
