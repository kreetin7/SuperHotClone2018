using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on a cube
//Intent: proto-"player controller" for prototyping time purposes, 
public class cubeProtoMiove : MonoBehaviour
{
	//private float TimeTarget; 
	public float CubeSpeed = 0.5f; //normal speed of the cube
	
	public float lookSpeed = 300f;

	private float upDownRotation; 
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;	//mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;	//mouseY = vertical mouseDelta
		
		transform.Rotate(0f, mouseX, 0f);
		//Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f); //camera rotation
		Camera.main.transform.Rotate(-mouseY, 0f,0f); //same thing
		

		Camera.main.transform.localEulerAngles -= new Vector3( //making the camera rotate 
			0,
			0,
			Camera.main.transform.localEulerAngles.z 
		);
		
		upDownRotation -= mouseY; //setting up downRotation variable to the y axis
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); //clamping the camera

		TimeManager.instance.TimeTarget = 0.12f; //setting the default time target (as in how slow it starts out) 
		
		
		if (Input.GetKey(KeyCode.W)) //if W is pressed 
		{
			transform.Translate(0f, 0f,1f * CubeSpeed); //moving the cube forwards on the Z axis because thats the orientation of Ryan's scene for some reason

		
			TimeManager.instance.TimeTarget = 1; //setting the target to the normal rate 


		}

		if (Input.GetKey(KeyCode.S)) //if S is pressed 
		{
			transform.Translate(0f, 0f,-1f * CubeSpeed); //moving the cube backwards on the Z axis @ryan why
			TimeManager.instance.TimeTarget = 1; //setting the target to the normal rate so that it speeds back up to a "normal" speed
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		
		if (Input.GetKey(KeyCode.A)) //if A is pressed 
		{
			transform.Translate(-1f * CubeSpeed, 0f,0f); //moving left on the x axis 
			TimeManager.instance.TimeTarget = 1; //setting the target at normal rate
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		
		if (Input.GetKey(KeyCode.D)) //if D is pressed 
		{
			transform.Translate(1f * CubeSpeed, 0f,0f); //moving right on the x axis
			TimeManager.instance.TimeTarget = 1; //setting the time target back at normal time
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; //hide the cursor as well, just to be safe
		}
		
	}
}
