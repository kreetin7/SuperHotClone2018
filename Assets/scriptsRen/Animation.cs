using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

	public SpawnProjectiles SpawnProjectiles;
	public lookPickUp LookPickUp; 
	public Animator anim; 
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (LookPickUp.SeeGun == true)
		{
			anim.SetBool("canseegun", true);
		}

		else
		{
			anim.SetBool("canseegun", false);
		}

		if (SpawnProjectiles.isHoldingGun == true)
		{
			anim.SetBool("hasgun", true);
			if (Input.GetMouseButtonDown(0) ) 
			{
			anim.SetBool("Shoot", true);
			anim.SetBool("hasgun", false);
			}
			else
			{
				anim.SetBool("Shoot", false);
			}
		}
		
		
	}
}
