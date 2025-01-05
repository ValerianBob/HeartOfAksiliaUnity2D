using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunsShop : MonoBehaviour
{
    private HandController handController;

    public GameObject[] allGunsPrefabs;

    public Button buyShotGun;
    public Button buyMac10;

    private bool shotGunHasBought = false;
    private bool mac10HasBought = false;

    void Start()
    {
        handController = GameObject.Find("Kaylo").transform.GetChild(0).GetComponent<HandController>();

        buyShotGun.onClick.AddListener(BuyShotGun);
        buyMac10.onClick.AddListener(BuyMac10);
    }

    private void Update()
    {
        if (CrystalsController.Instance.orangeCrystals >= 100 && !mac10HasBought)
        {
            buyMac10.interactable = true;
        }
        else
        {
            buyMac10.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= 200 && !shotGunHasBought)
        {
            buyShotGun.interactable = true;
        }
        else
        {
            
            buyShotGun.interactable = false;
        }
    }

    private void BuyShotGun()
    {
        buyShotGun.interactable = false;
        if (!shotGunHasBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= 200;
            PlayerResult.Instance.Orange—rystalsSpent += 200;
            handController.allGunsInStock.Add(allGunsPrefabs[1]);
            shotGunHasBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy shotgun", "blue");
        }
    }

    private void BuyMac10()
    {
        buyMac10.interactable = false;
        if (!mac10HasBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= 100;
            PlayerResult.Instance.Orange—rystalsSpent -= 100;
            handController.allGunsInStock.Add(allGunsPrefabs[2]);
            mac10HasBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy mac10", "blue");
        }
    }
}
