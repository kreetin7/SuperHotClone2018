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
	public Rigidbody Rb;
	
	//reference to the loopPickUp script so that the object has access to the itemHit bool
	public lookPickUp cameraScript;
	//
	
	//speed in which the object will fly towards the player
	public float pickUpSpeed;
	
	
	//state int 
	//there are three states:
	//1. laying on ground
	//2. moving towards player ("getting picked up")
	//3. in the player's hands ("in the camera view")
	private int itemState = 1;
	
	
	//force of throw
	private float throwForce = 600f;
	//bool to see if item is picked up by player
	public bool isHolding = false;
	
	void Start ()
	{
		destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (itemState == 1)
		{
			if (cameraScript.itemHit == true)
			{
				itemState = 2;
			}
		}

		if (itemState == 2)
		{
			//this.GetComponent<Rigidbody>().useGravity = false;
			destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, destination, pickUpSpeed * Time.deltaTime);
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
			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
			this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
			
	}
	
	
	
	//when it hits the player... position item in front of player
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			itemState = 3;
		}
	}
	
	

}
