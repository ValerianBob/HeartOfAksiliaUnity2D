using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PechenegController : MonoBehaviour
{
    public CharacterController characterController;

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
        if (!_inGameMenuController.isPause && !GameOver.Instance.gameOver && !characterController.isPlayerDead)
        {
            if (Input.GetMouseButton(0) && !_shopController.isOpened)
            {
                if (Time.time >= nextFireTime)
                {
                    PechenegShoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void PechenegShoot()
    {
        newBulletDirection = transform.position + handController.difference;

        PlayerResult.Instance.BulletsFired += 1;

        Instantiate(bulletPrefab, newBulletDirection, transform.rotation);

        SoundsController.Instance.PlayGunSound(3);
    }
}