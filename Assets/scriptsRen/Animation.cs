using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

	public SpawnProjectiles SpawnProjectiles; 
	public Animator anim; 
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0) ) 
		{
			if (SpawnProjectiles.isHoldingGun == true)
			{
				anim.SetBool("Shoot", true);
			}

		}
		else
		{
			anim.SetBool("Shoot", false);
		}
	}
}
