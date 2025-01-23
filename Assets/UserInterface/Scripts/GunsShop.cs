using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunsShop : MonoBehaviour
{
    private HandController handController;

    public GameObject[] allGunsPrefabs;

    public Button buyShotGun;
    public Button buyMac10;
    public Button buyPecheneg;
    public Button buyAK;
    public Button buyGroza;

    private bool shotGunHasBought = false;
    private bool mac10HasBought = false;
    private bool pechenegBought = false;
    private bool akBought = false;
    private bool grozaBought = false;

    public TextMeshProUGUI mac10CostText;
    public TextMeshProUGUI shotGunCostText;
    public TextMeshProUGUI pechenegCostText;
    public TextMeshProUGUI akCostText;
    public TextMeshProUGUI grozaCostText;

    private int mac10Cost = 100;
    private int shotGunCost = 300;
    private int pechenegCost = 700;
    private int akCost = 500;
    private int grozaCost = 900;

    void Start()
    {
        handController = GameObject.Find("Kaylo").transform.GetChild(0).GetComponent<HandController>();

        buyShotGun.onClick.AddListener(BuyShotGun);
        buyMac10.onClick.AddListener(BuyMac10);
        buyPecheneg.onClick.AddListener(BuyPecheneg);
        buyAK.onClick.AddListener(BuyAk);
        buyGroza.onClick.AddListener(BuyGroza);

        mac10CostText.text = "Cost : " + mac10Cost.ToString();
        shotGunCostText.text = "Cost : " + shotGunCost.ToString();
        pechenegCostText.text = "Cost : " + pechenegCost.ToString();
        akCostText.text = "Cost : " + akCost.ToString();
        grozaCostText.text = "Cost : " + grozaCost.ToString();
    }

    private void Update()
    {
        if (CrystalsController.Instance.orangeCrystals >= mac10Cost && !mac10HasBought)
        {
            buyMac10.interactable = true;
        }
        else
        {
            buyMac10.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= shotGunCost && !shotGunHasBought)
        {
            buyShotGun.interactable = true;
        }
        else
        {
            
            buyShotGun.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= pechenegCost && !pechenegBought)
        {
            buyPecheneg.interactable = true;
        }
        else
        {

            buyPecheneg.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= akCost && !akBought)
        {
            buyAK.interactable = true;
        }
        else
        {

            buyAK.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= grozaCost && !grozaBought)
        {
            buyGroza.interactable = true;
        }
        else
        {

            buyGroza.interactable = false;
        }
    }

    private void BuyShotGun()
    {
        buyShotGun.interactable = false;
        if (!shotGunHasBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= shotGunCost;
            PlayerResult.Instance.Orange—rystalsSpent += shotGunCost;
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
            CrystalsController.Instance.orangeCrystals -= mac10Cost;
            PlayerResult.Instance.Orange—rystalsSpent -= mac10Cost;
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
            CrystalsController.Instance.orangeCrystals -= pechenegCost;
            PlayerResult.Instance.Orange—rystalsSpent -= pechenegCost;
            handController.allGunsInStock.Add(allGunsPrefabs[3]);
            pechenegBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy Pecheneg", "blue");
        }
    }

    private void BuyAk()
    {
        buyAK.interactable = false;
        if (!akBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= akCost;
            PlayerResult.Instance.Orange—rystalsSpent -= akCost;
            handController.allGunsInStock.Add(allGunsPrefabs[4]);
            akBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy AK", "blue");
        }
    }

    private void BuyGroza()
    {
        buyGroza.interactable = false;
        if (!grozaBought)
        {
            PlayerResult.Instance.CountOfBoughtGuns += 1;
            CrystalsController.Instance.orangeCrystals -= grozaCost;
            PlayerResult.Instance.Orange—rystalsSpent -= grozaCost;
            handController.allGunsInStock.Add(allGunsPrefabs[5]);
            grozaBought = true;
            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Buy Groza", "blue");
        }
    }
}
