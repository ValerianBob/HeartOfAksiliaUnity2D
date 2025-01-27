using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperWeaponShop : MonoBehaviour
{
    public GameObject[] superWeaponUI;

    public GameObject[] allSuperWeaponsPrefabs;

    private const int maxSlots = 6;
    private GameObject[] slots = new GameObject[maxSlots];

    public Button buyMine;
    public Button buyElectrickShock;
    public Button buyAirStrick;
    public Button buyLaserRain;

    private int mineCost = 50;
    private int electricShockCost = 250;
    private int airStrickCost = 450;
    private int laserRainCost = 650;

    public TextMeshProUGUI mineCostText;
    public TextMeshProUGUI electrickShockText;
    public TextMeshProUGUI airStrikeText;
    public TextMeshProUGUI laserRainText;

    private bool checkOnNull = false;
    private bool cantPlaceHere = false;
    public bool slotIsUsing = false;

    private void Start()
    {
        buyMine.onClick.AddListener(BuyMine);
        buyElectrickShock.onClick.AddListener(BuyElectrickShock);

        buyLaserRain.onClick.AddListener(BuyLaserRain);

        mineCostText.text = "Cost : " + mineCost;
        electrickShockText.text = "Cost : " + electricShockCost;

        laserRainText.text = "Cost : " + laserRainCost;
    }

    private void Update()
    {
        CheckOnCost();

        //if (Input.GetMouseButtonDown(1) && slotIsUsing)
        //{
        //    slotIsUsing = false;
        //}

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
        if (CrystalsController.Instance.orangeCrystals >= mineCost)
        {
            buyMine.interactable = true;
        }
        else
        {
            buyMine.interactable = false;
        }
        if (CrystalsController.Instance.orangeCrystals >= electricShockCost)
        {
            buyElectrickShock.interactable = true;
        }
        else
        {
            buyElectrickShock.interactable = false;
        }

        if (CrystalsController.Instance.orangeCrystals >= laserRainCost)
        {
            buyLaserRain.interactable = true;
        }
        else
        {
            buyLaserRain.interactable = false;
        }
    }

    private void BuyMine()
    {
        checkOnNull = AreAllSlotsFull();

        if (!checkOnNull)
        {
            CrystalsController.Instance.orangeCrystals -= mineCost;

            AddItemToSlot(allSuperWeaponsPrefabs[0]);

            //DisplaySlots();

            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Mine bought", "blue");
            PlayerResult.Instance.CountOfBoughtSuperWeapon += 1;
        }
        else
        {
            NotificationsController.Instance.AddNewMessage("All slots full", "red");
        }
    }
    private void BuyElectrickShock()
    {
        checkOnNull = AreAllSlotsFull();

        if (!checkOnNull)
        {
            CrystalsController.Instance.orangeCrystals -= electricShockCost;

            AddItemToSlot(allSuperWeaponsPrefabs[1]);

            //DisplaySlots();

            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Electrick Shock bought", "blue");
            PlayerResult.Instance.CountOfBoughtSuperWeapon += 1;
        }
        else
        {
            NotificationsController.Instance.AddNewMessage("All slots full", "red");
        }
    }

    private void BuyLaserRain()
    {
        checkOnNull = AreAllSlotsFull();

        if (!checkOnNull)
        {
            CrystalsController.Instance.orangeCrystals -= laserRainCost;

            AddItemToSlot(allSuperWeaponsPrefabs[3]);

            //DisplaySlots();

            SoundsController.Instance.PlayShopsSound(0);
            NotificationsController.Instance.AddNewMessage("Laser Rain bought", "blue");
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
                Debug.Log(slots[i].name);
                if (slots[i].name == "Mine")
                {
                    superWeaponUI[0].transform.GetChild(i).gameObject.SetActive(true);
                }
                else if (slots[i].name == "ElectrickShock")
                {
                    superWeaponUI[1].transform.GetChild(i).gameObject.SetActive(true);
                }
                else if (slots[i].name == "LaserRain")
                {
                    superWeaponUI[3].transform.GetChild(i).gameObject.SetActive(true);
                }
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
                superWeaponUI[0].transform.GetChild(index).gameObject.SetActive(false);
                MineController mineController = slots[index].GetComponent<MineController>();
                slotIsUsing = mineController.isPlacing;
            }
            else if (slots[index].name == "ElectrickShock")
            {
                superWeaponUI[1].transform.GetChild(index).gameObject.SetActive(false);
                ElectrickShockFild electrickShockFild = slots[index].GetComponent<ElectrickShockFild>();
                slotIsUsing = electrickShockFild.isPlacing;
            }
            else if (slots[index].name == "LaserRain")
            {
                superWeaponUI[3].transform.GetChild(index).gameObject.SetActive(false);
            }

            Instantiate(slots[index]);

            slots[index] = null;
        }
        else
        {
            NotificationsController.Instance.AddNewMessage("Empty Slot", "red");
        }
    }
}
