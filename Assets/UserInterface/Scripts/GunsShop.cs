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
    public Button buyPecheneg;

    private bool shotGunHasBought = false;
    private bool mac10HasBought = false;
    private bool pechenegBought = false;

    void Start()
    {
        handController = GameObject.Find("Kaylo").transform.GetChild(0).GetComponent<HandController>();

        buyShotGun.onClick.AddListener(BuyShotGun);
        buyMac10.onClick.AddListener(BuyMac10);
        buyPecheneg.onClick.AddListener(BuyPecheneg);
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

        if (CrystalsController.Instance.orangeCrystals >= 300 && !pechenegBought)
        {
            buyPecheneg.interactable = true;
        }
        else
        {

            buyPecheneg.interactable = false;
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
    private void BuyPecheneg()
    {
        buyPecheneg.interactable = false;
        if (!pechenegBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= 300;
            PlayerResult.Instance.Orange—rystalsSpent -= 300;
            handController.allGunsInStock.Add(allGunsPrefabs[3]);
            pechenegBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy Pecheneg", "blue");
        }
    }
}
