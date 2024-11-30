using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuController : MonoBehaviour
{
    private ShopController _shopController;

    private AudioSource buttonSounds;

    public TextMeshProUGUI textOfChose;

    public GameObject panel;
    public GameObject inGameMenuButtons;
    public GameObject optionsMenu;
    public GameObject chooseMainMenu;

    public Button resume;
    public Button options;
    public Button mainMenu;
    public Button back;
    public Button chooseYes;
    public Button chooseNo;

    public bool isPause = false;
    public bool isOptions = false;
    public bool isChoose = false;

    void Start()
    {
        _shopController = GetComponent<ShopController>();

        buttonSounds = GetComponent<AudioSource>();
        resume.onClick.AddListener(Resume);
        options.onClick.AddListener(Options);
        mainMenu.onClick.AddListener(MainMenu);
        back.onClick.AddListener(BackFromOptions);
        chooseYes.onClick.AddListener(BackToMainMenu);
        chooseNo.onClick.AddListener(BackToGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Resume();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = true;
                Time.timeScale = 0;
                panel.SetActive(isPause);

                if (_shopController.isOpened)
                {
                    _shopController.isOpened = false;
                    _shopController.shopMenu.SetActive(false);
                }

                SoundsController.Instance.PlayInGameMenuSound(1);
            }
        }
    }

    public void Resume()
    {
        isPause = false;
        isOptions = false;
        isChoose = false;
        Time.timeScale = 1;
        panel.SetActive(isPause);
        inGameMenuButtons.SetActive(true);
        optionsMenu.SetActive(isOptions);
        chooseMainMenu.SetActive(isChoose);

        SoundsController.Instance.PlayInGameMenuSound(0);
    }

    public void MainMenu()
    {
        isChoose = true;
        inGameMenuButtons.SetActive(!isChoose);
        chooseMainMenu.SetActive(isChoose);

        SoundsController.Instance.PlayInGameMenuSound(1);
    }

    public void Options()
    {
        isOptions = true;
        inGameMenuButtons.SetActive(!isOptions);
        optionsMenu.SetActive(isOptions);

        SoundsController.Instance.PlayInGameMenuSound(1);
    }

    public void BackFromOptions()
    {
        isOptions = false;
        optionsMenu.SetActive(isOptions);
        inGameMenuButtons.SetActive(!isOptions);

        SoundsController.Instance.PlayInGameMenuSound(0);
    }

    public void BackToMainMenu()
    {
        isChoose = false;
        chooseYes.transform.position = new Vector3(-1000f, -1000f, 0f);
        chooseNo.transform.position = new Vector3(-1000f, -1000f, 0f); 
        textOfChose.text = "Quit...";
        textOfChose.transform.localPosition = Vector3.zero;
        StartCoroutine(WaitForLoading(0.25f));
        isPause = false;
        Time.timeScale = 1;

        SoundsController.Instance.PlayInGameMenuSound(0);
    }

    public void BackToGame()
    {
        isChoose = false;
        chooseMainMenu.SetActive(isChoose);
        inGameMenuButtons.SetActive(!isChoose);

        SoundsController.Instance.PlayInGameMenuSound(0);
    }

    IEnumerator WaitForLoading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
}