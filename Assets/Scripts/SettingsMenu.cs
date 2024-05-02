using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        //audioMixer.SetFloat("volume", -50);

    }
    public void SetVolume(float volume)
    {
       audioMixer.SetFloat("volume", volume);
    }
}
