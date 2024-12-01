using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    private ShopController _shopController;
    private InGameMenuController _inGameMenuController;
    private GunsShop gunsShop;

    public GameObject player;
    public GameObject[] bulletPrefabs;
    public List<GameObject> allGunsInStock = new List<GameObject>();
    private GameObject spawnBullet;

    public Image[] gunsImages;

    private Vector3 difference;
    private Vector3 playrLocalScale;
    private Vector3 bulletColibration = new Vector3(0f, -0.3f, 0f);

    private Vector2 newBulletDirection;

    private float rotationZ;
    private float playerScale;

    private int currentGun;

    private string activeGun;

    private void Start()
    {
        playerScale = player.transform.localScale.x;

        _inGameMenuController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<InGameMenuController>();
        _shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();
        gunsShop = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<GunsShop>();

        allGunsInStock.Add(gunsShop.allGunsPrefabs[0]);

        currentGun = 0;
    }

    private void Update()
    {
        if (!_inGameMenuController.isPause && !GameOver.Instance.gameOver)
        {
            HandMovement();

            if (Input.GetMouseButtonDown(0) && !_shopController.isOpened)
            {
                Shoot();
            }

            ChooseGun();
        }
    }

    private void HandMovement()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        playrLocalScale = player.transform.localScale;

        if (rotationZ < -90 || rotationZ > 90)
        {
            playrLocalScale.x = -playerScale;
            transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            playrLocalScale.x = playerScale;
            transform.localScale = new Vector3(1, 1, 1);
        }

        player.transform.localScale = playrLocalScale;
    }

    private void Shoot()
    {
        newBulletDirection = transform.position + difference + bulletColibration;
        spawnBullet = Instantiate(bulletPrefabs[currentGun], newBulletDirection, transform.rotation);    
    }

    private void ChooseGun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentGun > 0)
            {
                currentGun -= 1;
            }
            else
            {
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentGun < allGunsInStock.Count - 1)
            {
                currentGun += 1;
            }
            else
            {
            }
        }

        for (int i = 0; i <  allGunsInStock.Count; i++)
        {
            allGunsInStock[i].gameObject.SetActive(false);

            if (i == currentGun)
            {
                allGunsInStock[i].gameObject.SetActive(true);
                activeGun = allGunsInStock[i].gameObject.name;
            }
        }

        for (int i = 0; i < gunsImages.Length; i++)
        {
            gunsImages[i].gameObject.SetActive(false);

            if (activeGun + "Image" == gunsImages[i].gameObject.name)
            {
                gunsImages[i].gameObject.SetActive(true);
            }
        }
    }
}