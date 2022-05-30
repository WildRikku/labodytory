using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelThreeManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    bool logged = false;
    public bool debugMode = true;

    public GameObject useTextPrefab;
    public GameObject obElevator;
    public Vector3 offsetPosition;
    private GameObject objuseText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (elevator.opened && elevator.inFront)
        {
            // Load next Scene here!
            if (!logged)
            {
                logged = true;
                ShowUseText();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(fadeToBlackAndOutro());
            }
        }
        if (elevator.inFront == false)
        {
            DestroyUseText();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        else if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("GameLvl3");
        }
    }

    IEnumerator fadeToBlackAndOutro()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().isStopped = true;
        GameObject panel = GameObject.Find("Panel");
        GameObject canvas = GameObject.Find("FadeToBlackCanvas");
        GameObject text1 = GameObject.Find("IntroText1");
        GameObject text2 = GameObject.Find("IntroText2");
        GameObject text3 = GameObject.Find("IntroText3");
        text1.GetComponent<Text>().enabled = false;
        canvas.GetComponent<Canvas>().enabled = true;
        panel.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        panel.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        yield return new WaitForSeconds(4);
        text1.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(30);
        text1.GetComponent<Text>().enabled = false;
        text2.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(30);
        text2.GetComponent<Text>().enabled = false;
        text3.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(30);
        text3.GetComponent<Text>().enabled = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, obElevator.transform.position + offsetPosition, Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<Space> Leave";
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
