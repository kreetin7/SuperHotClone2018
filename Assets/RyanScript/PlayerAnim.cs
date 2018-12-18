using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

	public Animator anim;

	Rigidbody playerRigidBody;

	void Start()
	{
		anim = GetComponent<Animator>();// gets animator and turns it on
		anim.enabled = false;

		playerRigidBody = GetComponent<Rigidbody>();
	}
	
		
	IEnumerator DeathCorotine() //player dies
	{
		anim.enabled = true; 
		anim.SetBool("isDead", true);
		yield return new WaitForSecondsRealtime(3f);

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("npcBullet"))
		{
			StartCoroutine(DeathCorotine()); //go to coroutine

			//This part doesn't work
			playerRigidBody.constraints = RigidbodyConstraints.FreezePositionZ | 
			                              RigidbodyConstraints.FreezePositionX |
			                              RigidbodyConstraints.FreezePositionY;
			
			

		}
	}

}
