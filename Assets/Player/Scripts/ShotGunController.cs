using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private ShopController _shopController;
    private InGameMenuController _inGameMenuController;

    public HandController handController;

    private Vector2 newBulletDirection;

    private float fireRate = 0.4f;

    private float nextFireTime = 0f;

    void Start()
    {
        _inGameMenuController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<InGameMenuController>();
        _shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();
    }

    void LateUpdate()
    {
        if (!_inGameMenuController.isPause && !GameOver.Instance.gameOver)
        {
            if (Input.GetMouseButtonDown(0) && !_shopController.isOpened)
            {
                if (Time.time >= nextFireTime)
                {
                    ShotGunShot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void ShotGunShot()
    {
        newBulletDirection = transform.position + handController.difference;

        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, 5f));
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, 10f));
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, 15f));
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation);
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, -5f));
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, -10f));
        Instantiate(bulletPrefab, newBulletDirection, transform.rotation * Quaternion.Euler(0, 0, -15f));

        SoundsController.Instance.PlayGunSound(1);
    }
}