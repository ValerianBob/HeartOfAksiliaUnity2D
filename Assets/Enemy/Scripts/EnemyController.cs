using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private CharacterController characterController;

    private EnemySpawner spawner;

    private Animator animator;

    private Transform player;
    private Transform currentTarget;

    private GameObject[] targets;

    private GameObject build;

    public GameObject _bloodPrefab;
    public GameObject _OrangeCrystall;

    private Vector3 targetDirection;
    private Vector3 localScale;
    private Vector3 obstacleAvoidDirection;

    private bool isAvoidingObstacle = false;

    private float enemySpeed = 9f;
    public float avoidSpeedMultiplier = 2f;

    private float attackRange = 20f;

    private float pastX;
    private float currentX;
    private float enemyScale;

    private float nextFireTime;
    private float attackSpeed = 0.5f;

    public int attackPower = 0;
    public int enemyHealth = 0;
    private int orangeCrystalsForKill = 0;

    private TextMeshProUGUI OrangeCrystallCountForKill;

    void Start()
    {
        animator = GetComponent<Animator>();

        player = GameObject.Find("Kaylo").GetComponent<Transform>();
        characterController = GameObject.Find("Kaylo").GetComponent<CharacterController>();

        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        OrangeCrystallCountForKill = _OrangeCrystall.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        SetEnemyParameters();

        pastX = transform.position.x;
        enemyScale = transform.localScale.x;
    }

    public void SetEnemyParameters()
    {
        if (gameObject.name == "BeetleLight(Clone)")
        {
            attackPower = 1;
            enemyHealth = 2;
            orangeCrystalsForKill = 1;
        }
        else if (gameObject.name == "BeetleMedium(Clone)")
        {
            attackPower = 2;
            enemyHealth = 3;
            orangeCrystalsForKill = 2;
        }
        else if (gameObject.name == "BeetleHeavy(Clone)")
        {
            attackPower = 3;
            enemyHealth = 4;
            orangeCrystalsForKill = 3;
        }
        else if (gameObject.name == "BeetleNeedl(Clone)")
        {
            attackPower = 4;
            enemyHealth = 5;
            orangeCrystalsForKill = 4;
        }
        else if (gameObject.name == "BeetleHorns(Clone)")
        {
            attackPower = 5;
            enemyHealth = 6;
            orangeCrystalsForKill = 5;
        }
        else if (gameObject.name == "BeetleMantis(Clone)")
        {
            attackPower = 6;
            enemyHealth = 7;
            orangeCrystalsForKill = 6;
        }

        attackPower += spawner.enemyNewPower;
        enemyHealth += spawner.enemyNewPower;
    }
    void Update()
    {
        ChooseTarget();
        EnemyMovement();
        EnemyRotation();
    }

    void ChooseTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Build");

        float playerDistance = Vector2.Distance(transform.position, player.position);
        float closestBuildingDistance = Mathf.Infinity;
        Transform closestBuilding = null;

        foreach (GameObject building in targets)
        {
            float buildingDistance = Vector2.Distance(transform.position, building.transform.position);
            if (buildingDistance < closestBuildingDistance)
            {
                closestBuildingDistance = buildingDistance;
                closestBuilding = building.transform;
            }
        }

        if (playerDistance <= attackRange && playerDistance < closestBuildingDistance)
        {
            if (!characterController.isPlayerDead)
            {
                currentTarget = player;
            }
            else
            {
                currentTarget = targets[0].transform;
            }
        }
        else if (closestBuildingDistance <= attackRange)
        {
            currentTarget = closestBuilding;
            build = closestBuilding.gameObject;
        }
        else
        {
            if (!characterController.isPlayerDead)
            {
                currentTarget = player;
            }
            else
            {
                currentTarget = targets[0].transform;
            }
        }
    }

    private void EnemyMovement()
    {
        if (!isAvoidingObstacle)
        {
            targetDirection = (currentTarget.transform.position - transform.position).normalized;
        }
        transform.Translate(targetDirection * enemySpeed * Time.deltaTime);
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

    private void AttackTarget(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kaylo"))
        {
            if (Time.time >= nextFireTime)
            {
                player.GetComponent<CharacterController>().TakingDamage(attackPower);
                nextFireTime = Time.time + attackSpeed;
                animator.SetBool("Attack", true);
            }
        }
        else if (collision.gameObject.CompareTag("Build"))
        {
            if (Time.time >= nextFireTime)
            {
                if (collision.gameObject.name == "MainBase")
                {
                    PlayerResult.Instance.CountOfMainBaseDamage += attackPower;
                }
                collision.gameObject.GetComponent<HealthOfBuild>().TakeDamage(attackPower);
                nextFireTime = Time.time + attackSpeed;
                animator.SetBool("Attack", true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        AttackTarget(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Attack", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BerretBullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= 1;

            if (enemyHealth == 0)
            {
                CountOfDeadCrip();
                Destroy(gameObject);
                SoundsController.Instance.PlayEnemyDeathSound(0);

                CrystalsController.Instance.orangeCrystals += orangeCrystalsForKill;

                OrangeCrystallCountForKill.text = "+" + orangeCrystalsForKill;

                PlayerResult.Instance.OrangeCrystalCollected += orangeCrystalsForKill;
                PlayerResult.Instance.Kills += 1;
                PlayerResult.Instance.KillsByPlayer += 1;

                Instantiate(_bloodPrefab, new Vector3(transform.position.x, transform.position.y, 0), _bloodPrefab.transform.rotation);
                Instantiate(_OrangeCrystall, new Vector3(transform.position.x, transform.position.y, -1), _OrangeCrystall.transform.rotation);
            }
        }

        if (collision.gameObject.CompareTag("PiercingTuretBullet") || collision.gameObject.CompareTag("SimpleTuretBullet"))
        {
            if (collision.gameObject.CompareTag("SimpleTuretBullet"))
            {
                Destroy(collision.gameObject);
            }

            enemyHealth -= 1;

            if (enemyHealth == 0)
            {
                CountOfDeadCrip();
                Destroy(gameObject);
                SoundsController.Instance.PlayEnemyDeathSound(0);

                CrystalsController.Instance.orangeCrystals += orangeCrystalsForKill;

                OrangeCrystallCountForKill.text = "+" + orangeCrystalsForKill;

                PlayerResult.Instance.OrangeCrystalCollected += orangeCrystalsForKill;
                PlayerResult.Instance.Kills += 1;
                PlayerResult.Instance.KillsByTower += 1;

                Instantiate(_bloodPrefab, new Vector3(transform.position.x, transform.position.y, 0), _bloodPrefab.transform.rotation);
                Instantiate(_OrangeCrystall, new Vector3(transform.position.x, transform.position.y, -1), _OrangeCrystall.transform.rotation);
            }
        }

        if (collision.gameObject.CompareTag("Mine"))
        {
            MineController mineController = collision.gameObject.GetComponent<MineController>();
            if (!mineController.isPlacing)
            {
                CountOfDeadCrip();
                Destroy(gameObject);
                Destroy(collision.gameObject);
                SoundsController.Instance.PlayEnemyDeathSound(0);
                SoundsController.Instance.PlayGunSound(4);

                CrystalsController.Instance.orangeCrystals += orangeCrystalsForKill;

                OrangeCrystallCountForKill.text = "+" + orangeCrystalsForKill;

                PlayerResult.Instance.OrangeCrystalCollected += orangeCrystalsForKill;
                PlayerResult.Instance.Kills += 1;
                PlayerResult.Instance.KillsBySuperWeapon += 1;

                Instantiate(_bloodPrefab, new Vector3(transform.position.x, transform.position.y, 0), _bloodPrefab.transform.rotation);
                Instantiate(_OrangeCrystall, new Vector3(transform.position.x, transform.position.y, -1), _OrangeCrystall.transform.rotation);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GoAroundTheRock(collision);
    //}

    private void GoAroundTheRock(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            obstacleAvoidDirection = (Vector3)collisionNormal;

            Vector3 avoidDirection = new Vector3(-obstacleAvoidDirection.y, obstacleAvoidDirection.x, 0);

            isAvoidingObstacle = true;

            Invoke("ResetAvoidObstacle", 0.3f);
        }
    }

    private void ResetAvoidObstacle()
    {
        isAvoidingObstacle = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void CountOfDeadCrip()
    {
        if (gameObject.name == "BeetleHeavy(Clone)")
        {
            PlayerResult.Instance.KillsBeetleHeavy += 1;
        }
        else if (gameObject.name == "BeetleLight(Clone)")
        {
            PlayerResult.Instance.KillsBeetleLight += 1;
        }
        else if (gameObject.name == "BeetleMedium(Clone)")
        {
            PlayerResult.Instance.KillsBeetleMedium += 1;
        }
        else if(gameObject.name == "KillsBeetleHorns(Clone)")
        {
            PlayerResult.Instance.KillsBeetleHorns += 1;
        }
        else if (gameObject.name == "KillsBeetleMantis(Clone)")
        {
            PlayerResult.Instance.KillsBeetleMantis += 1;
        }
        else if (gameObject.name == "KillsBeetleNeedl(Clone)")
        {
            PlayerResult.Instance.KillsBeetleNeedl += 1;
        }
    }
}
