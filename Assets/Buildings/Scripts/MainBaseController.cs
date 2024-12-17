using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBaseController : MonoBehaviour
{
    public HealthBarController mainBaseHealthBar;

    public int maxHealth = 1000;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        mainBaseHealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentHealth -= 100;
            mainBaseHealthBar.SetHealth(currentHealth);
        }
    }
}
