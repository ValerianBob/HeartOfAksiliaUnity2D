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

    public TextMeshProUGUI mainMenuTitle;
    public TextMeshProUGUI optionsTitle;
    public TextMeshProUGUI resultTitle;

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
        mainMenuTitle.transform.localPosition = Vector3.zero;
        mainMenuTitle.text = "Loading...";
        StartCoroutine(WaitForLoading(0.25f));
    }

    public void Options()
    {
        buttonSounds.Play();
        isOptions = true;
        mainMenuTitle.text = "";
        mainMenuButtons.SetActive(!isOptions);
        optionsMenu.SetActive(isOptions);
        Debug.Log("Options");
    }

    public void Results()
    {
        buttonSounds.Play();
        isResults = true;
        mainMenuTitle.text = "";
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
        mainMenuTitle.text = "";
    }

    public void BackFromOptions()
    {
        buttonSounds.Play();
        isOptions = false;
        mainMenuTitle.text = "Heart Of Aksilia";
        optionsMenu.SetActive(isOptions);
        mainMenuButtons.SetActive(!isOptions);
    }

    public void BackFromResults()
    {
        buttonSounds.Play();
        isResults = false;
        mainMenuTitle.text = "Heart Of Aksilia";
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
        mainMenuTitle.text = "Heart Of Aksilia";
        mainMenuButtons.SetActive(!isChoose);
    }

    IEnumerator WaitForLoading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Game");
    }
}
