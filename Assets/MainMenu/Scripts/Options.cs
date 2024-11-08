using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioSource audioButtonSource;

    public Camera mainCamera;

    public Slider sliderAudio;

    public TMP_InputField inputCameraSize;

    public TextMeshProUGUI textAudioPercent;

    public Button applyAll;

    public float inputCameraSizeValue = 5;

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
        if (sliderAudio.value != audioButtonSource.volume)
        {
            textAudioPercent.text = Convert.ToString(Convert.ToInt32(sliderAudio.value*100)) + " %";
            audioButtonSource.volume = sliderAudio.value;
        }
    }

    public void ChangeCameraSize()
    {
        if (float.TryParse(inputCameraSize.text, out inputCameraSizeValue) && inputCameraSizeValue != mainCamera.orthographicSize && inputCameraSizeValue > 0 && inputCameraSizeValue <= 15f)
        {
            mainCamera.orthographicSize = inputCameraSizeValue;
        }
    }

    public void ApplyAll()
    {
        SoundSlider();
        ChangeCameraSize();
    }
}
