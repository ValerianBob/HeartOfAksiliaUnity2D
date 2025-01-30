using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipControllsGuid : MonoBehaviour
{
    public Button skip;

    private void Start()
    {
        Time.timeScale = 0;

        skip.onClick.AddListener(SkipControlls);
    }

    private void SkipControlls()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
