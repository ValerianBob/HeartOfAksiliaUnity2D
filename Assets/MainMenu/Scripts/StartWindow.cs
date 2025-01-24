using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartWindow : MonoBehaviour
{
    public GameObject mainMenuButtons;
    public GameObject titleOfGame;
    public GameObject background;
    public GameObject backgroundPlay;
    public GameObject imagePlanet;
    public MainMenuEnterName MainMenuEnterName;

    public Button start;

    void Start()
    {
        start.onClick.AddListener(StartButton);
    }

    void StartButton()
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        gameObject.SetActive(false);
        backgroundPlay.SetActive(false);
        background.SetActive(true);
        imagePlanet.SetActive(true);
        mainMenuButtons.SetActive(true);    
        titleOfGame.SetActive(true);
        OptionsConfig.Instance.userName = MainMenuEnterName.LoadFromFile(Application.persistentDataPath + "/saveName.xml");
        if(OptionsConfig.Instance.userName == "")
        {
            mainMenuButtons.SetActive(false) ;
        }
    }
}
