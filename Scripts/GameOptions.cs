using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame() {
        SceneManager.LoadScene(5);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLiveMatch()
    {
        SceneManager.LoadScene(3);
    }


    public void SinglePlay()
    {
        SceneManager.LoadScene(3);
    }

    public void SpeacialPlay()
    {
        SceneManager.LoadScene(4);
    }
}
