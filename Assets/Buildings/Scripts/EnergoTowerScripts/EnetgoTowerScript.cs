using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnetgoTowerScript : MonoBehaviour
{
    private BuildingController buildingController;

    public GameObject healingUI;

    private GameObject[] buildsInHealingFild;

    private float nextFireTime;
    private float healingSpeed = 1f;

    private bool building = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
    }

    private void Update()
    {
        buildsInHealingFild = GameObject.FindGameObjectsWithTag("Build");

        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && building)
        {
            building = false;
        }

        if (Time.time >= nextFireTime && !building)
        {
            foreach (GameObject build in buildsInHealingFild)
            {
                if (build != null)
                {
                    build.GetComponent<HealthOfBuild>().HealingBuild(1);
                    Instantiate(healingUI, build.transform.position, healingUI.transform.rotation);
                }
            }
            nextFireTime = Time.time + healingSpeed;
        }
    }
}
