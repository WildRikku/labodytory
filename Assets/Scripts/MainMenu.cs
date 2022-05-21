using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void openOptions()
    {
                
    }

    public void openCredits()
    {

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
