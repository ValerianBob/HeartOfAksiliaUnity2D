using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInfo : MonoBehaviour
{
    private Sprite _controlsButtonOrig;
    private Sprite _buildsButtonOrig;
    private Sprite _gunsButtonOrig;
    private Sprite _superGunsButtonOrig;
    private Sprite _enemyButtonOrig;

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

    public Sprite controlsButtonPressed;
    public Sprite buildsButtonPressed;
    public Sprite gunsButtonPressed;
    public Sprite superGunsButtonPressed;
    public Sprite enemyButtonPressed;

    void Start()
    {  
        backFromInfo.onClick.AddListener(BackToMainMenu);
        controlsButton.onClick.AddListener(Controls);
        buildsButton.onClick.AddListener(Builds);
        gunsButton.onClick.AddListener(Guns);
        superGunsButton.onClick.AddListener(SuperGuns);
        enemyButton.onClick.AddListener(Enemy);

        _controlsButtonOrig = controlsButton.image.sprite;
        _buildsButtonOrig = buildsButton.image.sprite;
        _gunsButtonOrig = gunsButton.image.sprite;
        _superGunsButtonOrig = superGunsButton.image.sprite;
        _enemyButtonOrig = enemyButton.image.sprite;

        controlsButton.image.sprite = controlsButtonPressed;
    }

    void Controls()
    {
        Debug.Log("52");
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        controlsInfo.SetActive(true);

        controlsButton.image.sprite = controlsButtonPressed;
        buildsButton.image.sprite = _buildsButtonOrig;
        gunsButton.image.sprite = _gunsButtonOrig;
        superGunsButton.image.sprite = _superGunsButtonOrig;
        enemyButton.image.sprite = _enemyButtonOrig;
    }

    void Builds()
    {
        controlsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(true);

        controlsButton.image.sprite = _controlsButtonOrig;
        buildsButton.image.sprite = buildsButtonPressed;
        gunsButton.image.sprite = _gunsButtonOrig;
        superGunsButton.image.sprite = _superGunsButtonOrig;
        enemyButton.image.sprite = _enemyButtonOrig;
    }

    void Guns()
    {
        controlsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(true);

        controlsButton.image.sprite = _controlsButtonOrig;
        buildsButton.image.sprite = _buildsButtonOrig;
        gunsButton.image.sprite = gunsButtonPressed;
        superGunsButton.image.sprite = _superGunsButtonOrig;
        enemyButton.image.sprite = _enemyButtonOrig;
    }

    void SuperGuns()
    {
        controlsInfo.SetActive(false);
        enemyInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(true);

        controlsButton.image.sprite = _controlsButtonOrig;
        buildsButton.image.sprite = _buildsButtonOrig;
        gunsButton.image.sprite = _gunsButtonOrig;
        superGunsButton.image.sprite = superGunsButtonPressed;
        enemyButton.image.sprite = _enemyButtonOrig;
    }

    void Enemy()
    {
        controlsInfo.SetActive(false);
        buildsInfo.SetActive(false);
        gunsInfo.SetActive(false);
        superGunsInfo.SetActive(false);
        enemyInfo.SetActive(true);
        controlsButton.image.sprite = _controlsButtonOrig;
        buildsButton.image.sprite = _buildsButtonOrig;
        gunsButton.image.sprite = _gunsButtonOrig;
        superGunsButton.image.sprite = _superGunsButtonOrig;
        enemyButton.image.sprite = enemyButtonPressed;
    }

    void BackToMainMenu()
    {
        SoundsController.Instance.PlayInGameMenuSound(0);
        gameObject.SetActive(false);
        buttons.SetActive(true);
    }
}
