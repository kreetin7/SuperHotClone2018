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

	public void playGunShot()
	{
		source.PlayOneShot(gunShot, 0.5f);
	}
	
	public void playGunHit()
	{
		source.PlayOneShot(gunHit, 0.5f);
	}
	
	public void playGunPickUp()
	{
		source.PlayOneShot(gunPickUp, 0.5f);
	}
	
	public void playSUPERHOT()
	{
		source.Play(); //(SUPERHOT, 0.5f);
	}
}
