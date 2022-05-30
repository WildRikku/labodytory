using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        // Start background music
        AudioSource backgroundmusic = GameObject.Find("Backgroundmusic").GetComponent<AudioSource>();
        backgroundmusic.enabled = true;
        StartCoroutine(FadeInAudio(backgroundmusic, 2));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeInAudio(AudioSource audio, float fadetime)
    {
        while (audio.volume < 0.5)
        {
            audio.volume += Time.deltaTime / fadetime;
            yield return null;
        }
    }
}
