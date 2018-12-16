using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on an empty object called TimeManager
//Intent: slows down time according to a TimeSpeed assigned in the inspector
public class TimeManager : MonoBehaviour
{


	

	

	public float TimeTarget; //the target TimeScale, Assigned in inspector
	public float TimeSpeed; //the speed at which TimeScale changes, also assigned in inspector

	

	public static TimeManager instance; //making this manager a static instance
	// Use this for initialization
	 void Start()
	{
		instance = this; //setting the static instance
	}

	public void Update()
	{
		Time.timeScale = Mathf.MoveTowards(Time.timeScale, TimeTarget, TimeSpeed); //moves the TimeScale towards a certain target at a variable speed
	}

	

	
}
