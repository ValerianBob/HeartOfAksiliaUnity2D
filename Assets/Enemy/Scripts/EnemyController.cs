using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;

    private Vector3 playerDirection;
    private Vector3 localScale;

    private float enemySpeed = 9f;
    private float pastX;
    private float currentX;
    private float enemyScale;

    private bool enemyLookAt = false;

    void Start()
    {
        player = GameObject.Find("Kaylo").transform.GetChild(0);

        pastX = transform.position.x;
        enemyScale = transform.localScale.x;
    }

    void Update()
    {
        EnemyMovement();
        EnemyRotation();
    }

    private void EnemyMovement()
    {
        playerDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(playerDirection * enemySpeed * Time.deltaTime);
    }

    private void EnemyRotation()
    {
        currentX = transform.position.x;

        localScale = transform.localScale;

        if (currentX > pastX)
        {
            localScale.x = enemyScale;
        }
        else if (currentX < pastX)
        {
            localScale.x = -enemyScale;
        }

        transform.localScale = localScale;

        pastX = currentX;
    }
}
