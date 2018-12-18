using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

	//This script handles the movement of the projectile

	//speed of projectile
	public float speed;
	public GameObject deathParticles;
	private Vector3 pos;
	private AudioScript AS;
	private GameObject evilAudio;

	//firing rate of prpjectiles (not relevant)
	public float fireRate;
	// Use this for initialization
	void Start ()
	{
		
	evilAudio = GameObject.Find("evilAudio");
	AS = (AudioScript) evilAudio.GetComponent(typeof(AudioScript));
	//AS = GameObject.FindObjectOfType(typeof(AudioScript)) as AudioScript;

	}
	
	// Update is called once per frame
	void Update () {
		//if the speed is higher than 0
		if (speed != 0)
		{
			//move the bullet forward
			transform.position += transform.forward * (speed * Time.deltaTime);
		}
		else
		{
			Debug.Log("No Speed");
		}
		
	}
	
	//none functioning collisions code
 
	void OnCollisionEnter(Collision col)
	{
		pos = this.gameObject.transform.position;
		
	
		speed = 0;
		if (col.gameObject.layer == 14)
		{
		    AS.playGunHit();
			Instantiate(deathParticles, pos, Quaternion.identity);
			Destroy(this.gameObject);
			
		}
		else
		{
			Destroy(this.gameObject);
		}
	} 
}
