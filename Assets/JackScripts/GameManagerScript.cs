using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
	
	public static bool isAlive = false;
	public GameObject Player;
	
	//The end of game text that displays "SUPER... HOT"
	//ignore these for now
	public Text endGameText;
	private bool isGameOver = false;
	private float endTitleCounter = 0;
	//ignore these for now^
	
	
	void Start()
	{
		isAlive = true;
	}

	void Update () {
		if (isAlive == false)
		{
			endGameText.text = "GAME OVER";
			SceneManager.LoadScene(1);
		}
		
	}
}
