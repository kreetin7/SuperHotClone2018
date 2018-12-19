using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class np : MonoBehaviour {

	public GameObject npcFirePoint;
	public List<GameObject> npcvfx = new List<GameObject>();
	public float npcShootTimer = 0f;
	private GameObject effectToSpawn;
	public AudioScript AudioScript;
	public ParticleSystem flare;
	public ParticleSystem flare2; 
	
	//Declarations

	void Start () {
		//You will assign the bullet prefab in the inspector
		effectToSpawn = npcvfx[0];
		//flare.enableEmission = false;
		flare.Stop();
		npcShootTimer = 0f; 
	}


	void Update()
	{
		//NPC buffer for shooting countdown
		npcShootTimer -= 1 * Time.deltaTime; 
		
		Debug.Log(npcShootTimer);
		//If the firepoint exists and the npc shooting cooldown is over
		if (npcFirePoint != null && npcShootTimer <= 0)
		{
			//Shooting buffer for the npcs
			npcShootTimer = 1f;
			AudioScript.playGunShot();
			SpawnVFX();
		}
	}
	
	void SpawnVFX()
	{
		GameObject vfx;

		//if the firepoint exists
		if (npcFirePoint != null)
		{
			//instantiate a bullet
			vfx =  Instantiate(effectToSpawn, npcFirePoint.transform.position,  this.transform.rotation);
			Debug.Log("Bullet Spawned");
			//flare.enableEmission = true; 
			flare.Play();
			
		}
	}
}
