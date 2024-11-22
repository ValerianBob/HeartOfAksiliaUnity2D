using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SimpleTuretController : MonoBehaviour
{
    private BuildingController _buildingController;

    public GameObject turetBullet;

    private Transform targetEnemy;
    private Transform firePoint;

    private Vector3 directionFromTurretToEnemy;

    private Quaternion smoothlyRotation;

    private float rotationSpeed = 10f;
    private float angleNeededToLook;
    private float detectionRadius = 10f;
    private float nextFireTime;
    private float fireRate = 0.3f;

    private void Start()
    {
        _buildingController = GameObject.Find("Builds").transform.GetChild(0).GetComponent<BuildingController>();
    }

    private void Update()
    {
        FindTarget();
        RotateTurret();
        Shoot();
    }

    private void Shoot()
    {
        if (targetEnemy != null && Time.time >= nextFireTime)
        {
            Debug.Log("Fire !!!");
            nextFireTime = Time.time + fireRate;

            Instantiate(turetBullet, transform.position, transform.rotation);
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
