using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private AudioSource buttonSounds;

    public TextMeshProUGUI MainMenuTitle;

    public GameObject mainMenuButtons;
    public GameObject optionsMenu;
    public GameObject resultsMenu;
    public GameObject chooseQuitMenu;

    public Button newGame;
    public Button options;
    public Button results;
    public Button quit;
    public Button backFromOptions;
    public Button backFromResults;
    public Button chooseYes;
    public Button chooseNo;

    public bool isOptions = false;
    public bool isResults = false;
    public bool isChoose = false;

    public void Start()
    {
        buttonSounds = GetComponent<AudioSource>();
        newGame.onClick.AddListener(NewGame);
        options.onClick.AddListener(Options);
        results.onClick.AddListener(Results);
        quit.onClick.AddListener(Quit);
        backFromOptions.onClick.AddListener(BackFromOptions);
        backFromResults.onClick.AddListener(BackFromResults);
        chooseYes.onClick.AddListener(QuitFromGame);
        chooseNo.onClick.AddListener(BackToMainMenu);
    }

    public void NewGame()
    {
        buttonSounds.Play();
        mainMenuButtons.SetActive(false);
        MainMenuTitle.transform.localPosition = Vector3.zero;
        MainMenuTitle.text = "Loading...";
        StartCoroutine(WaitForLoading(0.25f));
    }

    public void Options()
    {
        buttonSounds.Play();
        isOptions = true;
        MainMenuTitle.text = "Options";
        mainMenuButtons.SetActive(!isOptions);
        optionsMenu.SetActive(isOptions);
        Debug.Log("Options");
    }

    public void Results()
    {
        buttonSounds.Play();
        isResults = true;
        MainMenuTitle.text = "Results";
        mainMenuButtons.SetActive(!isResults);
        resultsMenu.SetActive(isResults);
        Debug.Log("Results");
    }

    public void Quit()
    {
        buttonSounds.Play();
        isChoose = true;
        mainMenuButtons.SetActive(!isChoose);
        chooseQuitMenu.SetActive(isChoose);
        MainMenuTitle.text = "";
    }

    public void BackFromOptions()
    {
        buttonSounds.Play();
        isOptions = false;
        MainMenuTitle.text = "Heart Of Aksilia";
        optionsMenu.SetActive(isOptions);
        mainMenuButtons.SetActive(!isOptions);
    }

    public void BackFromResults()
    {
        buttonSounds.Play();
        isResults = false;
        MainMenuTitle.text = "Heart Of Aksilia";
        resultsMenu.SetActive(isResults);
        mainMenuButtons.SetActive(!isResults);
    }

    public void QuitFromGame()
    {
        buttonSounds.Play();
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        buttonSounds.Play();
        isChoose = false;
        chooseQuitMenu.SetActive(isChoose);
        MainMenuTitle.text = "Heart Of Aksilia";
        mainMenuButtons.SetActive(!isChoose);
    }

    IEnumerator WaitForLoading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Game");
    }
}
