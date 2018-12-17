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
	
	public SpawnProjectiles SpawnProjectiles;
	
	//speed in which the object will fly towards the player
	public float pickUpSpeed;
	
	
	//state int 
	//there are three states:
	//1. laying on ground
	//2. moving towards player ("getting picked up")
	//3. in the player's hands ("in the camera view")
	//4. being thrown (use gun as projectile)
	public int itemState = 1;
	
	
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

		
			Rb.useGravity = false; // turn gravity off
			Vector3 destination = (player.transform.position - transform.position).normalized; //initialize item's new destination
			Rb.MovePosition(transform.position + destination * pickUpSpeed * Time.deltaTime);	//make the gun's rigid body move towards destination
			Debug.DrawLine(transform.position, destination, Color.magenta);//debug line to see gun's direction
			transform.LookAt(destination);//make gun look towards the player

		}

		if (itemState == 3)
		{
			//find unchecked "gun" item, and set the position 
			transform.parent = Camera.main.transform;
			//initialize new position based off where GunPos is which is a child of Camera.main
			Transform gunPosTrans = Camera.main.transform.GetChild(0);
			//transform the gun's position into GunPos's position
			transform.position = gunPosTrans.position;
			//transform the gun's rotation into GunPos's rotation
			transform.rotation = gunPosTrans.rotation;
			//make sure that RigidBody isn't being messed with when in player's hand. No collisions or anything.
			Rb.velocity = Vector3.zero;
			Rb.angularVelocity = Vector3.zero;
			Rb.isKinematic = true;
			Rb.detectCollisions = false;
			//code that prevents gun from jittering when player moves around
			Rb.interpolation = RigidbodyInterpolation.None;
			//reference to Charlie's gun projectile code so that it activates when gun is in itemState 3
			SpawnProjectiles.setGunBoolTrue();
		}

		if (Input.GetMouseButton(1) && itemState == 3) //if player clicks right mouse button when holding gun...
		{
			itemState = 4; //changed gun to thrown state
		}

		if (itemState == 4)
		{
			//make sure to unpair the gun from any parents so that it can be thrown.
			transform.parent = null;
			//make sure that the rigid body is now affected by gravity and enviroment
			Rb.isKinematic = false;
			Rb.interpolation = RigidbodyInterpolation.Interpolate;
			Rb.useGravity = true;
			//force is added to rigid body so that the gun is thrown where player is aiming
			Rb.AddForce(Camera.main.transform.forward * throwForce);
			Rb.detectCollisions = true;
			//turn off Charlie's gun projectile code so that player now can't shoot
			SpawnProjectiles.setGunBoolFalse();
		}
	}


	//when it hits the player... position item in front of player
	void OnCollisionEnter (Collision col)
	{
		if (itemState == 2 && col.gameObject.tag == "Player") //when gun hits the player...
		{
			itemState = 3;//gun goes into hold state
		}

		if (itemState == 4 && col.gameObject.tag == "Finish")	//when gun hits any wall or surface...
		{
			Destroy(gameObject);//destroy gun
		} 
		else if (itemState == 4 && col.gameObject.tag == "npc") //when gun hits an npc
		{
			Destroy(gameObject);	//destroy gun
			Destroy(col.gameObject);//haven't updated, but stun enemies
		}
	}
	
	

}
