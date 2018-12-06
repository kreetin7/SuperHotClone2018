using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on any pick up objects
//intent: item will lerp to player and be visible in camera. You can then aim and throw the object

public class itemPickUp : MonoBehaviour {
	
	//destination towards 
	public Vector3 destination;
	//player reference for the destination vector3 to be assigned to
	public GameObject player;
	
	//item's rigid body
	private Rigidbody Rb;
	
	//reference to the loopPickUp script so that the object has access to the itemHit bool
	public lookPickUp cameraScript;
	//
	
	public SpawnProjectiles SpawnProjectiles;
	
	//speed in which the object will fly towards the player
	public float pickUpSpeed;
	
	
	//state int 
	//there are three states:
	//1. laying on ground
	//2. moving towards player ("getting picked up")
	//3. in the player's hands ("in the camera view")
	//4. being thrown (use gun as projectile)
	private int itemState = 1;
	
	
	//force of throw
	private float throwForce = 150f;
	//bool to see if item is picked up by player
	public bool isHolding = false;
	
	void Start ()
	{
		//destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void FixedUpdate()
	{
		if (itemState == 1)
		{
			if (cameraScript.itemHit == true)
			{
				itemState = 2;
			}
		}

		if (itemState == 2)
		{
			//old method of transforming towards player without using rigidbodies
			//destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
			//transform.position = Vector3.MoveTowards(transform.position, destination, pickUpSpeed * Time.deltaTime);
			Rb.useGravity = false;
			Vector3 destination = (player.transform.position - transform.position).normalized;
			Rb.MovePosition(transform.position + destination * pickUpSpeed * Time.deltaTime);
			Debug.DrawLine(transform.position, destination, Color.magenta);
			transform.LookAt(destination);
		}

		if (itemState == 3)
		{
			//find unchecked "gun" item, and set the position 
			transform.parent = Camera.main.transform;
			Transform gunPosTrans = Camera.main.transform.GetChild(0);
			transform.position = gunPosTrans.position;
			transform.rotation = gunPosTrans.rotation;
			Rb.velocity = Vector3.zero;
			Rb.angularVelocity = Vector3.zero;
			Rb.isKinematic = true;
			SpawnProjectiles.setGunBoolTrue();
		}

		if (Input.GetMouseButton(1) && itemState == 3)
		{
			itemState = 4;
		}

		if (itemState == 4)
		{
			transform.parent = null;
			Rb.isKinematic = false;
			Rb.useGravity = true;
			Rb.AddForce(Camera.main.transform.forward * throwForce);
			SpawnProjectiles.setGunBoolFalse();
		}
	}


	//when it hits the player... position item in front of player
	void OnCollisionEnter (Collision col)
	{
		if (itemState == 2 && col.gameObject.tag == "Player")
		{
			itemState = 3;
		}

		if (itemState == 4 && col.gameObject.tag == "Finish")
		{
			Destroy(gameObject);
		} 
		else if (itemState == 4 && col.gameObject.tag == "npc")
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
	
	

}
