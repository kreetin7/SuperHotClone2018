using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INTENT:  To make the NPCS shoot at the player
//USAGE:  Attach to the NPC, and set the firepoint to an empty game object from the point you want the bullet to come from
//USAGE2: Set list length to 1, and attach bullet prefab to first list object.
public class NPCShoot : MonoBehaviour
{
	//Declarations
	public GameObject npcFirePoint;
	public List<GameObject> npcvfx = new List<GameObject>();
	private float npcShootTimer = 120f;
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
		flare2.Stop(); 
	}


	void Update()
	{
		//NPC buffer for shooting countdown
		npcShootTimer -= 1; 
		Debug.Log(npcShootTimer);
		//If the firepoint exists and the npc shooting cooldown is over
		if (npcFirePoint != null && npcShootTimer < 0)
		{
			//Shooting buffer for the npcs
			npcShootTimer = 120f;
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
			vfx = Instantiate(effectToSpawn, npcFirePoint.transform.position,  this.transform.rotation);
			Debug.Log("Bullet Spawned");
			//flare.enableEmission = true; 
			flare.Play();
			flare2.Play();
		}
	}
}
