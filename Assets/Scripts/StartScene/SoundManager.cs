using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMsource;

    public void SetMusicVolume(float volume)
    {
        BGMsource.volume = volume;
    }
}
