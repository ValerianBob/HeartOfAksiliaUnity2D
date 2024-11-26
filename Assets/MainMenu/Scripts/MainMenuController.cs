using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private AudioSource _buttonSounds;

    public TextMeshProUGUI loadingText;
    public TextMeshProUGUI optionsTitle;
    public TextMeshProUGUI resultTitle;

    public GameObject mainMenuButtons;
    public GameObject optionsMenu;
    public GameObject resultsMenu;
    public GameObject chooseQuitMenu;
    public GameObject gameTitle;

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
        _buttonSounds = GetComponent<AudioSource>();
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
        _buttonSounds.Play();
        gameTitle.SetActive(false);
        mainMenuButtons.SetActive(false);
        loadingText.transform.localPosition = Vector3.zero;
        loadingText.text = "Loading...";
        StartCoroutine(WaitForLoading(0.25f));
    }

    public void Options()
    {
        _buttonSounds.Play();
        isOptions = true;
        mainMenuButtons.SetActive(!isOptions);
        optionsMenu.SetActive(isOptions);
        Debug.Log("Options");
    }

    public void Results()
    {
        _buttonSounds.Play();
        isResults = true;
        mainMenuButtons.SetActive(!isResults);
        resultsMenu.SetActive(isResults);
        Debug.Log("Results");
    }

    public void Quit()
    {
        _buttonSounds.Play();
        isChoose = true;
        mainMenuButtons.SetActive(!isChoose);
        chooseQuitMenu.SetActive(isChoose);
    }

    public void BackFromOptions()
    {
        _buttonSounds.Play();
        isOptions = false;
        optionsMenu.SetActive(isOptions);
        mainMenuButtons.SetActive(!isOptions);
    }

    public void BackFromResults()
    {
        _buttonSounds.Play();
        isResults = false;
        resultsMenu.SetActive(isResults);
        mainMenuButtons.SetActive(!isResults);
    }

    public void QuitFromGame()
    {
        _buttonSounds.Play();
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        _buttonSounds.Play();
        isChoose = false;
        chooseQuitMenu.SetActive(isChoose);
        mainMenuButtons.SetActive(!isChoose);
    }

    IEnumerator WaitForLoading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Game");
    }
}
