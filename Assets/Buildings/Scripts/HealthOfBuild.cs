using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthOfBuild : MonoBehaviour
{
    private Animator animator;

    public HealthBarController healthBar;
    private BuildingController buildingController;

    private int maxHealth;
    public int currentHealth;

    public bool gameOver = false;

    private bool setTag = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
        animator = transform.GetChild(0).GetComponent<Animator>();

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
        else if (gameObject.name == "MedTent(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 200;
        }
        else if (gameObject.name == "EnergoTower(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 210;
        }
        else if (gameObject.name == "MachinGunTuret(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 130;
        }
        else if (gameObject.name == "ShotGunTuret(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 130;
        }
        else if (gameObject.name == "PiercingTuret(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 130;
        }
        else if (gameObject.name == "CrystalFarming(Clone)" + buildingController.buildsCount)
        {
            maxHealth = 200;
        }
    }

    private void Update()
    {
        if (gameObject.name == "MainBase" && currentHealth <= 0 && gameOver==false)
        {
            GameOver.Instance.gameOver = true;
            gameOver = true; 
            animator.SetBool("Destroy", true);
        }
        else if (currentHealth <= 0 && gameObject.name != "MainBase")
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && setTag)
        {
            setTag = false;
            gameObject.tag = "Build";
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        SoundsController.Instance.PlayHit(1);
    }

    public void HealingBuild(int hp)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += hp;
            healthBar.SetHealth(currentHealth);
        }
    }
}
