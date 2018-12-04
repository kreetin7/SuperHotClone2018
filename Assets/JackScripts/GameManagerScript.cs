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
	
	
	public static bool isAlive = false;//Boolean determining if player is alive or not
	public GameObject Player; //The player
	
	//The end of game text that displays "SUPER... HOT"
	//ignore these for now
	public Text endGameText;
	private bool isGameOver = false;
	private float endTitleCounter = 0;
	//ignore these for now^
	
	
	void Start()
	{
		isAlive = true; //Alive on start
	}

	void Update () {
		if (isAlive == false) //if you die
		{
			endGameText.text = "GAME OVER"; // display GAME OVER on the screen
			SceneManager.LoadScene(1); // load Scene(1) in the build settings(Test Scene right now)
		}
		
	}
}
