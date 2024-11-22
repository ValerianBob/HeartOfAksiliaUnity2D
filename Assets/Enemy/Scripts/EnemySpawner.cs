using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;

    private Vector3[] spawnPositions =
    {
        new Vector3(-20, -20, -1),
        new Vector3(-20, 20, -1),
        new Vector3(20, 20, -1),
        new Vector3(20, -20, -1),
    };

    private void Start()
    {
        StartCoroutine("EnemySpawnerCoroutine");
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            GameObject newEnemy = enemy[Random.Range(0, enemy.Length)];

            Instantiate(newEnemy, spawnPositions[Random.Range(0, spawnPositions.Length)], newEnemy.transform.rotation);
        }
    }
}
