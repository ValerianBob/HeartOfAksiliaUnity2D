using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainOptions : MonoBehaviour
{
    private string _currentSceneName;

    public Camera mainCamera;

    public Slider sliderAudio;

    public TMP_InputField inputCameraSize;

    public TextMeshProUGUI textAudioPercent;

    public Button applyAll;

    public GameObject notificationsSystem;

    public Toggle notificationsToggle;

    public Button resetAll;

    public TextMeshProUGUI placeholderText;

    public float cameraSizeOut;

    void Start()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        applyAll.onClick.AddListener(ApplyAll);
        resetAll.onClick.AddListener(ResetAll);
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
       if (sliderAudio.value != OptionsConfig.Instance.sound)
       {
            textAudioPercent.text = Convert.ToString(Convert.ToInt32(sliderAudio.value * 100)) + " %";
            OptionsConfig.Instance.sound = sliderAudio.value;
            SoundsController.Instance.audioSource.volume = OptionsConfig.Instance.sound;
       }
    }

    public void ChangeCameraSize()
    {
        if (float.TryParse(inputCameraSize.text, out cameraSizeOut) && cameraSizeOut != mainCamera.orthographicSize && cameraSizeOut > 0 && cameraSizeOut <= 20f)
        {
            mainCamera.orthographicSize = cameraSizeOut;
            OptionsConfig.Instance.cameraSize = cameraSizeOut;
        }
    }

    public void ApplyAll()
    {
        SoundSlider();
        NotificationSystem();
        ChangeCameraSize();
        SoundsController.Instance.PlayInGameMenuSound(1);
    }

    public void ResetAll()
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        OptionsConfig.Instance.sound = 0.5f;
        OptionsConfig.Instance.cameraSize = 10;
        ExecConfig();
    }

    public void NotificationSystem()
    {
        OptionsConfig.Instance.notificationsSystem = notificationsToggle.isOn;

        if (notificationsSystem != null)
        {
            Debug.Log("Invisible notification" + $" {OptionsConfig.Instance.notificationsSystem}");

            notificationsSystem.SetActive(OptionsConfig.Instance.notificationsSystem);
        }
    }

    public void ExecConfig()
    {
        SoundsController.Instance.audioSource.volume = OptionsConfig.Instance.sound;
        sliderAudio.value = OptionsConfig.Instance.sound;
        textAudioPercent.text = Convert.ToString(Convert.ToInt32(sliderAudio.value * 100)) + " %";
        placeholderText = inputCameraSize.placeholder.GetComponent<TextMeshProUGUI>();
        inputCameraSize.text = OptionsConfig.Instance.cameraSize.ToString();
        placeholderText.text = Convert.ToString(OptionsConfig.Instance.cameraSize);
        mainCamera.orthographicSize = OptionsConfig.Instance.cameraSize;
        notificationsToggle.isOn = OptionsConfig.Instance.notificationsSystem;
        if (_currentSceneName == "Game")
        {
            Debug.Log(_currentSceneName);
            notificationsSystem.SetActive(OptionsConfig.Instance.notificationsSystem);
        }
        ApplyAll();
        
    }
}
