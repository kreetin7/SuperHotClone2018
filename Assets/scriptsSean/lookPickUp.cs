using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on the mainCamera that should be a child of player gameObject
//intent: script will cast a raycast out form position of camera that can detect if there is an item you can pick up

public class lookPickUp : MonoBehaviour
{

	public GameObject player;
	//length of item pick up raycast
	float maxRaycastDist = 3f;

	public LayerMask layerMask; 
	//bool to see if raycast hit a pick up item
	public bool ItemHit;

	public bool SeeGun = false; 
	
	void Start () {
		
	}
	
	void Update () {
		//aim pickUpRay raycast
		Ray pickUpRay = new Ray(player.transform.position, transform.forward);
		//Camera.main.ScreenPointToRay(transform.position);
		
		Debug.DrawRay(pickUpRay.origin, pickUpRay.direction * maxRaycastDist, Color.red);
		
		RaycastHit pickUpRayHit = new RaycastHit();	
		//if raycast hits something...
		
		
		
		if (Physics.SphereCast(pickUpRay.origin, 3f, pickUpRay.direction,  out pickUpRayHit, maxRaycastDist, layerMask, QueryTriggerInteraction.UseGlobal))
		{
			if (pickUpRayHit.collider.tag == "gun")

				
			{
				SeeGun = true;
				if (Input.GetKey(KeyCode.E))
				{
					SeeGun = false; 
					//Debug.Log("you can pick it up!");
					ItemHit = true;
				}
				
				else {
					 
					ItemHit= false;
				}
			}
			
			
		}
	}

	
}
