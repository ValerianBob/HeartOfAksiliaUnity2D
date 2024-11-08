using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuController : MonoBehaviour
{
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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                panel.SetActive(isPause);
            }
        }
    }

    public void Resume()
    {
        buttonSounds.Play();
        isPause = false;
        isOptions = false;
        isChoose = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        panel.SetActive(isPause);
        inGameMenuButtons.SetActive(true);
        optionsMenu.SetActive(isOptions);
        chooseMainMenu.SetActive(isChoose);
    }

    public void MainMenu()
    {
        buttonSounds.Play();
        isChoose = true;
        inGameMenuButtons.SetActive(!isChoose);
        chooseMainMenu.SetActive(isChoose);
    }

    public void Options()
    {
        buttonSounds.Play();
        isOptions = true;
        inGameMenuButtons.SetActive(!isOptions);
        optionsMenu.SetActive(isOptions);
    }

    public void BackFromOptions()
    {
        buttonSounds.Play();
        isOptions = false;
        optionsMenu.SetActive(isOptions);
        inGameMenuButtons.SetActive(!isOptions);
    }

    public void BackToMainMenu()
    {
        buttonSounds.Play();
        isChoose = false;
        chooseYes.transform.position = new Vector3(-1000f, -1000f, 0f);
        chooseNo.transform.position = new Vector3(-1000f, -1000f, 0f); 
        textOfChose.text = "Quit...";
        textOfChose.transform.localPosition = Vector3.zero;
        StartCoroutine(WaitForLoading(0.25f));
        isPause = false;
        Time.timeScale = 1;
    }

    public void BackToGame()
    {
        buttonSounds.Play();
        isChoose = false;
        chooseMainMenu.SetActive(isChoose);
        inGameMenuButtons.SetActive(!isChoose);
    }

    IEnumerator WaitForLoading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
}