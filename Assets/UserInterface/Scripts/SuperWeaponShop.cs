using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SuperWeaponShop : MonoBehaviour
{
    public GameObject superWeaponsUI;

    public GameObject[] allSuperWeaponsPrefabs;

    private const int maxSlots = 6;
    private GameObject[] slots = new GameObject[maxSlots];

    public Button buyMine;

    private bool checkOnNull = false;
    private bool slotIsUsing = false;

    private void Start()
    {
        buyMine.onClick.AddListener(BuyMine);
    }

    private void Update()
    {
        CheckOnCost();

        if (Input.GetMouseButtonDown(1) && slotIsUsing)
        {
            slotIsUsing = false;
        }

        Debug.Log("Slot is using :" + slotIsUsing);

        if (Input.GetKeyDown(KeyCode.Alpha1) && !slotIsUsing)
        {
            UseSlot(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !slotIsUsing)
        {
            UseSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !slotIsUsing)
        {
            UseSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && !slotIsUsing)
        {
            UseSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && !slotIsUsing)
        {
            UseSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && !slotIsUsing)
        {
            UseSlot(5);
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
        checkOnNull = AreAllSlotsFull();

        if (!checkOnNull)
        {
            CrystalsController.Instance.orangeCrystals -= 25;

            AddItemToSlot(allSuperWeaponsPrefabs[0]);

            DisplaySlots();

            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Mine bought", "blue");
            PlayerResult.Instance.CountOfBoughtSuperWeapon += 1;
        }
        else
        {
            NotificationsController.Instance.AddNewMessage("All slots full", "red");
        }
    }

    private bool AreAllSlotsFull()
    {
        foreach (GameObject slot in slots)
        {
            if (slot == null)
            {
                return false; // At least one slot is empty
            }
        }
        return true; // All slots are full
    }

    public void AddItemToSlot(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                superWeaponsUI.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true);
                return;
            }
        }
    }

    public void DisplaySlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log($"Slot {i}: {(slots[i] != null ? slots[i].name : "Empty")}");
        }
    }

    private void UseSlot(int index)
    {
        if (slots[index] != null)
        {
            if (slots[index].name == "Mine")
            {
                MineController mineController = slots[index].GetComponent<MineController>();
                slotIsUsing = mineController.isPlacing;
            }

            Instantiate(slots[index]);
            slots[index] = null;
            superWeaponsUI.transform.GetChild(0).transform.GetChild(index).gameObject.SetActive(false);
            DisplaySlots();
        }
        else
        {
            NotificationsController.Instance.AddNewMessage("Empty Slot", "red");
        }
    }
}
