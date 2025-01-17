using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MachinGunTuretController : MonoBehaviour
{
    private BuildingController buildingController;

    public GameObject turetBullet;

    private Transform targetEnemy;

    private Vector3 directionFromTurretToEnemy;

    private Quaternion smoothlyRotation;

    private float rotationSpeed = 10f;
    private float angleNeededToLook;
    private float detectionRadius = 10f;
    private float nextFireTime;
    private float fireRate = 0.2f;

    private bool building = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && building)
        {
            building = false;
        }

        if (!building)
        {
            FindTarget();
            RotateTurret();
            Shoot();
        }
    }

    private void Shoot()
    {
        if (targetEnemy != null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            PlayerResult.Instance.BulletsFired += 1;
            Instantiate(turetBullet, transform.position, transform.rotation);
            SoundsController.Instance.PlayTurretShots(2);
        }
    }

    private void RotateTurret()
    {
        if (targetEnemy != null)
        {
            directionFromTurretToEnemy = (targetEnemy.position - transform.position).normalized;

            angleNeededToLook = Mathf.Atan2(directionFromTurretToEnemy.y, directionFromTurretToEnemy.x) * Mathf.Rad2Deg;

            smoothlyRotation = Quaternion.Euler(new Vector3(0, 0, angleNeededToLook));
            transform.rotation = Quaternion.Slerp(transform.rotation, smoothlyRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        targetEnemy = enemies
            .Select(enemy => enemy.transform)
            .Where(enemy => Vector2.Distance(transform.position, enemy.position) <= detectionRadius)
            .OrderBy(enemy => Vector2.Distance(transform.position, enemy.position))
            .FirstOrDefault();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
