using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public static GameOver Instance { get; private set; }

	private TimerController time;

    private ShopController shop;

    public Image gameOverWindow;
	public TextMeshProUGUI timeResult;

	public Button InMainMenu;

	public bool gameOver = false;

    private void Start()
    {
        time = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<TimerController>();
        shop = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();

        InMainMenu.onClick.AddListener(GoInMainMenu);
    }

    private void Update()
    {
        if (gameOver)
		{
            Time.timeScale = 0;
            gameOverWindow.gameObject.SetActive(true);

            if (shop.isOpened)
            {
                shop.isOpened = false;
                shop.shopMenu.SetActive(false);
            }

            timeResult.text = "Your Result : " + string.Format("{0:00}:{1:00}", time.minutes, time.seconds);
            NotificationsController.Instance.AddNewMessage("Game Over!!!", "red");
        }
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
        SceneManager.LoadScene("MainMenu");
    }
}
