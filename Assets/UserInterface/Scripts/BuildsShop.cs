using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildsShop : MonoBehaviour
{
    private ShopController shopController;

    public GameObject[] builds;
    public GameObject chosenBuild;

    public Button buyTurel;
    public Button buyRedTurel;

    public bool isBuying = false;

    void Start()
    {
        shopController = GetComponent<ShopController>();

        buyTurel.onClick.AddListener(BuyTurel);
        buyRedTurel.onClick.AddListener(BuyRedTurel);
    }

    private void BuyTurel()
    {
        chosenBuild = builds[0];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
    }

    private void BuyRedTurel()
    {
        chosenBuild = builds[1];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
    }
}
