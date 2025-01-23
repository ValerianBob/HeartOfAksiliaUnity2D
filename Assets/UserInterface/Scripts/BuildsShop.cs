using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshProUGUI simpleTuretCostText;
    public TextMeshProUGUI medTentCostText;
    public TextMeshProUGUI energoTowerCostText;
    public TextMeshProUGUI machineGunTuretCostText;
    public TextMeshProUGUI shotGunTuretCostText;
    public TextMeshProUGUI piercingTuretCostText;
    public TextMeshProUGUI crystalFarmingCostText;

    private int simpleTurelCost = 50;
    private int medTentCost = 200;
    private int energoTowerCost = 300;
    private int machineGunTuretCost = 200;
    private int shotGunTuretCost = 300;
    private int piercingTuretCost = 400;
    private int crystalFarmingCost = 100;

    public bool isBuying = false;

    public int energoTowerCount = 0;

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

        simpleTuretCostText.text = "Cost : " + simpleTurelCost.ToString();
        medTentCostText.text = "Cost : " + medTentCost.ToString();
        energoTowerCostText.text = "Cost : " + energoTowerCost.ToString();
        machineGunTuretCostText.text = "Cost : " + machineGunTuretCost.ToString();
        shotGunTuretCostText.text = "Cost : " + shotGunTuretCost.ToString();
        piercingTuretCostText.text = "Cost : " + piercingTuretCost.ToString();
        crystalFarmingCostText.text = "Cost : " + crystalFarmingCost.ToString();
    }

    private void Update()
    {
        if (CrystalsController.Instance.crystals < simpleTurelCost)
        {
            buySimpleTurel.interactable = false;
        }
        else
        {
            buySimpleTurel.interactable = true;
        }

        if (CrystalsController.Instance.crystals < medTentCost)
        {
            buyMedTent.interactable = false;
        }
        else
        {
            buyMedTent.interactable = true;
        }

        if (CrystalsController.Instance.crystals < energoTowerCost)
        {
            buyEnergoTower.interactable = false;
        }
        else
        {
            buyEnergoTower.interactable = true;
        }

        if (CrystalsController.Instance.crystals < machineGunTuretCost)
        {
            buyMachineGunTuret.interactable = false;
        }
        else
        {
            buyMachineGunTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < shotGunTuretCost)
        {
            buyShotGunTuret.interactable = false;
        }
        else
        {
            buyShotGunTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < piercingTuretCost)
        {
            buyPiercingTuret.interactable = false;
        }
        else
        {
            buyPiercingTuret.interactable = true;
        }

        if (CrystalsController.Instance.crystals < crystalFarmingCost)
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
        CrystalsController.Instance.crystals -= simpleTurelCost;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfSimpleTurel += 1;
        PlayerResult.Instance.BlueÑrystalsSpent += simpleTurelCost;
        chosenBuild = builds[0];
        isBuying = true;
        
        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Simple Turrel bought","blue");
    }

    private void BuyMedTent()
    {
        CrystalsController.Instance.crystals -= medTentCost;
        PlayerResult.Instance.BlueÑrystalsSpent += medTentCost;
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
        CrystalsController.Instance.crystals -= energoTowerCost;
        PlayerResult.Instance.BlueÑrystalsSpent += energoTowerCost;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfEnergoTower += 1;
        chosenBuild = builds[2];
        isBuying = true;

        energoTowerCount += 1;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Energo bought", "blue");
    }

    private void BuyMachineGunTuret()
    {
        CrystalsController.Instance.crystals -= machineGunTuretCost;
        PlayerResult.Instance.CountOfPlacedTowers += 1;
        PlayerResult.Instance.CountOfMachineGunTuret += 1;
        PlayerResult.Instance.BlueÑrystalsSpent += machineGunTuretCost;
        chosenBuild = builds[3];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        SoundsController.Instance.PlayShopsSound(0);
        NotificationsController.Instance.AddNewMessage("Machin Turet bought", "blue");
    }
    private void BuyShotGunTuret()
    {
        CrystalsController.Instance.crystals -= shotGunTuretCost;
        PlayerResult.Instance.BlueÑrystalsSpent += shotGunTuretCost;
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
        CrystalsController.Instance.crystals -= piercingTuretCost;
        PlayerResult.Instance.BlueÑrystalsSpent += piercingTuretCost;
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
        CrystalsController.Instance.crystals -= crystalFarmingCost;
        PlayerResult.Instance.BlueÑrystalsSpent += crystalFarmingCost;
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