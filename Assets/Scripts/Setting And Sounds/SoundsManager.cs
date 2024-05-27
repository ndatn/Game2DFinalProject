using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("--Sound--")]
    [SerializeField] AudioSource musicSound;
    [SerializeField] AudioSource sFXSound;

    [Header("--Clip--")]
    public AudioClip background;
    public AudioClip click;
    public AudioClip running;
    public AudioClip Sword1;
    public AudioClip Sword2;
    public AudioClip Gun;
    public AudioClip Damage;
    public AudioClip DamageS;
    public AudioClip Die;
    public AudioClip BWood;
    public AudioClip Portal;
    public AudioClip Dash;

    private static SoundsManager instance;
    public static SoundsManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        musicSound.clip = background;
        musicSound.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        //sFXSound.clip = clip;
        //sFXSound.Play();
        sFXSound.PlayOneShot(clip);
    }
    public void PlaySFXrun(AudioClip clip)
    {
        sFXSound.clip = clip;
        sFXSound.loop = true;
        sFXSound.Play();
    }
        public void StopSFXrun()
    {
        sFXSound.loop = false;
        sFXSound.Stop();
    }
}