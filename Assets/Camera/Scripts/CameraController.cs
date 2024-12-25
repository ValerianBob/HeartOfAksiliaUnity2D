using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private CharacterController characterController;

    private float followSpeed = 10f;
    private float speedWhenDead = 25f;
    private float edgeBorder = 10f;

    private Vector3 offset;
    private Vector3 targetPosition;

    void Start()
    {
        player = GameObject.Find("Kaylo").GetComponent<Transform>();
        characterController = GameObject.Find("Kaylo").GetComponent<CharacterController>();
        offset = transform.position - player.position;
    }

    private void Update()
    {
        if (characterController.isPlayerDead)
        {
            Vector3 mousePos = Input.mousePosition;

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Vector3 movement = Vector3.zero;

            if (mousePos.x < edgeBorder)
            {
                movement.x = -speedWhenDead;
            }
            else if (mousePos.x > screenWidth - edgeBorder)
            {
                movement.x = speedWhenDead;
            }

            if (mousePos.y < edgeBorder)
            {
                movement.y = -speedWhenDead;
            }
            else if (mousePos.y > screenHeight - edgeBorder)
            {
                movement.y = speedWhenDead;
            }

            transform.Translate(movement * Time.deltaTime, Space.World);
        }
    }

    void LateUpdate()
    {
        if (!characterController.isPlayerDead)
        {
            targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
