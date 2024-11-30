using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunsShop : MonoBehaviour
{
    private HandController handController;

    public GameObject[] allGunsPrefabs;

    public Button buyShotGun;

    private bool shotGunHasBought = false;

    void Start()
    {
        handController = GameObject.Find("Kaylo").transform.GetChild(0).GetComponent<HandController>();

        buyShotGun.onClick.AddListener(BuyShotGun);
    }
    
    private void BuyShotGun()
    {
        if (!shotGunHasBought)
        {
            handController.allGunsInStock.Add(allGunsPrefabs[1]);
            shotGunHasBought = true;
        }
    }
}
