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
		
		//rotating on x axis is pitch (look up and down)
		//rotating on y axis is yaw (look left and right)
		//rotating on z axis is roll
		
		//problem 1: camera keeps rolling
		//solution 1: after applying rotations, unroll the camera
		Camera.main.transform.localEulerAngles -= new Vector3(
			0,
			0,
			Camera.main.transform.localEulerAngles.z
		);
		
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); 

		TimeManager.instance.TimeTarget = 0.12f; 
		if (Input.GetKey(KeyCode.W)) //if W is pressed 
		{
			transform.Translate(0f, 0f,1f * CubeSpeed); //moving the cube forwards on the Z axis because thats the orientation of Ryan's scene for some reason

			/*Time.timeScale += (1f/TimeManager.instance.slowDownLength) * Time.unscaledDeltaTime;//setting time to "normal time" when you move
			Debug.Log(Time.timeScale);
			Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
			Debug.Log(Time.time);
			*/
			//Time.timeScale = 1;
			TimeManager.instance.TimeTarget = 1; 


		}

		if (Input.GetKey(KeyCode.S)) //if S is pressed 
		{
			transform.Translate(0f, 0f,-1f * CubeSpeed); //moving the cube backwards on the Z axis @ryan why
			TimeManager.instance.TimeTarget = 1;
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		
		if (Input.GetKey(KeyCode.A)) //if S is pressed 
		{
			transform.Translate(-1f * CubeSpeed, 0f,0f); //moving the cube backwards on the Z axis @ryan why
			TimeManager.instance.TimeTarget = 1;
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		
		if (Input.GetKey(KeyCode.D)) //if S is pressed 
		{
			transform.Translate(1f * CubeSpeed, 0f,0f); //moving the cube backwards on the Z axis @ryan why
			TimeManager.instance.TimeTarget = 1;
			//Time.timeScale = 1;
			//Debug.Log(Time.timeScale);
		}
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; //hide the cursor as well, just to be safe
		}
		else 
		{
			//TimeManager.instance.SlowDown(); //calling the slowdown function if you aren't moving
		}
	}
}
