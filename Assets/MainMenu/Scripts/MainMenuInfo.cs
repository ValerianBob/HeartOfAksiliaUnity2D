using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInfo : MonoBehaviour
{
    public GameObject buttons;

    public Button backFromInfo;


    void Start()
    {
        backFromInfo.onClick.AddListener(BackToMainMenu);
    }

    void Update()
    {
        
    }

    void BackToMainMenu()
    {
        SoundsController.Instance.PlayInGameMenuSound(0);
        gameObject.SetActive(false);
        buttons.SetActive(true);
    }
}
