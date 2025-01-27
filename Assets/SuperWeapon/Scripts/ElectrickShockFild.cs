using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrickShockFild : MonoBehaviour
{
    private SuperWeaponShop superWeaponShop;

    private ShopController shopController;

    public GameObject shockFlame;

    private HashSet<GameObject> enemiesInField = new HashSet<GameObject>();

    Vector3 mouseScreenPosition;
    Vector3 mouseWorldPosition;

    public bool isPlacing = true;
    private bool cantPlacHere = false;

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

            KillEnemy();
            SoundsController.Instance.PlayBuildsSound(0);
            Destroy(gameObject);
        }
    }

    private void KillEnemy()
    {
        foreach (GameObject enemy in enemiesInField)
        {
            if (enemy != null)
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                Instantiate(shockFlame, enemy.transform.position, shockFlame.transform.rotation);
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
