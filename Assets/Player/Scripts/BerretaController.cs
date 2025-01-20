using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerretaController : MonoBehaviour
{
    public CharacterController characterController;

    public GameObject bulletPrefab;

    private ShopController _shopController;
    private InGameMenuController _inGameMenuController;

    public HandController handController;

    private Vector2 newBulletDirection;

    private float fireRate = 0.3f;

    private float nextFireTime = 0f; 

    public bool fire = false;

    void Start()
    {
        _inGameMenuController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<InGameMenuController>();
        _shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();
    }

    void LateUpdate()
    {
        if (!_inGameMenuController.isPause && !GameOver.Instance.gameOver && !characterController.isPlayerDead)
        {
            if (Input.GetMouseButtonDown(0) && !_shopController.isOpened)
            {
                if (Time.time >= nextFireTime)
                {
                    fire = true;
                    BerretaShot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void BerretaShot()
    {
        newBulletDirection = transform.position + handController.difference;

        Instantiate(bulletPrefab, newBulletDirection, transform.rotation);

        PlayerResult.Instance.BulletsFired += 1;
    }
}
