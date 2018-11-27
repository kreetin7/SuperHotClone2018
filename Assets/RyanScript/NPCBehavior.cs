using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: Put this on a NPC 
//INTENT: NPC will see and shoot at the Player
public class NPCBehavior : MonoBehaviour
{
	public float visDistance; //So I can adjust variables in the Inspector 
	public float shootDelay; //Short timer so the npcs don't shoot like crazy
	public float timeUntilShoot; //when this gets to 0, Npc shoots again
	
	// Update is called once per frame
	void Update () {
		
		timeUntilShoot -= Time.deltaTime;
		
		Ray NPCRay = new Ray(transform.position, -transform.forward); //NPC Raycast facing towards Player
		
		float maxDistance = visDistance; //How far the NPC can look
		
		RaycastHit hit; //Raycast gotta hit somethin
		
		Debug.DrawRay(NPCRay.origin, NPCRay.direction * maxDistance, Color.cyan); //Draws the ray out
		
		//NPC raycast
		if (Physics.Raycast(NPCRay, out hit, maxDistance))
		{
		
			if (hit.transform.tag == "Player")
			{
				Debug.Log("NPC Sees Player");

				//Inlcude Timer so that they don't just shoot like crazy
				shootDelay = 1f;

				if (timeUntilShoot <= 0f)
				{
					Debug.Log("SHOOTS!");

					timeUntilShoot = 2f;
				}
			}

		}
		else
		{
			Debug.Log("NPC Doesn't See Player");
		}

	}
}
	
	

