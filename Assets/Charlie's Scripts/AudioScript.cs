using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioSource source;
	public AudioClip gunShot;
	public AudioClip gunHit; 
	public AudioClip gunPickUp;
	public AudioClip SUPERHOT;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playGunShot()
	{
		source.PlayOneShot(gunShot, 0.5f);
	}
	
	void playGunHit()
	{
		source.PlayOneShot(gunHit, 0.5f);
	}
	
	void playGunPickUp()
	{
		source.PlayOneShot(gunPickUp, 0.5f);
	}
	
	void playSUPERHOT()
	{
		source.PlayOneShot(SUPERHOT, 0.5f);
	}
}
