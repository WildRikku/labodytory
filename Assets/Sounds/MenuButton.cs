using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Canvas canvas;
    private AudioSource audioSource;
    private ScreenManager screenManager;

    private AudioClip son_mouseHover;
    private AudioClip son_mouseClick;

    private Text obj_text;
    private int initFontSize;
    private int hoverFontSize;
    private Color initColor;
    private Color hoverColor;

    private bool isClick = false;

    //Create Event
    void Start()
    {
        
        audioSource = canvas.GetComponent<AudioSource>();
        screenManager = canvas.GetComponent<ScreenManager>();

        obj_text = GetComponentInChildren<Text>();
        hoverColor = screenManager.buttonHoverColor;
        son_mouseHover = screenManager.hover_sound;
        son_mouseClick = screenManager.click_sound;
        hoverFontSize = screenManager.buttonTextHoverSize;
        initColor = obj_text.color;
        initFontSize = obj_text.fontSize;
    }

    //Mouse Enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        obj_text.color = hoverColor;
        obj_text.fontSize = hoverFontSize;
        audioSource.clip = son_mouseHover;
        audioSource.Play();
    }

    //Mouse Leave
    public void OnPointerExit(PointerEventData eventData)
    {
        obj_text.color = initColor;
        obj_text.fontSize = initFontSize;
    }

    //Mouse Klick
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isClick == false)
        {
            audioSource.clip = son_mouseClick;
            audioSource.Play();
            isClick = true;
        }
    }
}
