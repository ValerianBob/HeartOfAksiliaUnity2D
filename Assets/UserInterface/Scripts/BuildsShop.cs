using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildsShop : MonoBehaviour
{
    private ShopController shopController;
    private SoundsController _soundController;

    public GameObject[] builds;
    public GameObject chosenBuild;

    public Button buySimpleTurel;

    public bool isBuying = false;

    void Start()
    {
        _soundController = GameObject.Find("SoundsManager").GetComponent<SoundsController>();
        shopController = GetComponent<ShopController>();

        buySimpleTurel.onClick.AddListener(BuySimpleTurel);
    }

    private void BuySimpleTurel()
    {
        chosenBuild = builds[0];
        isBuying = true;

        shopController.isOpened = !shopController.isOpened;
        shopController.shopMenu.SetActive(false);
        _soundController.PlayShopsSound(0);
    }
}
