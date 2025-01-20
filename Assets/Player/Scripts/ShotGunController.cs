using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunController : MonoBehaviour
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
                    ShotGunShot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void ShotGunShot()
    {
        newBulletDirection = transform.position + handController.difference;

        PlayerResult.Instance.BulletsFired += 7;

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
