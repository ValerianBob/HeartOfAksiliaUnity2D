using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioSource audioButtonSource;

    public Camera mainCamera;

    public Slider sliderAudio;

    public TMP_InputField inputCameraSize;

    public TextMeshProUGUI textAudioPercent;

    public Button applyAll;

    public Button resetAll;

    public TextMeshProUGUI placeholderText;

    public float cameraSizeOut;

    void Start()
    {
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
            audioButtonSource.volume = OptionsConfig.Instance.sound;
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
        ChangeCameraSize();
    }

    public void ResetAll()
    {
        OptionsConfig.Instance.sound = 0.5f;
        OptionsConfig.Instance.cameraSize = 10;
        ExecConfig();
    }

    public void ExecConfig()
    {
        audioButtonSource.volume = OptionsConfig.Instance.sound;
        sliderAudio.value = OptionsConfig.Instance.sound;
        textAudioPercent.text = Convert.ToString(Convert.ToInt32(sliderAudio.value * 100)) + " %";
        placeholderText = inputCameraSize.placeholder.GetComponent<TextMeshProUGUI>();
        inputCameraSize.text = OptionsConfig.Instance.cameraSize.ToString();
        placeholderText.text = Convert.ToString(OptionsConfig.Instance.cameraSize);
        mainCamera.orthographicSize = OptionsConfig.Instance.cameraSize;
    }
}
