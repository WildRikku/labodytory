using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Slider mainSlider;
    public Slider audioSlider;
    public AudioMixer mainMixer;
    public AudioMixer audioMixer;

    private float mainValue;
    private float audioValue;

    public void SetVolume()
    {
        mainMixer.SetFloat("mainVolume", mainSlider.value);
        //audioMixer.SetFloat("audioVolume", audioSlider.value);

        
    }

    private void Start()
    {
       // mainMixer.GetFloat("mainVolume", out mainValue);
       // audioMixer.GetFloat("audioVolume", out audioValue);

        //mainSlider.value = mainValue;
        //audioSlider.value = audioValue;
    }


    public void Awake()
    {
        SoundManager.instance.Play("Background");
        
    }

    public void playGame()
    {
        Loader.Load(Loader.Scene.Level1);
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