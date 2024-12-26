using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergoHealingFildScript : MonoBehaviour
{
    public GameObject healingUI;

    private List<GameObject> buildsInHealingFild;

    private float nextFireTime;
    private float healingSpeed = 1f;

    private void Start()
    {
        buildsInHealingFild = new List<GameObject>();
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            foreach (GameObject build in buildsInHealingFild)
            {
                if (build != null)
                {
                    build.GetComponent<HealthOfBuild>().HealingBuild(1);
                    Instantiate(healingUI, build.transform.position, healingUI.transform.rotation);
                }
            }
            nextFireTime = Time.time + healingSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Build"))
        {
            buildsInHealingFild.Add(collision.gameObject);
        }
    }
}
