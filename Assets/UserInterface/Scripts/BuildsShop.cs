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
    public Button buyMachineGunTuret;
    public Button buyShotGunTuret;
    public Button buyPiercingTuret;
    public Button buyCrystalFarming;

    public bool isBuying = false;

    void Start()
    {
        shopController = GetComponent<ShopController>();
        buySimpleTurel.onClick.AddListener(BuySimpleTurel);
        buyMedTent.onClick.AddListener(BuyMedTent);
        buyEnergoTower.onClick.AddListener(BuyEnergoTower);
        buyMachineGunTuret.onClick.AddListener(BuyMachineGunTuret);
        buyShotGunTuret.onClick.AddListener(BuyShotGunTuret);
        buyPiercingTuret.onClick.AddListener(BuyPiercingTuret);
        buyCrystalFarming.onClick.AddListener(BuyCrystalFarming);
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

        if (CrystalsController.Instance.crystals < 250)
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

        if (CrystalsController.Instance.crystals < 200)
        {
            buyMachineGunTuret.interactable = false;
        }
        else
        {
            buyMachineGunTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < 250)
        {
            buyShotGunTuret.interactable = false;
        }
        else
        {
            buyShotGunTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < 300)
        {
            buyPiercingTuret.interactable = false;
        }
        else
        {
            buyPiercingTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < 200)
        {
            buyCrystalFarming.interactable = false;
        }
        else
        {
            buyCrystalFarming.interactable = true;
        }
    }

    private void BuySimpleTurel()
    {
        CrystalsController.Instance.crystals -= 100;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfSimpleTurel += 1;
        PlayerResult.Instance.BlueÑrystalsSpent += 100;
        chosenBuild = builds[0];
        isBuying = true;
        
        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Simple Turrel bought","blue");
    }

    private void BuyMedTent()
    {
        CrystalsController.Instance.crystals -= 250;
        PlayerResult.Instance.BlueÑrystalsSpent += 200;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfMedTent += 1;
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
        PlayerResult.Instance.BlueÑrystalsSpent += 300;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfEnergoTower += 1;
        chosenBuild = builds[2];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Energo bought", "blue");
    }

    private void BuyMachineGunTuret()
    {
        CrystalsController.Instance.crystals -= 200;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfMachineGunTuret += 1;
        PlayerResult.Instance.BlueÑrystalsSpent += 200;
        chosenBuild = builds[3];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Machin Turet bought", "blue");
    }
    private void BuyShotGunTuret()
    {
        CrystalsController.Instance.crystals -= 250;
        PlayerResult.Instance.BlueÑrystalsSpent += 200;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfShotGunTuret += 1;
        chosenBuild = builds[4];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("ShotGunTuret bought", "blue");
    }

    private void BuyPiercingTuret()
    {
        CrystalsController.Instance.crystals -= 300;
        PlayerResult.Instance.BlueÑrystalsSpent += 300;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfPiercingTuret += 1;
        chosenBuild = builds[5];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("PiercingTuret bought", "blue");
    }

    private void BuyCrystalFarming()
    {
        CrystalsController.Instance.crystals -= 200;
        PlayerResult.Instance.BlueÑrystalsSpent += 200;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfCrystalFarming += 1;
        chosenBuild = builds[6];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("CrystalFarming bought", "blue");
    }
}