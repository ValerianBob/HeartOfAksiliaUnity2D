using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public static GameOver Instance { get; private set; }

    DateTime currentDate = DateTime.Now;

    private TimerController time;

    private ShopController shop;

    public Image gameOverWindow;
	public TextMeshProUGUI timeResult;

	public Button InMainMenu;

	public bool gameOver = false;
    public bool norep = true;

    private void Start()
    {
        time = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<TimerController>();
        shop = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();

        InMainMenu.onClick.AddListener(GoInMainMenu);
    }

    private void Update()
    {
        if (gameOver && norep)
		{
            Invoke(nameof(GameOverMethod), 2f);
        }
    }

    private void GameOverMethod()
    {
        Time.timeScale = 0;

        gameOverWindow.gameObject.SetActive(true);

        if (shop.isOpened)
        {
            shop.isOpened = false;
            shop.shopMenu.SetActive(false);
        }

        timeResult.text = "Your Result : " + string.Format("{0:00}:{1:00}", time.minutes, time.seconds);
        PlayerResult.Instance.Time = string.Format("{0:00}:{1:00}", time.minutes, time.seconds);
        PlayerResult.Instance.Date = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
        NotificationsController.Instance.AddNewMessage("Game Over!!!", "red");
        PlayerResult.Instance._gameResults.AddGameResult(PlayerResult.Instance.GetThisSaveData());
        PlayerResult.Instance._gameResults.SaveToFile(Application.persistentDataPath + "/gameResults.xml");
        SoundsController.Instance.PlayOtherSounds(1);

        norep = false;
    }

    private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

    private void GoInMainMenu()
    {
        Debug.Log("1414124");
        SceneManager.LoadScene("MainMenu");
    }
}
