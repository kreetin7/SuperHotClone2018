using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on a capsule
//Intent: moves the player, camera look, any any other code such as setting timeTarget that should be controlled by the player object
public class cubeProtoMiove : MonoBehaviour
{
	//private float TimeTarget; 
	public float CubeSpeed = 0.5f; //normal speed of the cube, also assigned in the inspector
	
	public float lookSpeed = 300f; //speed of mouseLook, assigned in inspector

	private float upDownRotation; //mouseLook moving up and down on the Y axis
	private Vector3 inputVector; 
 
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.unscaledDeltaTime;	//mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.unscaledDeltaTime;	//mouseY = vertical mouseDelta
		
		transform.Rotate(0f, mouseX, 0f); 
	
		upDownRotation -= mouseY; //setting up downRotation variable to the y axis
	
		upDownRotation = Mathf.Clamp(upDownRotation, -70, 70); //clamping the camera

		Camera.main.transform.localEulerAngles = new Vector3( //making the camera rotate 
			upDownRotation,
			0f,
			0f
		);

		
		
		//Debug.Log(upDownRotation); 
		TimeManager.instance.TimeTarget = 0.05f; //setting the default time target (as in how slow it starts out) 
		
		
		float vertical = Input.GetAxis("Vertical"); //move on the Y axis
        float horizontal = Input.GetAxis("Horizontal"); //move on the X axis
		
		inputVector = transform.forward * vertical * CubeSpeed;	//forward/back
		inputVector += transform.right * horizontal * CubeSpeed;
		
		
		//WASD sets the time target to  1, so as you move the time scale moves towards that target
		if (Input.GetKey(KeyCode.W)) //if W is pressed 
		{
			

			TimeManager.instance.TimeTarget = 1; //setting the target to the normal rate 


		}


		if (Input.GetKey(KeyCode.S)) //if S is pressed 
		{
	
			TimeManager.instance.TimeTarget = 1; //setting the target to the normal rate so that it speeds back up to a "normal" speed
			
		}
		
		if (Input.GetKey(KeyCode.A)) //if A is pressed 
		{
			
			TimeManager.instance.TimeTarget = 1; //setting the target at normal rate
	
		}
		
		if (Input.GetKey(KeyCode.D)) //if D is pressed 
		{
			
			TimeManager.instance.TimeTarget = 1; //setting the time target back at normal time
		
		}

		//cursor lock
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; 
		}
		
	}
	
	void FixedUpdate()
	{
		//apply our forces to move the object around
		GetComponent<Rigidbody>().velocity = inputVector; 
	}
	
	//collision making you die

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "npcBullet") //checks for if you've been hit by the npcBullet's gameobject with this tag
		{
			GameManagerScript.isAlive = false; //sets the variable to false for whether you're alive or dead
		}
	}
}
