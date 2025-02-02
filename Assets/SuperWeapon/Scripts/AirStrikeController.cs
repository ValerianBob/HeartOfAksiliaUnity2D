using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AirStrikeController : MonoBehaviour
{
    private HashSet<GameObject> enemiesInField = new HashSet<GameObject>();

    private SuperWeaponShop superWeaponShop;
    private ShopController shopController;

    public GameObject Rocket;
    public GameObject explosionFlame;

    Vector3 mouseScreenPosition;
    Vector3 mouseWorldPosition;

    public bool isPlacing = true;
    private bool cantPlacHere = false;
    private bool rocketLaunch = false;

    void Start()
    {
        superWeaponShop = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<SuperWeaponShop>();
        shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();

        shopController.cantOpenWhilePlacingSuperWeapon = true;
    }

    void Update()
    {
        mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        if (isPlacing)
        {
            transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -1);
        }

        if (Input.GetMouseButtonDown(1) && isPlacing && !cantPlacHere)
        {
            isPlacing = false;
            superWeaponShop.slotIsUsing = isPlacing;
            shopController.cantOpenWhilePlacingSuperWeapon = false;

            rocketLaunch = true;

            Invoke(nameof(RocketHit), 0.5f);
        }

        if (rocketLaunch)
        {
            Rocket.transform.Translate(Vector2.up * 240f * Time.deltaTime);
        }
    }

    private void RocketHit()
    {
        KillEnemy();
        Instantiate(explosionFlame, transform.position, explosionFlame.transform.rotation);

        SoundsController.Instance.PlaySuperWeaponSounds(3, transform.position);

        Destroy(gameObject);
    }

    private void KillEnemy()
    {
        foreach (GameObject enemy in enemiesInField)
        {
            if (enemy != null)
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.KillEnemy();
            }
        }
        enemiesInField.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPlacing)
        {
            Debug.Log("I see enemy !");
            enemiesInField.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPlacing)
        {
            Debug.Log("I don't see enemy !");
            enemiesInField.Remove(collision.gameObject);
        }
    }
}
