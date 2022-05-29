using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    
   

   // private void Start()
   // {
        
       // mainMixer.GetFloat("mainVolume", out mainValue);
       // audioMixer.GetFloat("audioVolume", out audioValue);

        //mainSlider.value = mainValue;
        //audioSlider.value = audioValue;
    //}


    //public void Awake()
    //{
                
    //}

    public void PlaySound(AudioSource audioSource)
    {
        
        audioSource.Play();
    }

    public void playGame()
    {
        Loader.Load(Loader.Scene.Level1);
    }

    
    public void quitGame()
    {
        Application.Quit();
    }
}