using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartWindow : MonoBehaviour
{
    public GameObject mainMenuButtons;
    public GameObject titleOfGame;

    public Button start;

    void Start()
    {
        start.onClick.AddListener(StartButton);
    }

    void StartButton()
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        gameObject.SetActive(false);
        mainMenuButtons.SetActive(true);    
        titleOfGame.SetActive(true);
    }
}
