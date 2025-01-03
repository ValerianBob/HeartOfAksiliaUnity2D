using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalFarmingController : MonoBehaviour
{
    private BuildingController buildingController;

    public GameObject crystalUI;

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
            StartCoroutine("FarmCrystal");
        }
    }

    private IEnumerator FarmCrystal()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            CrystalsController.Instance.crystals += 1;
            Instantiate(crystalUI, transform.position, crystalUI.transform.rotation);
        }
    }
}
