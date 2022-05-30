using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelOneManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    bool logged = false;
    public bool debugMode = true;

    private bool startFade = false;

    public GameObject useTextPrefab;
    public GameObject obElevator;
    public Vector3 offsetPosition;
    private GameObject objuseText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeFromBlack());
    }

    // Update is called once per frame
    void Update()
    {
        if (cable.isActive && elevator.opened && elevator.inFront)
        {
            // Load next Scene here!
            if (!logged)
            {
                Debug.Log("Level completed. Press Space to continue...");
                logged = true;
                ShowUseText();
            }

            if (Input.GetKey(KeyCode.Space) && !startFade)
            {
                StartCoroutine(fadeToBlackAndNextLevel());
                startFade = true;
            }
        }
        if (elevator.inFront == false)
        {
            DestroyUseText();
        }
        if(Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu");
        }
        else if(Input.GetKey(KeyCode.Backspace)) {
            SceneManager.LoadScene("GameLvl1");
        }
    }

    IEnumerator fadeToBlackAndNextLevel()
    {
        GameObject panel = GameObject.Find("Panel");
        GameObject canvas = GameObject.Find("FadeToBlackCanvas");
        canvas.GetComponent<Canvas>().enabled = true;
        panel.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        panel.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameLvl2");
    }

    IEnumerator fadeFromBlack()
    {
        GameObject panel = GameObject.Find("Panel");
        GameObject canvas = GameObject.Find("FadeToBlackCanvas");
        GameObject text1caption = GameObject.Find("IntroText1Caption");
        GameObject text1 = GameObject.Find("IntroText1");
        GameObject text2caption = GameObject.Find("IntroText2Caption");
        GameObject text2 = GameObject.Find("IntroText2");
        GameObject.Find("Player").GetComponent<NavMeshAgent>().isStopped = true;

        if (!debugMode)
        {
            // Show intro text, two lines, and fade from black
            text1.GetComponent<Text>().enabled = false;
            text1caption.GetComponent<Text>().enabled = false;
            yield return new WaitForSeconds(1);
            text1.GetComponent<Text>().enabled = true;
            text1caption.GetComponent<Text>().enabled = true;
            canvas.GetComponent<Canvas>().enabled = true;
            panel.GetComponent<Image>().CrossFadeAlpha(1, 0, false);
            yield return new WaitForSeconds(6);
            text1.GetComponent<Text>().enabled = false;
            text1caption.GetComponent<Text>().enabled = false;
            text2.GetComponent<Text>().enabled = true;
            text2caption.GetComponent<Text>().enabled = true;
            yield return new WaitForSeconds(5);
            text2.GetComponent<Text>().enabled = false;
            text2caption.GetComponent<Text>().enabled = false;
            panel.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
        }

        yield return new WaitForSeconds(2);
        canvas.GetComponent<Canvas>().enabled = false;
        GameObject.Find("Player").GetComponent<NavMeshAgent>().isStopped = false;
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, obElevator.transform.position + offsetPosition, Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<Space> next level";
        }
    }
    void DestroyUseText()
    {
        if (objuseText)
        {
            Destroy(objuseText);
            objuseText = null;
            logged = false;
        }
    }
}
