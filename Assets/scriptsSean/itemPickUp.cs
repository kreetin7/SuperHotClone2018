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
	//p
	//reference to the loopPickUp script so that the object has access to the itemHit bool
	public lookPickUp cameraScript;
	//speed in which the object will fly towards the player
	public float pickUpSpeed;
	
	//force of throw
	private float throwForce = 600f;
	//bool to see if item is picked up by player
	public bool isHolding = false;
	//hold position
	private Vector3 holdPos;
	
	void Start ()
	{
		destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cameraScript.itemHit == true)
		{
			//this.GetComponent<Rigidbody>().useGravity = false;
			destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, destination, pickUpSpeed * Time.deltaTime);
			Debug.DrawLine(transform.position, destination, Color.magenta);
			transform.LookAt(destination);
		}
		
		if (cameraScript.itemHit == false && isHolding == true)
		{
			//holdPos =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+10);
			//this.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			//transform.position = destination;
			
			if (Input.GetMouseButtonDown(1))
			{
				
			}
		}
			
	}
	//when it hits the player... position item in front of player
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "player")
		{
			//isHolding = true;
			//cameraScript.itemHit = false;
		}
	}
	
	

}
