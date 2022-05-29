using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

   
[System.Serializable]
public class Sound
{

	public string name;

	public AudioClip clip;
	public AudioMixerGroup mixer;

	[Range(-80f, 0f)]
	public float volume = 0;

	[Range(-3f, 3f)]
	public float pitch = 1;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;

}


