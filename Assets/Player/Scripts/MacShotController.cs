using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacShotController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private ShopController _shopController;
    private InGameMenuController _inGameMenuController;

    public HandController handController;

    private Vector2 newBulletDirection;

    private float fireRate = 0.1f;

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
            if (Input.GetMouseButton(0) && !_shopController.isOpened)
            {
                if (Time.time >= nextFireTime)
                {
                    Mac10Shot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void Mac10Shot()
    {
        newBulletDirection = transform.position + handController.difference;

        Instantiate(bulletPrefab, newBulletDirection, transform.rotation);
    }
}
