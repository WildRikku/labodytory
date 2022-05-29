using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{

    [Header("Menü Sounds")]
    public AudioClip click_sound;
    public AudioClip hover_sound;
    private AudioSource source;
    private bool playAudio;
    private int buttonindex;

    [Header("Menü Button")]
    public Color buttonHoverColor;
    public int buttonTextHoverSize;

    private AsyncOperation asyncLoad;

    [Header("Wörterbuch")]
    private Woerterbuch buch;
    public Text btn_1Text;
    public Text btn_2Text;
    public Text btn_3Text;
    public Text btn_4Text;
    public string btn_1Key;
    public string btn_2Key;
    public string btn_3Key;
    public string btn_4Key;

    //Wird beim Start ausgeführt
    void Start()
    {
        playAudio = false;
        source = this.GetComponent<AudioSource>();

        StartCoroutine(LoadYourAsyncScene());

        WorterbuchLesen();

    }

    public void WorterbuchLesen()
    {
        buch = (Woerterbuch)FindObjectOfType(typeof(Woerterbuch));

        if (buch != null)
        {
            if (btn_1Text != null)
            { btn_1Text.text = buch.lies(btn_1Key); }

            if (btn_2Text != null)
            { btn_2Text.text = buch.lies(btn_2Key); }

            if (btn_3Text != null)
            { btn_3Text.text = buch.lies(btn_3Key); }

            if (btn_4Text != null)
            { btn_4Text.text = buch.lies(btn_4Key); }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {

        asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        asyncLoad.allowSceneActivation = false;

        // yield to other processes until the scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Do something here like enabling the play button or closing the splash/loading screen
    }

    //Wird jeden Frame ausgeführt
    void Update()
    {
        if (playAudio == true)
        {
            playAudio = false;
            Invoke("WaitManager", 0.1f) ;
        }
    }

    //Warte 1 Sekunde vor Szenenwechsel, damit ein Klicksound ausgeführt wird
    private void WaitManager()
    {

        switch(buttonindex)
        {
            case 4:
                SceneManager.LoadScene("MenuScene");
                break;
            case 3:
                Application.Quit();
                break;
            case 2:
                SceneManager.LoadScene("CreditScene");
                break;
            case 1:
                asyncLoad.allowSceneActivation = true;
                //SceneManager.LoadScene("SampleScene");
                break;
        }
    }

   
    //Löst den Szenenwechsel zur Spielszene aus
    public void GoToGameScene()
    {
        if (playAudio == false)
        {
            playAudio = true;
            buttonindex = 1;
        }    
    }

    //Löst den Szenenwechsel zu Credits aus
    public void GoToCredits()
    {
        if (playAudio == false)
        {
            playAudio = true;
            buttonindex = 2;
        }
    }

    //Löst den Szenenwechsel zur Beendet das Spiel
    public void Quit()
    {
        if (playAudio == false)
        {
            playAudio = true;
            buttonindex = 3;
        }
    }

    //Beendet das Spiel
    public void GoBackToMenu()
    {
        if (playAudio == false)
        {
            playAudio = true;
            buttonindex = 4;
        }
    }

}
