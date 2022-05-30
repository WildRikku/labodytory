using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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



    public void playGame(AudioSource audioSource)
    {
        SceneManager.LoadScene("GameLvl1");
        audioSource.Play();
    }

    
    public void quitGame(AudioSource audioSource)
    {
        Application.Quit();
        audioSource.Play();
    }

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}