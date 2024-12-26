using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class BuildsShop : MonoBehaviour
{
    private ShopController shopController;

    public GameObject[] builds;
    public GameObject chosenBuild;

    public Button buySimpleTurel;
    public Button buyMedTent;
    public Button buyEnergoTower;

    public bool isBuying = false;

    void Start()
    {
        shopController = GetComponent<ShopController>();
        buySimpleTurel.onClick.AddListener(BuySimpleTurel);
        buyMedTent.onClick.AddListener(BuyMedTent);
        buyEnergoTower.onClick.AddListener(BuyEnergoTower);
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

        if (CrystalsController.Instance.crystals < 200)
        {
            buyMedTent.interactable = false;
        }
        else
        {
            buyMedTent.interactable = true;
        }

        if (CrystalsController.Instance.crystals < 300)
        {
            buyEnergoTower.interactable = false;
        }
        else
        {
            buyEnergoTower.interactable = true;
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
        NotificationsController.Instance.AddNewMessage("Simple Turrel bought","blue");
    }

    private void BuyMedTent()
    {
        CrystalsController.Instance.crystals -= 200;
        chosenBuild = builds[1];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Med Tent bought", "blue");
    }

    private void BuyEnergoTower()
    {
        CrystalsController.Instance.crystals -= 300;
        chosenBuild = builds[2];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Energo bought", "blue");
    }
}
