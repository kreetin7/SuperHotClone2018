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
	public static bool npcisAlive = true;
	public GameObject Player; //The player
	
	//The end of game text that displays "SUPER... HOT"
	//ignore these for now
	public Text endGameText;
	private bool isGameOver = false;
	private float endTitleCounter = 10f;
	//ignore these for now^
	
	
	void Start()
	{
		isAlive = true; //Alive on start
	}

	void Update () {
		
		if (isAlive == false) //if you die
		{
			endGameText.text = "GAME"; // display GAME OVER on the screen
			StartCoroutine(GameOverText()); 
		}
		
		//if the npc dies
		if (npcCheck1 == null && npcCheck2 == null)
		{
			endTitleCounter -= 1f;
		}

		if (endTitleCounter < 0)
		{
			npcisAlive = false;
			endTitleCounter = 10f;
			endTitleCounter += 1;
		}

		if (npcisAlive == false)
		{
			StartCoroutine(SuperHotText()); // start the coroutine
		}
		
	}
	
	//Coroutine for SUPER HOT TEXT

	IEnumerator SuperHotText()
	{
		TimeManager.instance.TimeTarget = 1;
		endGameText.text = "SUPER";
		yield return new WaitForSeconds(2f);
		endGameText.text = "HOT";
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(1); // load Scene(1) in the build settings(Test Scene right now)
		
	}
	
	//Corountine for GAME OVER TEXT
	IEnumerator GameOverText()
	{
		TimeManager.instance.TimeTarget = 1; 
		yield return new WaitForSeconds(1f);
		endGameText.text = "OVER";
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(1);// load Scene(1) in the build settings(Test Scene right now)
	}
	
	
}
