using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour {

	
    public GameObject firePoint;
	//public List<GameObject> vfx = new List<GameObject>();  //old code
	public GameObject bullet; // changed vfx tp bullet
	public RotateToMouse RotateToMouse;
	public bool isHoldingGun = false;
	public int bulletsInGun = 5;
	//private GameObject effectToSpawn; //old code
	private float timeToFire = 0;

	public ParticleSystem muzzleFlash; 
	
	// Use this for initialization
	void Start ()
	{
		//effectToSpawn = vfx[0];
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isHoldingGun == true)
		{
			if (bulletsInGun > 0)
			{

				if (Input.GetMouseButton(0) && Time.time >= timeToFire)
				{
					// spawns the bullet
					timeToFire = Time.time + 1 / bullet.GetComponent<ProjectileMove>().fireRate; //used to be timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
					SpawnVFX();
					bulletsInGun = bulletsInGun - 1;
					
					
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			setGunBoolTrue();
		}
		
		
		if (Input.GetKeyDown(KeyCode.F))
		{
			setGunBoolFalse();
		}


	}

	void SpawnVFX()
	{
		GameObject newBullet;

		//if the firepoint exists
		if (firePoint != null)
		{
			muzzleFlash.Play();

				//instantiate a bullet
				newBullet = Instantiate(bullet, firePoint.transform.position, Camera.main.transform.rotation); //first value passed in used to be effectToSpawn
				if (RotateToMouse != null)
				{
					//bullet rotation equal to where circle is looking
					newBullet.transform.localRotation = RotateToMouse.GetRotation();
				}
		}

		else
		{
			Debug.Log("no firepoint");
		}
	}

	public bool setGunBoolTrue()
	{
		return isHoldingGun = true;
	}
	
	public bool setGunBoolFalse()
	{
		return isHoldingGun = false;
	}


	
}
