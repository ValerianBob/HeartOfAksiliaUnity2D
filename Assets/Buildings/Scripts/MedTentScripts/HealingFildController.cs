using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFildController : MonoBehaviour
{
    private CharacterController player;
    public GameObject healingUI;

    private bool isHealing = false;

    private float nextFireTime;
    private float healingSpeed = 1f;

    private void Update()
    {
        if (Time.time >= nextFireTime && isHealing)
        {
            player.Healing(1);
            Instantiate(healingUI, player.transform.position, healingUI.transform.rotation);
            nextFireTime = Time.time + healingSpeed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kaylo"))
        {
            player = collision.gameObject.GetComponent<CharacterController>();
        }

        isHealing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isHealing = false;
    }
}
