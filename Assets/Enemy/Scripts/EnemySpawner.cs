using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] enemiesAlive;

    public TextMeshProUGUI waves;

    public int wavesCount = 0;
    public int secondsToRespawn = 0;

    private bool canStartNewWave = true;

    private float spawnerSpeed = 1f;

    public int enemyNewPower = 0;

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
    //Beetle Needl :
    private Coroutine beetleNeedl1;
    private Coroutine beetleNeedl2;
    private Coroutine beetleNeedl3;
    //Beetle Horns :
    private Coroutine beetleHorns1;
    private Coroutine beetleHorns2;
    private Coroutine beetleHorns3;
    //Beetle Mantis :
    private Coroutine beetleMantis1;
    private Coroutine beetleMantis2;
    private Coroutine beetleMantis3;

    private Vector3[] spawnPositions =
    {
        //bottom :
        new Vector3(-75, -74, -1),
        new Vector3(-60, -74, -1),
        new Vector3(-40, -74, -1),
        new Vector3(-20, -74, -1),
        new Vector3(0, -74, -1),
        new Vector3(20, -74, -1),
        new Vector3(40, -74, -1),
        new Vector3(60, -74, -1),
        new Vector3(75, -74, -1),

        //Top :
        new Vector3(-75, 74, -1),
        new Vector3(-60, 74, -1),
        new Vector3(-40, 74, -1),
        new Vector3(-20, 74, -1),
        new Vector3(0, 74, -1),
        new Vector3(20, 74, -1),
        new Vector3(40, 74, -1),
        new Vector3(60, 74, -1),
        new Vector3(75, 74, -1),

        //Right :
        new Vector3(75, 40, -1),
        new Vector3(75, 20, -1),
        new Vector3(75, 0, -1),
        new Vector3(75, -40, -1),
        new Vector3(75, -20, -1),

        //Left :
        new Vector3(-75, 40, -1),
        new Vector3(-75, 20, -1),
        new Vector3(-75, 0, -1),
        new Vector3(-75, -40, -1),
        new Vector3(-75, -20, -1),
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

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 2;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 6 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 4;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 9 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 6;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 12 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 8;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();
            BeetleNeedlCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 15 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 10;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();
            BeetleNeedlCoroutinesStarter();
            BeetleHornsCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount < 18 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 12;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();
            BeetleNeedlCoroutinesStarter();
            BeetleHornsCoroutinesStarter();
            BeetleMantisCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (wavesCount >= 18 && secondsToRespawn == 30 && canStartNewWave == true)
        {
            wavesCount += 1;
            secondsToRespawn += 1;

            if (wavesCount % 2 == 0)
            {
                enemyNewPower += 14;
                NotificationsController.Instance.AddNewMessage("Enemy Power +" + enemyNewPower, "red");
            }

            BeetleLightCoroutinesStarter();
            BeetleMediumCoroutinesStarter();
            BeetleHeavyCoroutinesStarter();
            BeetleNeedlCoroutinesStarter();
            BeetleHornsCoroutinesStarter();
            BeetleMantisCoroutinesStarter();

            waves.text = wavesCount.ToString() + " wave";

            NotificationsController.Instance.AddNewMessage("Wave : " + wavesCount.ToString() + " Started !", "red");
            SoundsController.Instance.PlayOtherSounds(0);
        }
        else if (secondsToRespawn == 60)
        {
            secondsToRespawn = 0;
            StopCoroutine(secondsCounter);
            StopAllEnemiesSpawn();

            canStartNewWave = false;
        }
        else if (enemiesAlive.Length == 0 && canStartNewWave == false)
        {
            secondsCounter = StartCoroutine(SecondsCounter());
            canStartNewWave = true;

            NotificationsController.Instance.AddNewMessage("Enemies Dead", "green");
        }
        PlayerResult.Instance.Wave = wavesCount;
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
        //Needl :
        if (beetleNeedl1 != null)
        {
            StopCoroutine(beetleNeedl1);
        }
        if (beetleNeedl2 != null)
        {
            StopCoroutine(beetleNeedl2);
        }
        if (beetleNeedl3 != null)
        {
            StopCoroutine(beetleNeedl3);
        } 
        //Horns :
        if (beetleHorns1 != null)
        {
            StopCoroutine(beetleHorns1);
        }
        if (beetleHorns2 != null)
        {
            StopCoroutine(beetleHorns2);
        }
        if (beetleHorns3 != null)
        {
            StopCoroutine(beetleHorns3);
        }
        //Mantis :
        if (beetleMantis1 != null)
        {
            StopCoroutine(beetleMantis1);
        }
        if (beetleMantis2 != null)
        {
            StopCoroutine(beetleMantis2);
        }
        if (beetleMantis3 != null)
        {
            StopCoroutine(beetleMantis3);
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

    private void BeetleNeedlCoroutinesStarter()
    {
        if (wavesCount <= 10)
        {
            beetleNeedl1 = StartCoroutine(SpawnBeetle(3));
        }
        else if (wavesCount <= 11)
        {
            beetleNeedl1 = StartCoroutine(SpawnBeetle(3));
            beetleNeedl2 = StartCoroutine(SpawnBeetle(3));
        }
        else if (wavesCount >= 12)
        {
            beetleNeedl1 = StartCoroutine(SpawnBeetle(3));
            beetleNeedl2 = StartCoroutine(SpawnBeetle(3));
            beetleNeedl3 = StartCoroutine(SpawnBeetle(3));
        }
    }

    private void BeetleHornsCoroutinesStarter()
    {
        if (wavesCount <= 13)
        {
            beetleHorns1 = StartCoroutine(SpawnBeetle(4));
        }
        else if (wavesCount <= 14)
        {
            beetleHorns1 = StartCoroutine(SpawnBeetle(4));
            beetleHorns2 = StartCoroutine(SpawnBeetle(4));
        }
        else if (wavesCount >= 15)
        {
            beetleHorns1 = StartCoroutine(SpawnBeetle(4));
            beetleHorns2 = StartCoroutine(SpawnBeetle(4));
            beetleHorns3 = StartCoroutine(SpawnBeetle(4));
        }
    }

    private void BeetleMantisCoroutinesStarter()
    {
        if (wavesCount <= 16)
        {
            beetleMantis1 = StartCoroutine(SpawnBeetle(5));
        }
        else if (wavesCount <= 17)
        {
            beetleMantis1 = StartCoroutine(SpawnBeetle(5));
            beetleMantis2 = StartCoroutine(SpawnBeetle(5));
        }
        else if (wavesCount >= 18)
        {
            beetleMantis1 = StartCoroutine(SpawnBeetle(5));
            beetleMantis2 = StartCoroutine(SpawnBeetle(5));
            beetleMantis3 = StartCoroutine(SpawnBeetle(5));
        }
    }

    private IEnumerator SpawnBeetle(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnerSpeed);

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
