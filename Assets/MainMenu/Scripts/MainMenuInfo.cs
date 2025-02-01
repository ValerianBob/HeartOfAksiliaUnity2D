using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInfo : MonoBehaviour
{
    public GameObject buttons;
    public GameObject controlsInfo;
    public GameObject buildsInfo;
    public GameObject gunsInfo;
    public GameObject superGunsInfo;
    public GameObject enemyInfo;

    public Button controlsButton;
    public Button buildsButton;
    public Button gunsButton;
    public Button superGunsButton;
    public Button enemyButton;
    public Button backFromInfo;


    void Start()
    {
        backFromInfo.onClick.AddListener(BackToMainMenu);
        controlsButton.onClick.AddListener(Controls);
        buildsButton.onClick.AddListener(Builds);
        gunsButton.onClick.AddListener(Guns);
        superGunsButton.onClick.AddListener(SuperGuns);
        enemyButton.onClick.AddListener(Enemy);
    }

    void Controls()
    {
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        controlsInfo.SetActive(true);
    }

    void Builds()
    {
        controlsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(true);
    }

    void Guns()
    {
        controlsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(true);
    }

    void SuperGuns()
    {
        controlsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(true);
    }

    void Enemy()
    {
        controlsInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(true);
    }

    void BackToMainMenu()
    {
        SoundsController.Instance.PlayInGameMenuSound(0);
        gameObject.SetActive(false);
        buttons.SetActive(true);
    }
}
