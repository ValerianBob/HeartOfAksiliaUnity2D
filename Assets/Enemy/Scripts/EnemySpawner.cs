using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] enemiesAlive;

    public TextMeshProUGUI waves;

    private int wavesCount = 0;
    public int secondsToRespawn = 0;

    private bool canStartNewWave = true;

    private Coroutine secondsCounter;

    //Beetle Light :
    private Coroutine beetleLight1;
    private Coroutine beetleLight2;
    private Coroutine beetleLight3;
    //Beetle Medium :
    private Coroutine beetleMedium1;
    private Coroutine beetleMedium2;
    private Coroutine beetleMedium3;
    //Beetle Heavy :
    private Coroutine beetleHeavy1;
    private Coroutine beetleHeavy2;
    private Coroutine beetleHeavy3;

    private Vector3[] spawnPositions =
    {
        new Vector3(-75, -74, -1),
        new Vector3(-75, 74, -1),
        new Vector3(75, 74, -1),
        new Vector3(75, -74, -1),
    };

    private void Start()
    {
        waves.text = wavesCount.ToString() + " wave";

        secondsCounter = StartCoroutine(SecondsCounter());
    }

    private void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (wavesCount < 3 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            BeetleLightCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            Debug.Log("Wave : " + wavesCount.ToString() + " Started !");
            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 6 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            Debug.Log("Wave : " + wavesCount.ToString() + " Started !");
            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 9 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            Debug.Log("Wave : " + wavesCount.ToString() + " Started !");
            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (secondsToRespawn == 60)
        {
            secondsToRespawn = 0;
            StopCoroutine(secondsCounter);
            StopAllEnemiesSpawn();

            canStartNewWave = false;

            Debug.Log("Wave : " + wavesCount.ToString() + " Ended !");
            Debug.Log("Enemise left :" + enemiesAlive.Length.ToString());
        }
        else if (enemiesAlive.Length == 0 && canStartNewWave == false)
        {
            secondsCounter = StartCoroutine(SecondsCounter());
            canStartNewWave = true;

            Debug.Log("All enemies are dead !!");
            NotificationsController.Instance.AddNewMessage("Enemies Dead", "green");
        }
    }

    private void StopAllEnemiesSpawn()
    {
        // light :
        if (beetleLight1 != null)
        {
            StopCoroutine(beetleLight1);
        }
        if (beetleLight2 != null)
        {
            StopCoroutine(beetleLight2);
        }
        if (beetleLight3 != null)
        {
            StopCoroutine(beetleLight3);
        }
        // medium :
        if (beetleMedium1 != null)
        {
            StopCoroutine(beetleMedium1);
        }
        if (beetleMedium2 != null)
        {
            StopCoroutine(beetleMedium2);
        }
        if (beetleMedium3 != null)
        {
            StopCoroutine(beetleMedium3);
        }
        //Heavy :
        if (beetleHeavy1 != null)
        {
            StopCoroutine(beetleHeavy1);
        }
        if (beetleHeavy2 != null)
        {
            StopCoroutine(beetleHeavy2);
        }
        if (beetleHeavy3 != null)
        {
            StopCoroutine(beetleHeavy3);
        }
    }

    private void BeetleLightCoroutinesStarter()
    {
        if (wavesCount <= 1)
        {
            beetleLight1 = StartCoroutine(SpawnBeetle(0));
        }
        else if (wavesCount <= 2)
        {
            beetleLight1 = StartCoroutine(SpawnBeetle(0));
            beetleLight2 = StartCoroutine(SpawnBeetle(0));
        }
        else if (wavesCount >= 3)
        {
            beetleLight1 = StartCoroutine(SpawnBeetle(0));
            beetleLight2 = StartCoroutine(SpawnBeetle(0));
            beetleLight3 = StartCoroutine(SpawnBeetle(0));
        }
    }

    private void BeetleMediumCoroutinesStarter()
    {
        if (wavesCount <= 4)
        {
            beetleMedium1 = StartCoroutine(SpawnBeetle(1));
        }
        else if (wavesCount <= 5)
        {
            beetleMedium1 = StartCoroutine(SpawnBeetle(1));
            beetleMedium2 = StartCoroutine(SpawnBeetle(1));
        }
        else if (wavesCount >= 6)
        {
            beetleMedium1 = StartCoroutine(SpawnBeetle(1));
            beetleMedium2 = StartCoroutine(SpawnBeetle(1));
            beetleMedium3 = StartCoroutine(SpawnBeetle(1));
        }
    }

    private void BeetleHeavyCoroutinesStarter()
    {
        if (wavesCount <= 7)
        {
            beetleHeavy1 = StartCoroutine(SpawnBeetle(2));
        }
        else if (wavesCount <= 8)
        {
            beetleHeavy1 = StartCoroutine(SpawnBeetle(2));
            beetleHeavy2 = StartCoroutine(SpawnBeetle(2));
        }
        else if (wavesCount >= 9)
        {
            beetleHeavy1 = StartCoroutine(SpawnBeetle(2));
            beetleHeavy2 = StartCoroutine(SpawnBeetle(2));
            beetleHeavy3 = StartCoroutine(SpawnBeetle(2));
        }
    }

    private IEnumerator SpawnBeetle(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            Instantiate(enemy[index], spawnPositions[Random.Range(0, spawnPositions.Length)], enemy[0].transform.rotation);
        }
    }

    private IEnumerator SecondsCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            secondsToRespawn += 1;
        }
    }
}
