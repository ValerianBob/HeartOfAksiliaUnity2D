using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private BuildsShop buildsShop;

    private GameObject arrayOfAllBuildingsInGame;
    private GameObject newBuild;

    private Collider2D newBuildCollider;

    Vector3 mouseScreenPosition;
    Vector3 mouseWorldPosition;

    public bool buildingMode = false;
    public bool canNotBuildHere = false;

    public int buildsCount = 0;

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

            newBuildCollider = newBuild.GetComponent<Collider2D>();

            newBuild.name += buildsCount.ToString();

            newBuild.transform.SetParent(arrayOfAllBuildingsInGame.transform);
        }

        if (buildingMode)
        {
            newBuild.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -1);
        }

        if (Input.GetMouseButtonDown(1) && !canNotBuildHere)
        {
            buildsCount += 1;
            buildingMode = false;
            buildsShop.isBuying = false;
            newBuildCollider.isTrigger = false;
            SoundsController.Instance.PlayBuildsSound(0);
        }
    }
}
