using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnetgoTowerScript : MonoBehaviour
{
    private BuildingController buildingController;
    private bool building = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && building)
        {
            building = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
