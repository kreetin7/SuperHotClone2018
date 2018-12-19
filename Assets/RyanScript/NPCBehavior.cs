using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

//USAGE: Put this on a NPC 
//INTENT: NPC will see and shoot at the Player
public class NPCBehavior : MonoBehaviour
{
	public float visDistance; //So I can adjust variables in the Inspector 
	public float timeUntilShoot; //when this gets to 0, Npc shoots again

	public Transform playerTarget;

	public float turnMagnitude = 50f;

	
	// Update is called once per frame
	void Update ()
	{

		timeUntilShoot -= 1f;
		
		Ray NPCRay = new Ray(transform.position, transform.forward); //NPC Raycast facing towards Player
		
		float maxDistance = visDistance; //How far the NPC can look
		
		RaycastHit hit; //Raycast gotta hit somethin
		
		Debug.DrawRay(NPCRay.origin, NPCRay.direction * maxDistance, Color.cyan); //Draws the ray out

		Vector3 lookRotation = playerTarget.position - transform.position; 
		
		Quaternion rotation = Quaternion.LookRotation(lookRotation, Vector3.up);
		
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnMagnitude * Time.deltaTime);
	
		//NPC raycast
		if (Physics.Raycast(NPCRay, out hit, maxDistance))
		{
		
			if (hit.transform.tag == "Player")
			{
				

				Debug.Log("NPC Sees Player");


				
			}

		}
		else
		{
			Debug.Log("NPC Doesn't See Player");
		}

	}
}
	
	

