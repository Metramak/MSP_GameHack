using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public bool isFullScreen;
    public AudioMixer am; 

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void AutoVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
