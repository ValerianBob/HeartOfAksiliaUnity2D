using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserRainController : MonoBehaviour
{
    public GameObject LaserBeam;

    private GameObject[] enemies;

    private int maxKills = 0;

    private float fireRate = 0.2f;

    private float nextFireTime = 0f;

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Time.time >= nextFireTime)
        {
            maxKills += 1;

            if (maxKills == 21)
            {
                Destroy(gameObject);
            }
            else 
            {
                try
                {
                    EnemyController enemyController = enemies[0].GetComponent<EnemyController>();
                    if (enemyController != null)
                    {
                        Instantiate(LaserBeam, enemyController.transform.position, LaserBeam.transform.rotation);
                        enemyController.KillEnemy();
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Don't see enemies !!!");
                }
            }

            nextFireTime = Time.time + fireRate;
        }
    }
}
