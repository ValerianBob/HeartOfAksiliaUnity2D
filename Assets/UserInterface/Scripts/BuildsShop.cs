using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildsShop : MonoBehaviour
{
    private ShopController shopController;

    public GameObject[] builds;
    public GameObject chosenBuild;

    public Button buySimpleTurel;

    public bool isBuying = false;

    void Start()
    {
        shopController = GetComponent<ShopController>();

        buySimpleTurel.onClick.AddListener(BuyTurel);
    }

    private void BuyTurel()
    {
        chosenBuild = builds[0];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
    }
}
