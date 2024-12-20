using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthOfBuild : MonoBehaviour
{
    public HealthBarController healthBar;
    private BuildingController buildingController;

    private int maxHealth;
    public int currentHealth;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();

        SetHalthForBuild();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void SetHalthForBuild()
    {
        if (gameObject.name == "MainBase")
        {
            maxHealth = 1000;
        }
        else if (gameObject.name == "SimpleTuret(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 120;
        }
    }

    private void Update()
    {
        if (gameObject.name == "MainBase" && currentHealth <= 0)
        {
            GameOver.Instance.gameOver = true;
        }
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
