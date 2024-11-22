using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTuretController : MonoBehaviour
{
    public GameObject turetBullet;

    private Transform enemy;

    private Vector3 directionFromTurretToEnemy;

    private Quaternion smoothlyRotation;

    private float rotationSpeed = 10f;
    private float angleNeededToLook;

    private bool turetSeeEnemy = false;

    void Update()
    {
        if (enemy != null)
        {
            directionFromTurretToEnemy = (enemy.position - transform.position).normalized;

            angleNeededToLook = Mathf.Atan2(directionFromTurretToEnemy.y, directionFromTurretToEnemy.x) * Mathf.Rad2Deg;

            smoothlyRotation = Quaternion.Euler(new Vector3(0, 0, angleNeededToLook));
            transform.rotation = Quaternion.Slerp(transform.rotation, smoothlyRotation, rotationSpeed * Time.deltaTime);
        
            if (!turetSeeEnemy)
            {
                StartCoroutine("TuretOpenFire");
                turetSeeEnemy = true;
            }
        }
        else
        {
            turetSeeEnemy = false;
        }
    }

    private IEnumerator TuretOpenFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(turetBullet, transform.position + directionFromTurretToEnemy, turetBullet.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<Transform>();
            Debug.Log("Turet see enemy !!!");
        }
    }
}
