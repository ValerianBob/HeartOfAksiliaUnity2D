using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnetgoTowerScript : MonoBehaviour
{
    private BuildingController buildingController;
    private BuildsShop buildsShop;

    public GameObject healingUI;
    private GameObject newHealingBar;

    private GameObject[] buildsInHealingFild;

    private float nextFireTime;
    private float healingSpeed = 1f;

    private bool building = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
        buildsShop = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildsShop>();
    }

    private void Update()
    {
        buildsInHealingFild = GameObject.FindGameObjectsWithTag("Build");

        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && building)
        {
            building = false;

            healingUI.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buildsShop.energoTowerCount + " HP";
        }

        if (Time.time >= nextFireTime && !building)
        {
            foreach (GameObject build in buildsInHealingFild)
            {
                if (build != null)
                {
                    build.GetComponent<HealthOfBuild>().HealingBuild(1);

                    if (build.transform.childCount < 3)
                    {
                        newHealingBar = Instantiate(healingUI, build.transform.position + new Vector3(0f,0f,-1f), healingUI.transform.rotation);
                        newHealingBar.transform.SetParent(build.transform);
                    }
                    else
                    {
                        build.transform.GetChild(2).gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buildsShop.energoTowerCount + " HP";
                    }

                    PlayerResult.Instance.CountOfTowerHealedHP += 1;
                }
            }
            nextFireTime = Time.time + healingSpeed;
        }
    }
}