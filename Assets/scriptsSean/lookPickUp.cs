using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on the mainCamera that should be a child of player gameObject
//intent: script will cast a raycast out form position of camera that can detect if there is an item you can pick up

public class lookPickUp : MonoBehaviour
{

	public GameObject player;
	//length of item pick up raycast
	float maxRaycastDist = 2f;
	//bool to see if raycast hit a pick up item
	public bool itemHit;
	
	void Start () {
		
	}
	
	void Update () {
		//aim pickUpRay raycast
		Ray pickUpRay = new Ray(player.transform.position, transform.forward);
		//Camera.main.ScreenPointToRay(transform.position);
		
		Debug.DrawRay(pickUpRay.origin, pickUpRay.direction * maxRaycastDist, Color.red);
		
		RaycastHit pickUpRayHit = new RaycastHit();	
		//if raycast hits something...
		if (Physics.Raycast(pickUpRay, out pickUpRayHit, maxRaycastDist))
		{
			if (pickUpRayHit.collider.tag == "gun")
			{
				if (Input.GetKey(KeyCode.E))
				{
					Debug.Log("you can pick it up!");
					itemHit = true;
				}
			} else {
				//itemHit = false;
			}
			
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "gun")
		{
			
		}
	}
}
