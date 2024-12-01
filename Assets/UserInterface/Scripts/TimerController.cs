using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    private TextMeshProUGUI timerText;

    public int minutes;
    public int seconds;

    private void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

        StartCoroutine("TimerCounter");
    }

    private IEnumerator TimerCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            seconds += 1;

            if (seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
