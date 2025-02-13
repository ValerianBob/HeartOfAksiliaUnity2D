using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip[] Hit;
    public AudioClip[] SuperWeaponSounds;
    public AudioClip[] OtherSounds;

    public AudioSource audioSource;

    public GameObject playerPosition;

    public bool playerFound = false;

    private float soundsDistance = 40f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        { 
            playerPosition = GameObject.Find("Kaylo");
            playerFound = true;         
        }
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
      
        audioSource.PlayOneShot(GunSounds[index]);
    }

    public void PlayEnemyDeathSound(int index, Vector2 soundPosition)
    {
        float distance = Vector2.Distance(playerPosition.transform.position, soundPosition);
        float maxDistance = soundsDistance;
        float volume = Mathf.Clamp01(1 - distance / maxDistance);

        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempAudioSource = tempSound.AddComponent<AudioSource>();
        tempAudioSource.clip = EnemyDeathSounds[index];
        tempAudioSource.volume = audioSource.volume * volume;
        tempAudioSource.Play();

        Destroy(tempSound, EnemyDeathSounds[index].length);
    }

    public void PlayShopsSound(int index)
    {
        audioSource.PlayOneShot(ShopsSounds[index]);
    }

    public void PlayBuildsSound(int index, Vector2 soundPosition)
    {
        float distance = Vector2.Distance(playerPosition.transform.position, soundPosition);
        float maxDistance = soundsDistance;
        float volume = Mathf.Clamp01(1 - distance / maxDistance);
       
        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempAudioSource = tempSound.AddComponent<AudioSource>();
        tempAudioSource.clip = BuildsSounds[index];
        tempAudioSource.volume = audioSource.volume * volume;
        tempAudioSource.Play();
      
        Destroy(tempSound, BuildsSounds[index].length);
    }

    public void PlayInGameMenuSound(int index)
    {
        audioSource.PlayOneShot(InGameMenuSound[index]);
    }

    public void PlayPressTheButton(int index)
    {
        audioSource.PlayOneShot(PressButton[index]);
    }

    public void PlayTurretShots(int index, Vector2 soundPosition)
    {
        float distance = Vector2.Distance(playerPosition.transform.position, soundPosition);
        float maxDistance = soundsDistance;
        float volume = Mathf.Clamp01(1 - distance / maxDistance);
       
        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempAudioSource = tempSound.AddComponent<AudioSource>();
        tempAudioSource.clip = TurretShots[index];
        tempAudioSource.volume = audioSource.volume * volume;
        tempAudioSource.Play();
     
        Destroy(tempSound, TurretShots[index].length);
    }

    public void PlayHit(int index, Vector2 soundPosition)
    {
        float distance = Vector2.Distance(playerPosition.transform.position, soundPosition);
        float maxDistance = soundsDistance;
        float volume = Mathf.Clamp01(1 - distance / maxDistance);

        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempAudioSource = tempSound.AddComponent<AudioSource>();
        tempAudioSource.clip = Hit[index];
        tempAudioSource.volume = audioSource.volume * volume;
        tempAudioSource.Play();

        Destroy(tempSound, Hit[index].length);
    }

    public void PlaySuperWeaponSounds(int index, Vector2 soundPosition)
    {
        float distance = Vector2.Distance(playerPosition.transform.position, soundPosition);
        float maxDistance = soundsDistance;
        float volume = Mathf.Clamp01(1 - distance / maxDistance);

        
        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempAudioSource = tempSound.AddComponent<AudioSource>();
        tempAudioSource.clip = SuperWeaponSounds[index];
        tempAudioSource.volume = audioSource.volume * volume;
        tempAudioSource.Play();
       
        Destroy(tempSound, SuperWeaponSounds[index].length);
    }

    public void PlayOtherSounds(int index, Vector2 soundPosition)
    {
        audioSource.PlayOneShot(OtherSounds[index]);
    }
}
