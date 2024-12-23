using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildsShop : MonoBehaviour
{
    private ShopController shopController;

    public GameObject[] builds;
    public GameObject chosenBuild;

    public Button[] showBuildsInfoButtons;
    public Button buySimpleTurel;

    public bool isBuying = false;

    void Start()
    {
        shopController = GetComponent<ShopController>();
        buySimpleTurel.onClick.AddListener(BuySimpleTurel);
    }

    private void Update()
    {
        if (CrystalsController.Instance.crystals < 100)
        {
            buySimpleTurel.interactable = false;
        }
        else
        {
            buySimpleTurel.interactable = true;
        }
    }

    private void BuySimpleTurel()
    {
        CrystalsController.Instance.crystals -= 100;
        chosenBuild = builds[0];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Buy turrel","blue");
    }
}
