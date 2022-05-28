using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        Click,
        Note,
        Hover,
	    MenuMusic,
	    DoorOpen,
	    Elevator,
	    Pick,
	    Switch,
	    Electric,

    }

    private static Dictionary<Sound, float> soundTimerDict;
    private static GameObject oneShotGO;
    private static AudioSource oneShotAS;


    public static void Initialize()
    {
        soundTimerDict = new Dictionary<Sound, float>();
        soundTimerDict[Sound.Click] = 0f;
    }

    public static void playSound(Sound sound)
    {
        if (CanPlay(sound))
        {
            if(oneShotGO == null)
            {
                oneShotGO = new GameObject("Sound");
                oneShotAS = oneShotGO.AddComponent<AudioSource>();
            }
            
        }
        
        oneShotAS.PlayOneShot(GetAudioClip(sound));
    }

    private static bool CanPlay(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.Click:
                if (soundTimerDict.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDict[sound];
                    float playerMoveTimerMax = .05f;
                    if(lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDict[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.clip;
            }
        }
        return null;
    }

    public static void AddButtonSoundClick(this Button_UI buttonUI)
    {
        buttonUI.ClickFunc += () => SoundManager.playSound(Sound.Click);
        buttonUI.MouseOverOnceFunc += () => SoundManager.playSound(Sound.Hover);
    }
}