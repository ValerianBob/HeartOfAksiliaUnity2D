using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private InGameMenuController _inGameMenuController;

    public GameObject player;
    public GameObject bulletPrefab; // Префаб пули
    public float weaponLength = 2f; // Длина оружия
    public float bulletSpeed = 100f;
    
    private Vector3 difference;
    private Vector3 playrLocalScale;

    private float rotationZ;
    private float playerScale;

    private void Start()
    {
        playerScale = player.transform.localScale.x;
        Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
        _inGameMenuController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<InGameMenuController>();
    }

    private void Update()
    {
        if (!_inGameMenuController.isPause)
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

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

        }
    }

    private void Shoot()
    {
         // Вычисляем позицию конца оружия (или руки) с помощью transform.right
        Vector2 direction = transform.localScale.x > 0 ? transform.right : -transform.right;
        Vector2 gunEndPosition = (Vector2)transform.position + direction * weaponLength; // Точка вылета пули

        // Создаём пулю
        GameObject bullet = Instantiate(bulletPrefab, gunEndPosition, transform.rotation);

        // Направляем пулю в зависимости от направления оружия
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed; // Направление и скорость пули
    }
}