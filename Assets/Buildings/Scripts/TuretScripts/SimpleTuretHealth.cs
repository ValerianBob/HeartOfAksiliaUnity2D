using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTuretHealth : MonoBehaviour
{
    public HealthBarController turetHealthBar;

    private int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        turetHealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentHealth -= 10;
            turetHealthBar.SetHealth(currentHealth);
        }
    }
}
