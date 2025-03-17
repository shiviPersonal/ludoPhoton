using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{
	public static int howManyPlayers;

	void Start () 
	{
		
	}	

	void Update () 
	{
	
	}

	public void two_player()
	{
		SoundManager.buttonAudioSource.Play();
		GamePlay.Players = 2;
		SceneManager.LoadScene(5);
	}

	public void three_player()
	{
		SoundManager.buttonAudioSource.Play();
        GamePlay.Players = 3;
		SceneManager.LoadScene(5);
	}

	public void four_player()
	{
		SoundManager.buttonAudioSource.Play();
        GamePlay.Players = 4;
		SceneManager.LoadScene(5);
	}

	public void quit()
	{
		SoundManager.buttonAudioSource.Play ();
		Application.Quit ();
	}
}
