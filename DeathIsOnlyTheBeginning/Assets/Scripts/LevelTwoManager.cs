using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTwoManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    bool logged = false;

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
        if (cable.isActive && elevator.opened && elevator.inFront)
        {
            // Load next Scene here!
            if (!logged)
            {
                Debug.Log("Level completed. Press Space to continue...");
                logged = true;
                ShowUseText();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(fadeToBlackAndNextLevel());
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
            SceneManager.LoadScene("GameLvl2");
        }
    }

    IEnumerator fadeToBlackAndNextLevel() {
        GameObject canvas = GameObject.Find("FadeToBlackCanvas");
        canvas.GetComponent<Canvas>().enabled = true;
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        panel.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameLvl3");
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

