using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public static SoundsController Instance;

    public AudioClip[] GunSounds; 
    public AudioClip[] EnemyDeathSounds;
    public AudioClip[] ShopsSounds;
    public AudioClip[] BuildsSounds;
    public AudioClip[] InGameMenuSound;
    public AudioClip[] PressButton;
    public AudioClip[] TurretShots;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayGunSound(int index)
    {
       // audioSource.clip = GunSounds[index];
        audioSource.PlayOneShot(GunSounds[index]);
    }

    public void PlayEnemyDeathSound(int index)
    {
        audioSource.PlayOneShot(EnemyDeathSounds[index]);
    }

    public void PlayShopsSound(int index)
    {
        audioSource.PlayOneShot(ShopsSounds[index]);
    }

    public void PlayBuildsSound(int index)
    {
        audioSource.PlayOneShot(BuildsSounds[index]);
    }
    public void PlayInGameMenuSound(int index)
    {
        audioSource.PlayOneShot(InGameMenuSound[index]);
    }

    public void PlayPressTheButton(int index)
    {
        audioSource.PlayOneShot(PressButton[index]);
    }

    public void PlayTurretShots(int index)
    {
        audioSource.PlayOneShot(TurretShots[index]);
    }
}
// audioSource.clip = GunSounds[index];
//audioSource.Play(); - PlayOneTime