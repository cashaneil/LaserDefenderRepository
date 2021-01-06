using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //this has to be used in this case, for scenes.

public class Level : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0); //in unity build settings, index no. of StartMenu scene is 0
    }

    public void LoadQuitGame()
    {
        //will only work on EXE
        print("Quitting");
        Application.Quit();
    }
}
