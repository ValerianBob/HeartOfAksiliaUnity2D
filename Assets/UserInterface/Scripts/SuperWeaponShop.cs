using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuperWeaponShop : MonoBehaviour
{
    public GameObject[] allSuperWeaponsPrefabs;
    private GameObject[] slots = new GameObject[maxSlots];

    private const int maxSlots = 6;

    public Button buyMine;

    private void Start()
    {
        buyMine.onClick.AddListener(BuyMine);
    }

    private void Update()
    {
        CheckOnCost();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(allSuperWeaponsPrefabs[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Key 2 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Key 3 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Key 4 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Key 5 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("Key 6 pressed");
        }
    }

    private void CheckOnCost()
    {
        if (CrystalsController.Instance.orangeCrystals >= 25)
        {
            buyMine.interactable = true;
        }
        else
        {
            buyMine.interactable = false;
        }
    }

    private void BuyMine()
    {
        if (slots.Count() == maxSlots)
        {
            NotificationsController.Instance.AddNewMessage("Super Wepon Full", "red");
        }
        else if (slots.Length < maxSlots)
        {
            CrystalsController.Instance.orangeCrystals -= 25;

            slots[0] = allSuperWeaponsPrefabs[0];

            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Mine bought", "blue");
        }
    }
}
