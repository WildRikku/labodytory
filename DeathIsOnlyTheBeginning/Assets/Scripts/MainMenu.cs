using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        SoundManager.playSound(SoundManager.Sound.MenuMusic);
        transform.Find("New Game BTN").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.Level1);
        }; 
        
    }

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