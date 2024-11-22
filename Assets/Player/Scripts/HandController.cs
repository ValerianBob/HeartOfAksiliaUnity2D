using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private ShopController _shopController;
    private InGameMenuController _inGameMenuController;

    public GameObject player;
    public GameObject bulletPrefab;
    private GameObject bullet;

    private Vector3 difference;
    private Vector3 playrLocalScale;
    private Vector3 bulletColibration = new Vector3(0f, -0.3f, 0f);

    Vector2 newBulletDirection;

    private float rotationZ;
    private float playerScale;

    private void Start()
    {
        playerScale = player.transform.localScale.x;
        _inGameMenuController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<InGameMenuController>();
        _shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();
    }

    private void Update()
    {
        if (!_inGameMenuController.isPause)
        {
            HandMovement();

            if (Input.GetMouseButtonDown(0) && !_shopController.isOpened)
            {
                Shoot();
            }
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
            Debug.Log("Left");

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
        bullet = Instantiate(bulletPrefab, newBulletDirection, transform.rotation);
    }
}