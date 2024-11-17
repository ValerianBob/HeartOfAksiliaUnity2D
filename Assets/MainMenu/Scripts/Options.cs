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

    public TextMeshProUGUI placeholderText;

    void Start()
    {
        applyAll.onClick.AddListener(ApplyAll);
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
        if (float.TryParse(inputCameraSize.text, out OptionsConfig.Instance.cameraSize) && OptionsConfig.Instance.cameraSize != mainCamera.orthographicSize && OptionsConfig.Instance.cameraSize > 0 && OptionsConfig.Instance.cameraSize <= 20f)
        {
            mainCamera.orthographicSize = OptionsConfig.Instance.cameraSize;
        }
    }

    public void ApplyAll()
    {
        SoundSlider();
        ChangeCameraSize();
    }

    public void ExecConfig()
    {
        audioButtonSource.volume = OptionsConfig.Instance.sound;
        sliderAudio.value = OptionsConfig.Instance.sound;
        textAudioPercent.text = Convert.ToString(Convert.ToInt32(sliderAudio.value * 100)) + " %";
        placeholderText = inputCameraSize.placeholder.GetComponent<TextMeshProUGUI>();
        placeholderText.text = Convert.ToString(OptionsConfig.Instance.cameraSize);
        mainCamera.orthographicSize = OptionsConfig.Instance.cameraSize;
    }
}
