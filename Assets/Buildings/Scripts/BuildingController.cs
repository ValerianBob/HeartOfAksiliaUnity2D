using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private BuildsShop buildsShop;

    private GameObject arrayOfAllBuildingsInGame;
    private GameObject newBuild;

    Vector3 mouseScreenPosition;
    Vector3 mouseWorldPosition;

    private bool buildingMode = false;

    private int buildsCount = 0;

    private void Start()
    {
        arrayOfAllBuildingsInGame = GameObject.Find("Buildings");
        buildsShop = GetComponent<BuildsShop>();
    }

    private void Update()
    {
        mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        if (buildsShop.isBuying && !buildingMode)
        {
            buildingMode = true;

            newBuild = Instantiate(buildsShop.chosenBuild, new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -1),
                buildsShop.chosenBuild.transform.rotation);

            newBuild.name += buildsCount++.ToString();

            newBuild.transform.SetParent(arrayOfAllBuildingsInGame.transform);
        }

        if (buildingMode)
        {
            newBuild.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            buildingMode = false;
            buildsShop.isBuying = false;
        }
    }
}
