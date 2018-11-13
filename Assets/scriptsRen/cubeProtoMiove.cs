using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on a cube
//Intent: proto-"player controller" for prototyping time purposes, 
public class cubeProtoMiove : MonoBehaviour
{

	

	public float CubeSpeed = 0.5f; //normal speed of the cube
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		
		if (Input.GetKey(KeyCode.W)) //if W is pressed 
		{
			transform.Translate(0f, 0f,1f * CubeSpeed); //moving the cube forwards on the Z axis because thats the orientation of Ryan's scene for some reason

			Time.timeScale += (1f/TimeManager.instance.slowDownLength) * Time.unscaledDeltaTime;//setting time to "normal time" when you move
			Debug.Log(Time.timeScale);
			Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
			Debug.Log(Time.time);

		}

		if (Input.GetKey(KeyCode.S)) //if S is pressed 
		{
			transform.Translate(0f, 0f,-1f * CubeSpeed); //moving the cube backwards on the Z axis @ryan why
			
			Time.timeScale = 1;
			Debug.Log(Time.timeScale);
		}

		else
		{
			TimeManager.instance.SlowDown(); //calling the slowdown function if you aren't moving
		}
	}
}
