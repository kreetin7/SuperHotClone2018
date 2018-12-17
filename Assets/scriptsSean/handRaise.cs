using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on the hand model is attatched to GunPos and will come into view in the camera when gun is picked up
//intent: will activate the animation for the GunPos to rotate into view

public class handRaise : MonoBehaviour {
	
	//reference to itemPickUp script so we know if the gun is in itemState 3 (when it is picked up by the player
	public itemPickUp inHandScript;
	
	//reference to animator on GunPos
	public Animator handAnim;
	
	//booleans to trigger next animation states inside script not in animator
	public bool inHand = false;
	public bool shot = false;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {	
		//when gun is in hands make hand visible and play pull out animation
		if (inHandScript.itemState == 3) 
		{
			//transitions to pullout animation
			handAnim.SetBool("gunInHand", true);
			inHand = true; //turns on boolean to transition into handIdle animation
		}

		if (inHandScript.itemState == 3 && inHand == true)	//if the gun is in the player's hand and idle transition boolean is true
		{
			//transitions into idle animation
			handAnim.SetBool("gunHeld", true);
		}
		
		if (inHandScript.itemState == 3 && Input.GetMouseButtonDown(0) && shot == false)	//if gun is in hand and left mouse button is clicked
		{
			handAnim.SetBool("gunShot", true);//transition into handRecoil animation
			shot = true; //set boolean to true so it can transition the gunShot boolean back to false
		} else if (inHandScript.itemState == 3 && shot == true)	//once the gun has been shot...
		{
			//reset both the animation parameter and transition boolean
			handAnim.SetBool("gunShot", false);
			shot = false;
		}


		if (inHandScript.itemState == 4) //when gun is in thrown state...
		{
			//set gunInHand to false which will transition into the throwing animation
			handAnim.SetBool("gunInHand", false);
		}
	
	}
	
}
