using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    bool logged = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cable.isActive && elevator.trig && elevator.inFront)
        {
            // Load next Scene here!
            if (!logged)
            {
                Debug.Log("Level completed. Press Space to continue...");
                logged = true;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(fadeToBlack());
            }
        }
    }

    IEnumerator fadeToBlack()
    {
        GameObject panel = GameObject.Find("Panel");
        GameObject canvas = GameObject.Find("FadeToBlackCanvas");
        canvas.GetComponent<Canvas>().enabled = true;
        panel.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        panel.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameLvl2");
    }
}
