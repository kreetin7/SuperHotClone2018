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
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {	
		//when gun is in hands make hand visible and play pull out animation
		if (inHandScript.itemState == 3) 
		{
			//plays pull out animation
			handAnim.SetBool("gunInHand", true);
			
		} else if (inHandScript.itemState == 4) //when gun is thrown...
		{
			//set gunInHand to false which will transition into the throwing animation
			handAnim.SetBool("gunInHand", false);
		}
	
	}
	
}
