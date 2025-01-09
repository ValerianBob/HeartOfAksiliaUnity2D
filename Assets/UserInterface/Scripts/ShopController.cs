using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private InGameMenuController _inGameMenuController;
    private BuildsShop buildsShop;

    public GameObject shopMenu;
    public GameObject buildsList;
    public GameObject gunsList;
    public GameObject superWeaponsList;

    public Button buildsButton;
    public Button gunsButton;
    public Button superWeapon;

    public bool isOpened = false;

    private bool buildsActive = true;
    private bool gunsActive = false;
    private bool superWeaponsActive = false;
    public bool cantOpenWhilePlacingSuperWeapon = false;

    private void Start()
    {
        _inGameMenuController = GetComponent<InGameMenuController>();

        buildsButton.onClick.AddListener(OpenBuildsList);
        gunsButton.onClick.AddListener(OpenGunsList);
        superWeapon.onClick.AddListener(OpenSuperWeaponsList);

        buildsShop = GetComponent<BuildsShop>();
    }

    private void Update()
    {
        if (!_inGameMenuController.isPause && !GameOver.Instance.gameOver)
        {
            OpenShop();
            ButtonsActive();
        }
    }

    private void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.B) && !buildsShop.isBuying && !cantOpenWhilePlacingSuperWeapon)
        {
            isOpened = !isOpened;
            shopMenu.SetActive(isOpened);
        }
    }

    private void ButtonsActive()
    {
        if (buildsActive && !gunsActive && !superWeaponsActive)
        {
            buildsButton.gameObject.SetActive(false);
            gunsButton.gameObject.SetActive(true);
            superWeapon.gameObject.SetActive(true);
        }
        else if (!buildsActive && gunsActive && !superWeaponsActive)
        {
            buildsButton.gameObject.SetActive(true);
            gunsButton.gameObject.SetActive(false);
            superWeapon.gameObject.SetActive(true);
        }
        else
        {
            buildsButton.gameObject.SetActive(true);
            gunsButton.gameObject.SetActive(true);
            superWeapon.gameObject.SetActive(false);
        }
    }

    private void OpenBuildsList()
    {
        buildsList.SetActive(true);
        gunsList.SetActive(false);
        superWeaponsList.SetActive(false);

        buildsActive = true;
        gunsActive = false;
        superWeaponsActive = false;

        SoundsController.Instance.PlayShopsSound(1);
    }
    private void OpenGunsList()
    {
        buildsList.SetActive(false);
        gunsList.SetActive(true);
        superWeaponsList.SetActive(false);

        buildsActive = false;
        gunsActive = true;
        superWeaponsActive = false;

        SoundsController.Instance.PlayShopsSound(1);
    }
    private void OpenSuperWeaponsList()
    {
        buildsList.SetActive(false);
        gunsList.SetActive(false);
        superWeaponsList.SetActive(true);

        buildsActive = false;
        gunsActive = false;
        superWeaponsActive = true;

        SoundsController.Instance.PlayShopsSound(1);
    }
}
