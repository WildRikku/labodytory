using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public Player player;

    public bool isPlaying = false;
    private bool canPlay = false;
    public Vector3 offsetPosition;

    public GameObject useTextPrefab;
    private GameObject objuseText = null;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && (canPlay == true) && (timer>=0.5))
        {
            timer = 0;

            if (isPlaying == false)
            {
                PlayMusic();
                Destroy(objuseText);
            }
            else
            {
                StopMusic();
            }
        }
        timer += Time.deltaTime; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowUseText();
            canPlay = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        DestroyUseText();
        canPlay = false;
        isPlaying = false;
        StopMusic();
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + offsetPosition, Quaternion.Euler(40f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<E>";
        }
    }
    void DestroyUseText()
    {
        if (objuseText)
        {
            Destroy(objuseText);
            objuseText = null;
        }
    }


    public void PlayMusic()
    {
        isPlaying = true;
    }

    public void StopMusic()
    {
        isPlaying = false;
    }
}
