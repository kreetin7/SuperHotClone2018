﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
	//this isn't relevant, just rotates the circle object

	public Camera cam;

	public float maximunLength;

	private Ray rayMouse;

	private Vector3 pos;

	private Vector3 direction;

	private Quaternion rotation;
	
	
	// Update is called once per frame
	void Update () {
		if (cam != null)
		{
			//uses raycasting to rotate the circle
			RaycastHit hit;
			var mousePos = Input.mousePosition;
			rayMouse = cam.ScreenPointToRay(mousePos);
			if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximunLength))
			{
				RotateToMouseDirection(gameObject, hit.point);
			}
			else
			{
				//functions even outside of screen
				var pos = rayMouse.GetPoint(maximunLength);
				RotateToMouseDirection(gameObject, pos);
			}
		}
		
	}

	void RotateToMouseDirection(GameObject obj, Vector3 destination)
	{
		direction = destination - obj.transform.position;
		rotation = Quaternion.LookRotation(direction);
		obj.transform.localRotation = Quaternion.Lerp(obj.transform.localRotation, rotation, 1);
	}

	public Quaternion GetRotation()
	{
		//sends value to other script
		return rotation;
	}
}
