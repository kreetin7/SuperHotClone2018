using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on an empty object called TimeManager
//Intent: slows down time according to a slowDownFactor assigned in the inspector
public class TimeManager : MonoBehaviour
{


	//public float slowAcceleration = 0.3f;
	//public float slowIncriment = 0.2f; 

	public float slowDownFactor; //sets variable for on a scale from 0=>1, how slow do we go? 
	
	public float slowDownLength = 2f; 

	//public float slowdownLength;

	public static TimeManager instance; //making this manager a static instance
	// Use this for initialization
	 void Start()
	{
		instance = this; //setting the static instance
	}


	public void SlowDown() //a function to call when you want something to slow down
	{
		
		
		Time.timeScale = slowDownFactor; //set the time scale = to the slowdownfactor
		Time.fixedDeltaTime = Time.timeScale * 0.02f; 
		Debug.Log(Time.timeScale); //debugging to be sure it's reading it
	}

	
}
