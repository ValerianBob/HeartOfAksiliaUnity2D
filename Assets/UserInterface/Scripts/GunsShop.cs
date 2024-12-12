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
    
    private void BuyShotGun()
    {
        if (!shotGunHasBought)
        {
            handController.allGunsInStock.Add(allGunsPrefabs[1]);
            shotGunHasBought = true;
        }
    }

    private void BuyMac10()
    {
        if (!mac10HasBought)
        {
            handController.allGunsInStock.Add(allGunsPrefabs[2]);
            mac10HasBought = true;
        }
    }
}
