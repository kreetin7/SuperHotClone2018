using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.Experimental.UIElements.Image;

//INTENT:  To manage the overall scene with restarting the scene on death and victory
//USAGE:  Attatch to empty game object "GameManager"
public class GameManagerScript : MonoBehaviour
{

	public GameObject npcCheck1;
	public GameObject npcCheck2;
	
	public static bool isAlive = false;//Boolean determining if player is alive or not
	public bool npcisAlive = true;
	public GameObject Player; //The player
	
	//The end of game text that displays "SUPER... HOT"
	//ignore these for now
	public Text endGameText;
	public Text endGameText2;
	public Text RestartText;
	
	private bool isGameOver = false;
	private float endTitleCounter = 10f;
	//ignore these for now^

	public GameObject endGameAudio;
	
	
	void Start()
	{
		endGameText.text = ""; 
		isAlive = true; //Alive on start
		

		
	}

	void Update () {

		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
		if (isAlive == true)
		{
			
			
		}
		if (isAlive == false) //if you die
		{
			// start the death coroutine
			StartCoroutine(GameOverText()); 
		}
		
		//if the npc dies
		if (npcCheck1 == null && npcCheck2 == null)
		{
			endTitleCounter -= 1f;
		}

		if (npcCheck1 == true)
		{
			StopCoroutine(SuperHotText());
			
		}
		if (endTitleCounter < 0)
		{
			npcisAlive = false;
			endTitleCounter = 10f;
			endTitleCounter += 1;
		}

		if (npcisAlive == true)
		{
			StopCoroutine(SuperHotText());
			Debug.Log("Stop Coroutine");
		}
	

		if (npcisAlive == false)
		{
			Debug.Log("This should be saying super hot super hot");
			endGameAudio.SetActive(true);
			StartCoroutine(SuperHotText()); // start the coroutine
		}
		
	}
	
	//Coroutine for SUPER HOT TEXT

	IEnumerator SuperHotText()
	{

		
		
	
		endGameText.text = "SUPER";
		yield return new WaitForSecondsRealtime(1f); //using WaitForSecondsRealTime so that it isn't slowed down by TimeScale
		endGameText.enabled = false;
		endGameText2.text = "HOT";
		yield return new WaitForSecondsRealtime(1f);
		endGameText.enabled = true;
		endGameText2.enabled = false; 
		endGameText.text = "SUPER";
		yield return new WaitForSecondsRealtime(1f);
		endGameText.enabled = false;
		endGameText2.enabled = true;
		endGameText.text= ""; 
		endGameText2.text = "HOT";
		yield return new WaitForSecondsRealtime(.5f);
		SceneManager.LoadScene(0); // reload scene
	

	}
	
	//Corountine for GAME OVER TEXT
	IEnumerator GameOverText()
	{


		RestartText.text = "Press R to restart";
		yield return new WaitForSecondsRealtime(5f); //using WaitForSecondsRealTime so that it isn't slowed down by TimeScale
	
		SceneManager.LoadScene(0); // load Scene(1) in the build settings(Test Scene right oww
		
		
	}
	
	
}
