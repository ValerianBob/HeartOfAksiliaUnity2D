using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedTentScript : MonoBehaviour
{
    private BuildingController buildingController;

    private CharacterController player;
    public GameObject healingUI;

    private float nextFireTime;
    private float healingSpeed = 1f;

    private bool building = true;

    private void Start()
    {
        buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
        player = GameObject.Find("Kaylo").GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !buildingController.canNotBuildHere && building)
        {
            building = false;
        }

        if (Time.time >= nextFireTime && !building && !player.isPlayerDead)
        {
            player.Healing(1);
            Instantiate(healingUI, player.transform.position, healingUI.transform.rotation);
            nextFireTime = Time.time + healingSpeed;
        }
    }
}
