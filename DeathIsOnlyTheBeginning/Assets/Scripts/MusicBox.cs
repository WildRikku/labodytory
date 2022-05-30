using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public Player player;

    public bool isPlaying = false;
    // Start is called before the first frame update
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isPlaying)
                GetComponent<AudioSource>().Play();
            isPlaying = true;
        }
    }
}
