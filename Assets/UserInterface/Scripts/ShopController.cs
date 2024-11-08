using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private BuildsShop buildsShop;

    public GameObject shopMenu;
    public GameObject buildsList;
    public GameObject gunsList;
    public GameObject superWeaponsList;

    public Button buildsButton;
    public Button gunsButton;
    public Button superWeapon;

    public bool isOpened = false;
    
    private void Start()
    {
        buildsButton.onClick.AddListener(OpenBuildsList);
        gunsButton.onClick.AddListener(OpenGunsList);
        superWeapon.onClick.AddListener(OpenSuperWeaponsList);

        buildsShop = GetComponent<BuildsShop>();
    }

    private void Update()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.B) && !buildsShop.isBuying)
        {
            isOpened = !isOpened;
            shopMenu.SetActive(isOpened);

            Cursor.visible = isOpened;
            if (isOpened)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void OpenBuildsList()
    {
        buildsList.SetActive(true);
        gunsList.SetActive(false);
        superWeaponsList.SetActive(false);
    }
    private void OpenGunsList()
    {
        buildsList.SetActive(false);
        gunsList.SetActive(true);
        superWeaponsList.SetActive(false);
    }
    private void OpenSuperWeaponsList()
    {
        buildsList.SetActive(false);
        gunsList.SetActive(false);
        superWeaponsList.SetActive(true);
    }
}
