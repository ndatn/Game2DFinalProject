using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider master, music, sFX;
    public AudioMixer audioMixer;

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }
    public void ChangeMasterVol()
    {
        audioMixer.SetFloat("Master", master.value);
    }public void ChangeMusicVol()
    {
        audioMixer.SetFloat("Music", music.value);
    }public void ChangeSFXVol()
    {
        audioMixer.SetFloat("SFX", sFX.value);
    }
}
