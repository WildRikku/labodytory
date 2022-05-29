using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    private static float mainVol = 1f;
    private static float audioVol = 1f;
    

    public Globals(){
        
    }

    public static void setMainVol(float main)
    {
        mainVol = main;
    }

    public static float getMainVol()
    {
        return mainVol;
    }

    public static void setAudioVol(float audio)
    {
        audioVol = audio;
    }

    public static float getAudioVol()
    {
        return audioVol;
    }

}
