using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public Text RestartText; 
	private bool isGameOver = false;
	private float endTitleCounter = 10f;
	//ignore these for now^
	
	
	void Start()
	{
		endGameText.text = ""; 
		isAlive = true; //Alive on start
		

		
	}

	void Update () {

		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(1);
		}
		if (isAlive == true)
		{
			
			//Time.timeScale = Mathf.MoveTowards(Time.timeScale, TimeManager.instance.TimeTarget, TimeManager.instance.TimeSpeed);
		}
		if (isAlive == false) //if you die
		{
			// display GAME OVER on the screen
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
			StartCoroutine(SuperHotText()); // start the coroutine
		}
		
	}
	
	//Coroutine for SUPER HOT TEXT

	IEnumerator SuperHotText()
	{
	
		//TimeManager.instance.TimeTarget = 1;
		endGameText.text = "SUPER";
		yield return new WaitForSecondsRealtime(2f);
		endGameText.text = "HOT";
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(1); // load Scene(1) in the build settings(Test Scene right now)
	

	}
	
	//Corountine for GAME OVER TEXT
	IEnumerator GameOverText()
	{


		RestartText.text = "Press R to restart";
		yield return new WaitForSecondsRealtime(5f); 
	
		SceneManager.LoadScene(1); // load Scene(1) in the build settings(Test Scene right oww
		//Time.timeScale = Mathf.MoveTowards(Time.timeScale, TimeManager.instance.TimeTarget, TimeManager.instance.TimeSpeed);
		
	}
	
	
}
